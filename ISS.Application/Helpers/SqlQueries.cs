using System;
using System.Collections;
using System.Linq;

namespace ISS.Application.Helpers
{
    public static class SqlQueries
    {
        /// <summary>
        /// Funcão para construir uma query de selecao
        /// </summary>
        /// <param name="t">O nome da tabela</param>
        /// <returns></returns>
        public static string Select(string t) => $"SELECT * FROM [{t}]";

        /// <summary>
        /// Funcão para construir uma query de selecao de um dado
        /// </summary>
        /// <param name="t">O nome da tabela</param>
        /// <param name="p">A propriedade a ser filtrada</param>
        /// <param name="v">O valor da propriedade a ser filtrada</param>
        /// <returns></returns>
        public static string Select(string t, string p, string v) => $"SELECT * FROM [{t}] WHERE {p} = '{v}'";

        /// <summary>
        /// Funcão para construir uma query de selecao de um dado
        /// </summary>
        /// <param name="t">O nome da tabela</param>
        /// <param name="p">A propriedade a ser filtrada</param>
        /// <param name="v">O valor da propriedade a ser filtrada</param>
        /// <returns></returns>
        public static string SelectWhere(string t, string exp) => $"SELECT * FROM [{t}] {exp}";

        /// <summary>
        /// Funcão para construir uma query de inserção de um dado
        /// </summary>
        /// <typeparam name="T">o tipo do objecto que será gerada a query</typeparam>
        /// <param name="model">O objecto que precisa ser gerada a query</param>
        /// <returns></returns>
        public static string Insert<T>(T model, string id = null) where T : class
        {
            string extra = "";
            string extraInverted = "";
            string props = "";
            string values = "";
            var type = model.GetType();
            string key = model.GetPrimaryKey();
            string keyValue = Guid.NewGuid().ToString();
            string upTablekeyValue = id;

            // Setting the id
            var id_prop = type.GetProperty(key);


            var _value_ = id_prop.GetValue(model);

            if (_value_ != null)
            {
                keyValue = _value_.ToString();
            }

            id_prop.SetValue(model, keyValue);

            void MapKeys(object obj, string newId)
            {

                foreach (var item in obj.GetType().GetProperties())
                {
                    var value = item.GetValue(obj);

                    if (value == null) continue;

                    if (item.GetMethod.IsVirtual)
                    {

                        if (value is IList)
                        {
                            // Percorrendo a list de valores
                            foreach (var innerItem in (value as IList))
                            {
                                var inverse = item.GetAttr("InverseProperty");
                                var deliveredKey = innerItem.GetType().GetProperty(inverse).GetAttr("ForeignKey");
                                if (deliveredKey != null)
                                    innerItem.GetType().GetProperty(deliveredKey).SetValue(innerItem, newId);
                            }
                        }
                        // Senão...
                        else
                        {
                            // Vericando se o valor não tem a namespace que começa com Sys.Coll
                            if (!value.GetType().FullName.StartsWith("System.Collections"))
                            {
                                var foreignKey = item.GetAttr("ForeignKey");
                                // No caso de relacionamento 1 para N, em que a chave da outra tabela vem para a tabela principal.
                                if (foreignKey != null)
                                {
                                    var propertyType = value.GetType();
                                    var propertyId = value.GetPropertyValue(obj.GetPrimaryKey()) as string;
                                    string foreignPropertyId = propertyId ?? Guid.NewGuid().ToString();

                                    if (propertyId == null)
                                        propertyType.GetProperty(value.GetPrimaryKey()).SetValue(value, foreignPropertyId);

                                    // Configurando o valor do objecto principal
                                    obj.GetType().GetProperty(foreignKey).SetValue(obj, foreignPropertyId);

                                    MapKeys(value, foreignPropertyId);
                                }
                                // No caso de relacionamento 1 para 1, em que a chave da tabela principal vai na outra tabela.
                                else
                                {
                                    var propertyType = value.GetType();
                                    var linkedProperty = propertyType.GetProperties().FirstOrDefault(x => x.GetAttr("InverseProperty") == item.Name);
                                    var deliveredKey = linkedProperty?.GetAttr("ForeignKey");
                                    if (linkedProperty != null && deliveredKey != null)
                                        value.GetType().GetProperty(deliveredKey).SetValue(value, newId);
                                }

                            }
                        }
                    }
                }
            }

            if (_value_ == null)
                MapKeys(model, keyValue);

            foreach (var item in type.GetProperties())
            {

                if (item.HasAttr("IsIdentity"))
                    continue;

                // Pegando o valor da propriedade
                var value = item.GetValue(model);

                // Verificando se é validio
                if (value == null || (value as DateTime?) == (new DateTime()))
                    // Pulando para o proximo registro
                    continue;

                if (!item.GetMethod.IsVirtual)
                {
                    // Definindo a virgula ou não
                    string coma = !string.IsNullOrEmpty(props) ? ", " : "";
                    // Criando a propriedade
                    props += $"{coma}[{item.Name}]";

                    var v = value.ToString().ToLower();
                    if (v == "true")
                        value = 1;
                    else if (v == "false")
                        value = 0;

                    // Criando o seu valor
                    values += $"{coma}'{value}'";
                }
                else
                {

                    // Verificando se o valor é uma lista
                    if (value is IList)
                    {
                        // Percorrendo a list de valores
                        foreach (var lItem in (value as IList))
                            // Construindo a query interna
                            extra += "; " + Insert(lItem);
                    }
                    // Senão...
                    else
                    {
                        // Vericando se o valor não tem a namespace que começa com Sys.Coll
                        if (!value.GetType().FullName.StartsWith("System.Collections"))
                        {

                            var foreignKey = item.GetAttr("ForeignKey");
                            if (foreignKey == null)
                                // Construindo a query interna
                                extra += "; " + Insert(value);
                            else
                            {
                                var columnId = Guid.NewGuid().ToString();
                                model.GetType().GetProperty(foreignKey)?.SetValue(model, columnId);
                                // Função para construir a query da propriedade
                                extraInverted += Insert(value) + "; ";
                            }
                        }
                    }
                }
            }
            // Retornando tada query construida
            return $"{extraInverted} INSERT INTO [{type.Name}] ({props}) VALUES ({values}) {extra}";
        }

        /// <summary>
        /// Funcão para construir uma query de actualização de um dado
        /// </summary>
        /// <typeparam name="T">O tipo do objecto que será gerada a query</typeparam>
        /// <param name="model">O objecto que precisa ser gerada a query</param>
        /// <param name="id">O valor do campo</param>
        /// <param name="field">O campo</param>
        /// <returns></returns>
        public static string Update<T>(T model, string id, string field = null) where T : class
        {
            string values = "";
            string setters = "";
            var type = model.GetType();
            string key = model.GetPrimaryKey();
            string identity = model.GetIdentityKey();

            foreach (var item in type.GetProperties())
            {
                // Verificando se é uma propriedade virtual
                // Pulando para a proxima propriedade se for verdade
                if (item.GetMethod.IsVirtual) continue;

                // Verificando se a propriedade é a chave primária
                // Pulando para a proxima propriedade se for verdade
                if (item.Name == key || item.Name == identity) continue;

                // Pegando o valor da propriedade
                var value = item.GetValue(model);

                // Verificando se é validio
                // Pulando para o proximo registro se for verdade
                if (value == null) continue;

                // Definindo a virgula ou não
                string coma = !string.IsNullOrEmpty(setters) ? ", " : "";

                // Criando a propriedade
                setters += $"{coma}{item.Name} = '{value}'";

                // Criando o seu valor
                values += $"{coma}{value}";
            }

            // Verificando se o field foi definido
            // Definindo o field para a chave primaria do objecto
            if (field == null) field = key;

            return $"UPDATE [dbo].[{type.Name}] SET {setters} WHERE [{field}] = '{id}'";
        }

        /// <summary>
        /// Funcão para construir uma query de remoção de um dado
        /// </summary>
        /// <typeparam name="T">O tipo do objecto que será gerada a query</typeparam>
        /// <param name="model">O objecto que precisa ser gerada a query</param>
        /// <param name="id">O valor do campo</param>
        /// <param name="field">O campo</param>
        /// <returns></returns>
        public static string Remove<T>(T model, string id, string field = null) where T : class
        {
            var type = model.GetType();

            // Verificando se o field foi definido
            if (field == null)
                // Definindo o field para a chave primaria do objecto
                field = model.GetPrimaryKey();

            return $"DELETE FROM [{type.Name}] WHERE [{field}] = '{id}'";
        }

    }
}
