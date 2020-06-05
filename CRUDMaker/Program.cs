using ISS.Application.Helpers;
using ISS.Application.LinqToDb;
using ISS.Application.Models;
using LinqToDB;
using LinqToDB.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Saudações!!!\n\nQual opção desejas?");
            char _ans = 'n';
            do
            {
                Console.WriteLine("\n* GraphQL - g" +
                                  "\n* EFramework - e" +
                                  "\n* Quit - q");

                // Recuperando o valor digitado
                var ans = Console.ReadKey();

                // Alternado entre o valor
                switch (ans.KeyChar)
                {
                    case 'g': InitGraphQL("GraphQL, "); break;

                    case 'e':
                        _ans = ans.KeyChar;
                        Console.Clear();
                        InitEFramework("Entity Framework, ");
                        Console.WriteLine("Saindo... Obrigado pela escolha!!!");
                        break;

                    case 'q':
                        _ans = ans.KeyChar;
                        Console.Clear();
                        Console.WriteLine("Saindo... Obrigado pela escolha!!!");
                        break;

                    default: Console.WriteLine("Opção inválida: '" + ans.KeyChar + "' "); break;
                }

                Thread.Sleep(600);

            } while (_ans != 'q');
        }

        // -------- Main -------- 

        // Variavel auxiliar para armazenar o caminho do projecto principal 'a solucao'
        static readonly string solutionPath = SharedMethods.GlobalRootPath;
        // Variavel para classe de configuração de ficheiro json
        static JsonConfig jsonConfig = null;
        // Variavel para armazenar todos os modelos da base de dados
        static List<DbTable> AllDbTables = null;

        // Variavel auxiliar para adicionar objectos na geração dos objectos
        static List<(string, string)> constrainstGeracaoPessoas = new List<(string, string)> {
            (nameof(ISS.Application.Dto.Models.PessoaSingular), nameof(ISS.Application.Dto.Models.Pessoa)),
            (nameof(ISS.Application.Dto.Models.PessoaColectiva), nameof(ISS.Application.Dto.Models.Pessoa)),
        };

        // Função para pegar todas as entidades da Base de dados
        static List<DbTable> GetAllEntities()
        {
            // Obtendo o ficheiro json
            var jconfig = new JsonConfig($@"{solutionPath}ISS.WebApi\appsettings.json", false);
            // Pegando todo o ficheiro json
            var app = jconfig.Get();
            // Acessando o dados necessário
            var connection = ((dynamic)app).ConnectionStrings.LocalConnection.ToString();

            // Adicionando a connectionString
            DataConnection.DefaultSettings = new DbSettings(connection);
            // Instanciando o Linq
            var linq = new DataConnection();

            // Query para pegar todas as tabelas da base de dados
            var sql = $@"select c.TABLE_NAME as 'Name', c.COLUMN_NAME 'PrimaryKey' 
                        from INFORMATION_SCHEMA.KEY_COLUMN_USAGE as c 
                        where c.CONSTRAINT_NAME like 'PK_%' AND c.TABLE_NAME NOT LIKE 'AspNet%' AND C.TABLE_NAME NOT LIKE 'Sys%'";

            // A Tabela pessoa
            DbTable pessoa = null;

            // Pegando os dados da base de dados
            var tablesInfo = linq.FromSql<DbScaffold.TableColumn>
                    ($@"select c.TABLE_NAME, c.COLUMN_NAME, c.DATA_TYPE, c.IS_NULLABLE, 
                    (select count(i.TABLE_NAME) from INFORMATION_SCHEMA.COLUMNS as i
                    where COLUMNPROPERTY (object_id(i.TABLE_SCHEMA+'.'+i.TABLE_NAME), i.COLUMN_NAME, 'IsIdentity') = 1
                    and i.COLUMN_NAME = c.COLUMN_NAME) as IS_IDENTITY from INFORMATION_SCHEMA.COLUMNS as c").ToList();

            // Configurando os campos na base de dados
            var list = linq.FromSql<DbTable>(sql).ToList().Select(s =>
            {
                s.Name = SharedMethods.ToPascalCase(s.Name.Trim());
                s.PrimaryKey = SharedMethods.ToPascalCase(s.PrimaryKey.Trim());
                s.TableInfos = tablesInfo.Where(t => t.TABLE_NAME == s.Name).ToList();

                if (s.Name == "Pessoa") pessoa = s;

                return s;
            }).ToList();

            // Verificando se a pessoa foi encontrada
            if (pessoa != null)
            {
                // Criando as constraints partilhadas
                var shared = constrainstGeracaoPessoas.Select(sc =>
                {
                    return new DbTable
                    {
                        Name = sc.Item1,
                        PrimaryKey = pessoa.PrimaryKey,
                    };
                }).ToList();

                // Adicionando as constraints
                list.AddRange(shared);
            }

            return list;
        }

        // Função auxiliar para pegar a chave primaria de uma tabela
        static string GetPK(string tb) => AllDbTables.FirstOrDefault(x => x.Name == tb)?.PrimaryKey;
        #region GraphQL Creator

        // Função auxiliar para criar um objecto
        static Type GetTypeByName(string name)
        {
            // Verificador e construtor dos objectos da pessoa
            var cts = new List<string> {
                nameof(ISS.Application.Dto.Models.Pessoa),
                nameof(ISS.Application.Dto.Models.PessoaSingular),
                nameof(ISS.Application.Dto.Models.PessoaColectiva),
            };

            var _input_ = name;
            var _namespace_ = "ISS.Application"; // Definicão da namespace
            var _folder_ = _input_.Contains("Dto") ? "Dto" : "Models"; // Switching the folders

            if (cts.Any(x => x == name))
                _folder_ = "Dto.Models";

            // Construindo o assembly do objecto
            string assemby(string n, string f, string i) => $"{n}.{f}.{i}, {n}, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            // Pegando o respectivo objecto
            var obj = Type.GetType(assemby(_namespace_, _folder_, _input_));

            if (obj == null) // Verificando se o objecto não foi encontrado
            {
                // Alternando a pasta de  pesquisa
                _folder_ = _folder_ == "Dto" ? "Models" : "Dto";
                // Pegando o respectivo objecto
                obj = Type.GetType(assemby(_namespace_, _folder_, _input_));

                // Verificando se o objecto não foi encontrado
                if (obj == null) return null;
            }

            return obj;
        }

        static void InitGraphQL(string _v_)
        {

            SharedMethods.ChangeColor(ConsoleColor.Yellow, () =>
            {
                Console.WriteLine(_v_ + "Carregando os modelos da base de dados...");
                AllDbTables = AllDbTables ?? GetAllEntities();
            });

            if (AllDbTables.Count > 0)
                SharedMethods.ChangeColor(ConsoleColor.Green, () => Console.WriteLine(_v_ + "Modelos carregados!!"));
            else
                SharedMethods.ChangeColor(ConsoleColor.Red, () => Console.WriteLine(_v_ + "Erro no carregamento dos modelos!!"));

            jsonConfig = new JsonConfig(GraphQLConfigFiles.Config(solutionPath), false);

            // Função para pegar todos os GraphTypes criados
            List<string> Regenerate()
            {
                return Directory
                    .GetFiles(GraphQLConfigFiles.Type(solutionPath))
                    .Select(s => s.Split('\\').LastOrDefault().Replace("Type.cs", ""))
                    .ToList();
            }

            //Console.Clear();

            // Recuperando o valor digitado
            var name = "";
            // Lista auxiliar onde será adicionado as propriedades
            var objects = new List<Type>();
            // As opções que são definidas quando é escolhido a opção GraphQL
            var options = new Options();
            var rg = false;

            do
            {
                Console.WriteLine(_v_ + ", Alguns comandos: " +
                    "\n [-rg] significa 'regenerate', função que permite voltar a gerar todos os GraphTypes gerados." +
                    "\n [-rg-db] significa 'regenerate database' função que permite voltar a gerar GraphTypes com base as tabelas da base de dados." +
                    "\n [-q] significa 'quit', função que perminte sair." +
                    "\n * Se estiver que se usar a geração de objecto escrevenodo, pode se definir propriedades a não ser gerado," +
                    "\n para atingir esse efeito: NomeClasse:{Prop1 Prop2 Prop3 Prop4}.");
                Console.Write("\nDigite o nome da classe(s, separadas por ',') que está em Models (sem a extensão): ");
                name = Console.ReadLine();

                var secs = new List<string>();

                if (name == "-q")
                    return;
                else if (name == "-rg")
                {
                    rg = true;
                    secs = Regenerate();
                    Console.WriteLine("...Gerando Novamente todos os Tipo...");
                }
                else if (name == "-rg-db")
                {
                    rg = true;
                    secs = AllDbTables.Select(s => s.Name).ToList();
                    Console.WriteLine("...Gerando Novamente todos os Tipo...");
                }
                else
                    secs = name.Split(',').ToList();

                secs.ToList().ForEach(x =>
                {

                    // Dividindo os dados escritos
                    var splited = x.Split(":");
                    // Pegando o primeiro dado, que é nome da classe
                    var left = splited[0];

                    // Gerando o objecto
                    var obj = GetTypeByName(left.Trim());

                    // Adicionando os restrições
                    if (splited.Count() > 1)
                    {
                        // Tirando as chavetas
                        var list = splited[1].Replace("{", "").Replace("}", "").Trim().Split(" ").ToList();
                        // Adicionando nas restrições
                        jsonConfig.Add(left, list.Select(s => s.Trim()).ToList());
                    }

                    // Verificando se objecto é válido
                    if (obj != null)
                        // Adicionando nos objectos
                        objects.Add(obj);
                    else
                        SharedMethods.ChangeColor(ConsoleColor.Red, () =>
                        {
                            Console.WriteLine("Não econtrado: " + splited[0]);
                        });
                });

            } while (!objects.Any());

            // Verificando se deve ser parado
            if (name == "-q") return;

            if (rg == false)
            {
                Console.Write("\nDeseja gerar toda a hierarquia de objecos? (y/n): ");
                var _res_ = Console.ReadKey();

                if (_res_.KeyChar == 'n')
                {
                    Console.WriteLine("\nDigite 'y' para os objectos devem ser criados e 'n' para que não devem.");
                    foreach (var item in options.GetType().GetProperties())
                    {
                        Console.Write($"Deseja gerar {item.Name} ? (y/n): ");
                        item.SetValue(options, Console.ReadKey().KeyChar == 'n' ? false : true);
                        Console.WriteLine("");
                    }
                }
            }

            foreach (var item in objects)
            {
                if (options.Type)
                    AddModelType(item, objects, options);
            }

        }

        static void InitEFramework(string _v_)
        {
            var modelFolder = @$"{solutionPath}ISS.Application\Models\";

            SharedMethods.ChangeColor(ConsoleColor.Red, () =>
                Console.WriteLine("A classe DbContext não existe em Models do Projeto ISS.Application"));

            Console.Write("Deseja adicionar os data notation e reconfigurar modelos do Projeto ISS.Application (y/n)?: ");
            var rkey = Console.ReadKey();
            Console.WriteLine("");

            if (rkey.KeyChar != 'n')
            {
                // Carregando dados adicionando dados auxiliar de Historico Verificação de identidades
                var hvi_tmp = File.ReadAllText($@"{solutionPath}\CRUDMaker\CrudCreator\tmp\EF\hvi-extra.txt");
                // Carregando dados adicionando dados auxiliar de Histórico Loign
                var hl_tmp = File.ReadAllText($@"{solutionPath}\CRUDMaker\CrudCreator\tmp\EF\hlogin-extra.txt");
                // Template de usuario
                var pessoa_tmp = "\n\n        public virtual Usuario Usuario { get; set; }\n";

                var files = Directory.GetFiles(modelFolder).Select(s => new
                {
                    Name = s.Split("\\").LastOrDefault().Replace(".cs", ""),
                    Path = s,
                    Content = File.ReadAllLines(s)
                }).ToList();

                SharedMethods.ChangeColor(ConsoleColor.Yellow, () =>
                {
                    Console.WriteLine("Carregando os modelos da base de dados...");
                    AllDbTables = AllDbTables ?? GetAllEntities();
                });

                if (AllDbTables.Count > 0)
                    SharedMethods.ChangeColor(ConsoleColor.Green, () => Console.WriteLine("Modelos carregados!!"));
                else
                    SharedMethods.ChangeColor(ConsoleColor.Red, () => Console.WriteLine("Erro no carregamento dos modelos!!"));

                SharedMethods.ChangeColor(ConsoleColor.Green, () =>
                    Console.WriteLine("Adicionando o [Key]..."));

                foreach (var item in files)
                {

                    var model = AllDbTables.FirstOrDefault(x => x.Name == item.Name);

                    if (model == null)
                        continue;

                    string cnt = "";
                    foreach (var c in item.Content)
                    {
                        var ver = c.Contains($" {model.PrimaryKey} ");
                        if (cnt.Contains("[Key]") || c.Contains("[Key]"))
                            ver = false;

                        cnt += cnt.Length == 0 ? "" : "\n";

                        var splited = c.Trim().Split(" ");
                        var propName = splited.Length > 3 ? splited[2] : null;

                        if (ver)
                            cnt += c.Replace("public", "[Key] public");
                        else if (propName != null && c.Trim().StartsWith("public") && model.TableInfos.Any(x => x.COLUMN_NAME == propName && x.IS_IDENTITY == 1))
                            cnt += c.Replace("public", "[Attributes.IsIdentity] public");
                        else
                            cnt += c;

                        switch (item.Name)
                        {
                            case "Pessoa":
                                if (c.Trim().StartsWith("public virtual "))
                                {
                                    if (item.Content.Contains(pessoa_tmp.Trim())) break;

                                    cnt += pessoa_tmp;
                                    pessoa_tmp = "";
                                }
                                break;
                            case "HistoricoVerificacaoIdentidade":
                                if (c.Trim().StartsWith("public string UsuarioId "))
                                {
                                    if (item.Content.Contains(hvi_tmp.Trim())) break;

                                    cnt += hvi_tmp;
                                    hvi_tmp = "";
                                }
                                break;
                            case "HistoricoLogin":
                                if (c.Trim().StartsWith("public string UsuarioId "))
                                {
                                    if (item.Content.Contains(hl_tmp.Trim())) break;

                                    cnt += hl_tmp;
                                    hl_tmp = "";
                                }
                                break;
                        }

                    }

                    try
                    {
                        SharedMethods.ChangeColor(ConsoleColor.Green, () =>
                            Console.WriteLine("Salvando " + item.Name));

                        File.WriteAllText(item.Path, cnt);
                    }
                    catch (Exception ex)
                    {
                        SharedMethods.ChangeColor(ConsoleColor.Red,
                            () => Console.WriteLine("Erro tentando salvar. " + ex.Message + " . " + ex.InnerException?.Message));
                    }

                }

            }

        }

        // Função para Gerar o GraphType
        static string AddModelType(Type model, List<Type> objects, Options options = null, bool set = true)
        {

            // Defining the constraints
            var consts = new Dictionary<string, string>() {

                { "String", "StringGraph" }
                ,{ "Int", "IntGraph" }
                ,{ "Int16", "IntGraph" }
                ,{ "Int32", "IntGraph" }
                ,{ "Int64", "IntGraph" }
                ,{ "Float", "FloatGraph" }
                ,{ "Double", "FloatGraph" }
                ,{ "Boolean", "BooleanGraph" }
                ,{ "DateTime", "DateTimeGraph" }
            };

            // Chaves dos templates
            var key = "/*@Field@*/";
            var keyIn = "/*@FieldInput@*/";

            var instance = Activator.CreateInstance(model);
            var modelPk = GetPK(model.Name) ?? instance.GetPrimaryKey();
            // Carregando o template
            var tmp = File.ReadAllText(GraphQLConfigFiles.GraphQLTmp(solutionPath, "obj-g-type.txt"));

            // Carregando os campos
            var field = File.ReadAllText(GraphQLConfigFiles.GraphQLTmp(solutionPath, "obj-g-type-field.txt"));
            var fieldGen = File.ReadAllText(GraphQLConfigFiles.GraphQLTmp(solutionPath, "obj-g-type-field-gen-prim.txt"));
            var fieldIn = File.ReadAllText(GraphQLConfigFiles.GraphQLTmp(solutionPath, "obj-g-type-fieldInput.txt"));

            var fieldGenOne = File.ReadAllText(GraphQLConfigFiles.GraphQLTmp(solutionPath, "obj-g-type-field-gen.txt"));
            var fieldGenList = File.ReadAllText(GraphQLConfigFiles.GraphQLTmp(solutionPath, "obj-g-type-field-gen-list.txt"));

            // Pegando todos os tipos
            var types = Directory.GetFiles(GraphQLConfigFiles.Type(solutionPath)).ToList();

            string ToGraphType(string type)
            {
                // Definindo algumas restrições
                var res = consts.FirstOrDefault(x => x.Key == type);
                return res.Key != null ? res.Value : type;
            }

            // Configurando certas secções do template

            if (!constrainstGeracaoPessoas.Any(x =>
                 {
                     var @bool = x.Item1 == model.Name;

                     if (@bool)
                     {
                         tmp = tmp.Replace("@extends", $": {x.Item2}Type");//.Replace("@base", ": base(provider)");
                         tmp = tmp.Replace("@extendInput", $": {x.Item2}InputType");
                     }

                     return @bool;
                 }))
                tmp = tmp.Replace("@extends", ": ObjectGraphType<@-Model-@>").Replace("@base", "").Replace("@extendInput", ": InputObjectGraphType");

            // Substituindo as chaves básicas
            tmp = tmp.Replace("@-Model-@", model.Name);
            tmp = tmp.Replace("@-Var-@", model.Name.ToLowerFirstChar());

            // End Configurando certas secções do template

            // Percorrendo todas as propriedades do modelo
            foreach (var item in model.GetProperties())
            {

                if (jsonConfig.CheckValue(model.Name, item.Name))
                    continue;

                // Pegando o nome
                var type = item.PropertyType.Name;
                var objType = item.PropertyType;
                // Verficando se um argumento na propriedade
                if (item.PropertyType.GenericTypeArguments.Count() > 0)
                {
                    // Modificando o nome do tipo
                    type = item.PropertyType.GenericTypeArguments[0].Name;
                    objType = item.PropertyType.GenericTypeArguments[0];
                }

                // Var auxiliar para possibilitar comentar uma linha
                var comment = false;

                // Copiando o valor do tipo para ele nºao seja alterado
                string _type_ = ToGraphType(type);

                string extra = "";

                string idade = "Field<IntGraphType>(\"idade\", resolve: c => c.Source.DataNascimento != null ? new System.DateTime(System.DateTime.Now.Subtract((System.DateTime)c.Source.DataNascimento).Ticks).Year : 0);\n            ";

                // Verificando se o tipo não inicia com String para poder definir o template apropriado
                if (!type.Equals("String"))
                {

                    var list_field = false;
                    // Copiando o valor do field para ele nºao seja alterado
                    string _field_ = string.Copy(fieldGen);
                    // Var auxiliar para a string extra


                    string _fieldO_ = string.Copy(fieldGenOne);
                    string _fieldL_ = string.Copy(fieldGenList);


                    // Valor booleano para poder fazer a verificação do comentario
                    comment = !_type_.EndsWith("Graph");

                    // Verificando se existe já existe um ficheiro criado
                    var anyCreated = types.Any(x => x.EndsWith($@"\{_type_}Type.cs"));
                    comment = anyCreated ? false : comment;

                    // Verificando se o usuario escreveu o nome da tabela
                    var anyWrote = objects.Any(x => x.Name == _type_);
                    comment = anyWrote ? false : comment;

                    if (item.PropertyType.Name.Contains("ICollection"))
                    {
                        extra = $"<{type}Type>";
                        _type_ = "ListGraph";
                        list_field = true;
                    }

                    if (options != null)
                    {
                        // A possibilidade de gerar os objectos do filho do objecto principal
                        if (consts.FirstOrDefault(x => x.Key == type).Key == null && options.GenerateWithInChildren)
                        {
                            // Descomentado a linha
                            comment = options.GenerateWithInChildren ? false : comment;
                            // Gerando os objectos
                            AddModelType(objType, new List<Type>());
                        }
                    }

                    // Comentando a linha
                    if (comment)
                    {
                        // Comentando a linha
                        _field_ = "//" + _field_;
                        _fieldL_ = "//" + _fieldL_;
                        _fieldO_ = "//" + _fieldO_;

                    }

                    if (_type_.EndsWith("Graph") && consts.FirstOrDefault(x => x.Key == type).Key != null)
                    {

                        var txt = _field_.Replace("@-Model-@", item.Name)
                                                .Replace("@-Type-@", _type_)
                                                .Replace("@-Extra-@", extra);

                        if (model.Name == nameof(Pessoa) && item.Name == nameof(Pessoa.DataNascimento))
                        {
                            txt = idade + txt;
                            idade = "";
                        }

                        // Definindo e adicionando os dados no template
                        tmp = tmp.Replace(key, txt);

                    }
                    else if (!list_field)
                    {

                        var attr = item.GetAttr("ForeignKeyAttribute");

                        attr = attr != item.Name ? attr : modelPk;

                        tmp = tmp.Replace(key, _fieldO_
                                                .Replace("@-Model-@", _type_)
                                                .Replace("@-Var-@", item.Name.ToLowerFirstChar())
                                                .Replace("@-Var-U-@", attr));
                    }
                    else
                    {
                        tmp = tmp.Replace(key, _fieldL_
                                                .Replace("@-Model-@", type)
                                                .Replace("@-Var-@", item.Name.ToLowerFirstChar())
                                                .Replace("@-Key-@", modelPk));
                    }

                }
                else
                {
                    // Definindo e adicionando os dados no template
                    tmp = tmp.Replace(key, field.Replace("@-Model-@", item.Name));
                }

                string _fieldIn_ = string.Copy(fieldIn);

                if (comment || modelPk == item.Name)
                    _fieldIn_ = "//" + _fieldIn_;

                if (consts.FirstOrDefault(x => x.Key == type).Key == null)
                    if (_type_ != "ListGraph")
                        _type_ += "Input";
                    else
                        extra = extra.Replace("Type>", "InputType>");

                // Definindo e adicionando os dados no template
                tmp = tmp.Replace(keyIn, _fieldIn_
                                            .Replace("@-Type-@", _type_)
                                            .Replace("@-Extra-@", extra)
                                            .Replace("@-Var-@", item.Name.ToLowerFirstChar()));
            }

            SharedMethods.ChangeColor(ConsoleColor.Green, () =>
            {
                Console.WriteLine("Verificar em: " + GraphQLConfigFiles.Type("", $"{model.Name}Type.cs"));
            });

            // Verificando se o Objecto pode ser gerado
            if (set) File.WriteAllText(GraphQLConfigFiles.Type(solutionPath, $"{model.Name}Type.cs"), tmp.Replace(key, "").Replace(keyIn, ""));
            else Console.WriteLine($" Type: \n{tmp}");

            Task.Delay(100);

            return tmp;
        }

        #endregion
    }

    #region Classes

    public struct GraphQLConfigFiles
    {
        public static string Type(string r, string f = "") => r + @"ISS.GraphQL\Type\" + f;
        public static string GraphQLTmp(string r, string f) => r + @"CRUDMaker\CrudCreator\tmp\GraphQL\" + f;
        public static string Config(string r) => r + @"CRUDMaker\CrudCreator\tmp\GraphQL\graph_contraints.json";
    }

    public class Options
    {
        public bool Type { get; set; } = true;
        public bool GenerateWithInChildren { get; set; } = false;
    }

    public class JsonConfig
    {
        protected string path = null;
        protected string json = null;
        protected bool reload = true;

        // Construtor padrão
        public JsonConfig(string p, bool r = true)
        {
            path = p;
            reload = r;
        }

        // Checador de ficheiro
        protected bool CheckFile()
        {
            // Verificando o ficheiro foi encontrado
            if (reload)
                return true;

            if (path == null)
            {
                Debugger.Log(0, "[Json Config Error]:", "The path cannot be null.");
                return false;
            }
            if (!File.Exists(path))
            {
                Debugger.Log(0, "[Json Config Error]:", $"Could not open the file. Path: {path}");
                return false;
            }

            // Opening the file
            json = File.ReadAllText(path);

            return true;
        }

        public void Add(string key, object value)
        {
            if (!CheckFile()) return;

            if (string.IsNullOrEmpty(json)) json = "{}";

            // Deserializing to an dynamic object
            var obj = JsonConvert.DeserializeObject<dynamic>(json);

            // Setting the prop
            obj[key] = JsonConvert.SerializeObject(value);
            // Serializing to an string object
            json = JsonConvert.SerializeObject(obj);

            // Writting the file
            File.WriteAllText(path, json);
        }

        public string[] Get(string key)
        {
            if (!CheckFile()) return null;

            // Deserializing to an dynamic object
            var obj = JsonConvert.DeserializeObject<dynamic>(json);

            var res = obj[key];

            if (res == null) return null;

            return JsonConvert.DeserializeObject<string[]>(res.ToString());
        }

        public object Get()
        {
            if (!CheckFile()) return null;

            if (json == null) return null;

            // Deserializing to an dynamic object
            var obj = JsonConvert.DeserializeObject<dynamic>(json);
            return obj;
        }

        public bool CheckValue(string key, string value)
        {
            if (!CheckFile()) return false;

            var val = this.Get(key);

            if (val == null) return false;

            return val.Any(x => x == value);
        }

    }

    public class DbTable
    {
        public string Name { get; set; }
        public string PrimaryKey { get; set; }
        public List<DbScaffold.TableColumn> TableInfos { get; set; } = new List<DbScaffold.TableColumn>();
    }

    public class DbScaffold
    {
        // Função para pegar todas tabelas e contruir os dados
        #region Inner Classes and Enums

        public class TableColumn
        {
            public string TABLE_NAME { get; set; }
            public string COLUMN_NAME { get; set; }
            public int IS_IDENTITY { get; set; }
        }
        #endregion
    }

    public class SharedMethods
    {
        public static readonly string GlobalRootPath = BackFolder(AppDomain.CurrentDomain.BaseDirectory, 5) + "\\"; // internacionalSeguros/...

        static string BackFolder(string path, int n)
        {
            for (int i = 0; i < n; i++)
                path = Directory.GetParent(path).FullName;

            return path;
        }

        public static void ChangeColor(ConsoleColor color, Action action)
        {
            Console.ForegroundColor = color;
            action.Invoke();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string ToPascalCase(string str)
        {
            string text = "";
            bool upper = false;
            bool forceUpper = false;

            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];
                var isNumber = ((int)c >= 48 && (int)c <= 57);
                var ch = str[i].ToString();
                var chUpper = ch.ToUpper();

                if (i == 0)
                {
                    upper = false;
                    forceUpper = true;
                }

                if (ch == "_")
                {
                    forceUpper = true;
                    continue;
                }

                if (ch == chUpper && !upper || forceUpper)
                {
                    upper = true;
                    forceUpper = false;
                    text += chUpper;
                }
                else if (ch == chUpper && upper)
                {
                    text += ch.ToLower();
                }
                else
                {
                    upper = false;
                    text += ch;
                }

                if (isNumber) forceUpper = true;

            }

            return text;
        }
    }

    #endregion
}