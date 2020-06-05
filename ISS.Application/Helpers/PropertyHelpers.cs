using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ISS.Application.Helpers
{
    public static class PropertyHelpers
    {
        /// <summary>
        /// Buscar pelo nome de uma propriedade.
        /// </summary>
        /// <typeparam name="TType">O tipo de objecto onde será pego o nome da propriedade.</typeparam>
        /// <param name="expression">A expressão de seleção da propriedade.</param>
        /// <returns></returns>
        public static string GetPropertyName<TType>(this Expression<Func<TType, object>> expression)
            where TType : class
        {
            // Buscar pelo membro da expressão.
            var memberExp = expression.Body as MemberExpression;
            if (memberExp == null)
                return string.Empty;

            // Pegar informações sobre a propriedade.
            var propInfo = memberExp.Member as PropertyInfo;
            if (propInfo == null)
                return string.Empty;

            // Retornar o nome da propriedade.
            return propInfo.Name;
        }

        /// <summary>
        /// Buscar pelo valor de um propriedade.
        /// </summary>
        /// <typeparam name="TParent">O tipo do objecto onde será pego o valor da propriedade.</typeparam>
        /// <param name="instance">A instância do objecto onde será pego o valor da propriedade.</param>
        /// <param name="propName">O nome da propriedade.</param>
        /// <returns></returns>
        public static object GetPropertyValue<TParent>(this TParent instance, string propName)
            where TParent : class
        {
            // Pegar a propriedade.
            var prop = instance.GetType().GetProperty(propName);

            // Retornar o valor da propriedade, ou null.
            return prop == null ? null : prop.GetValue(instance);
        }
    }
}
