using System;
using ISS.Application.Helpers;
using System.Linq;

namespace CRUDMaker
{
    public static class Helper
    {
        public static string GetReference(this Type obj, string prop, object @base)
        {
            // Pegando o tipo do objecto
            var inner = obj;
            var baseType = @base.GetType();
            // Pegando a respectiva propriedade inversa
            var itProp = inner.GetProperties()
                              .FirstOrDefault(
                                  x => x.GetAttr("InversePropertyAttribute") == prop &&
                                  x.GetMethod.IsVirtual &&
                                  x.PropertyType.Name == baseType.Name);
            // Verificando se não foi encontrada
            if (itProp == null)
                // Retornando uma string vazia para que ela não danifique a query principal
                return "";

            // Pegando a chave estrangeira a ser configurada
            var reverseProp = itProp.GetAttr("ForeignKeyAttribute");

            //  Verificando se não está nula
            if (reverseProp == null)
                // Retornando uma string vazia para que ela não danifique a query principal
                return "";

            return reverseProp;
        }
    }
}
