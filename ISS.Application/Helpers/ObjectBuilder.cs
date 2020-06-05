using System;
using System.Collections.Generic;
using System.Linq;

namespace ISS.Application.Helpers
{
    public static class ObjectBuilder
    {
        public static T Build<T>(this T type, List<string> created = null)
        {

            if (created == null)
                created = new List<string>();

            var prop = type.GetType(); // Pegando o typo do objecto
            var list = prop.GetProperties(); // Pegando suas propriedades

            // Verificando se instanciado para não gerar loop infinito
            if (created.Any(x => x == prop.Name))
                return type;

            // Percorrendo suas propriedades
            foreach (var elem in list)
            {
                // Verificando se a propriedade não é propriedade do sistema
                if (elem.PropertyType.Namespace != "System" && elem.GetValue(type) == null)
                {
                    object obj = null;
                    // Verificando se é uma lista
                    if (elem.PropertyType.Namespace == "System.Collections.Generic")
                    {
                        // Pegando o argumento da lista
                        var parameter = elem.PropertyType.GetGenericArguments()[0];

                        if (parameter == null) continue;

                        created.Add(parameter.Name); // Adicionando na lista dos objectos instanciados
                        // Construindo o objecto do argumento
                        var objTemp = Build(Activator.CreateInstance(parameter), created);

                        var genList = typeof(List<>).MakeGenericType(parameter); // Criando uma lista generica
                        obj = Activator.CreateInstance(genList); // Criando uma instancia da lista

                        obj.GetType().GetMethod("Add")
                           .Invoke(obj, new[] {
                               objTemp
                           }); // Adicionando o objecto na lista
                    }
                    else
                    {
                        created.Add(elem.PropertyType.Name);// Adicionando na lista dos objectos instanciados
                        obj = Activator.CreateInstance(Type.GetType(elem.PropertyType.FullName)); //Criando uma instancia da propriendade
                        Build(obj, created); // Construindo o objecto
                    }

                    elem.SetValue(type, obj); // Configurando a propriedade
                }
            }
            return type;
        }
    }

}
