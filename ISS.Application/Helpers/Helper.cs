using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ISS.Application.Helpers
{
    public static class Helper
    {

        public static void For<T>(this IEnumerable<T> t, Action<T> action) where T : class
        {
            if (t == null)
                return;
            // Percorrendo a lista dos elementos
            foreach (var e in t)
                // Invocando a função passada como argumento
                action.Invoke(e);
        }

        public static bool AnyOne<T>(this IEnumerable<T> t, Func<T, bool> action) where T : class
        {
            // Percorrendo a lista dos elementos
            foreach (var e in t)
            {
                // Invocando a função passada como argumento
                var r = action.Invoke(e);
                if (r == true)
                    return r;
            }
            return false;
        }

        /// <summary>
        /// Extenão auxiliar para pegar a chave primaria de um objecto
        /// </summary>
        /// <typeparam name="T">O objecto que deve ser mandado</typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string GetPrimaryKey<T>(this T model) where T : class
        {
            // Definindo um valor qualquer
            var id = "Id";
            var type = model.GetType();

            var prop = type.GetProperties().FirstOrDefault(x => x.HasAttr("Key"));

            if (prop != null)
                return prop.Name;

            // Percorrendo as propriedades do objecto
            foreach (var p in type.GetProperties())
                // Verificano se ela comeca com Id...
                if (p.Name.StartsWith("Id"))
                {
                    // Setando o dado do Id
                    id = p.Name;
                    // Quebrando o fluxo
                    break;
                }

            return id;
        }

        public static string GetIdentityKey<T>(this T model) where T : class
        {
            // Definindo um valor qualquer
            var id = "NumOrdem";
            var type = model.GetType();

            var prop = type.GetProperties().FirstOrDefault(x => x.HasAttr("IsIdentity"));

            if (prop != null)
                return prop.Name;

            // Percorrendo as propriedades do objecto
            foreach (var p in type.GetProperties())
                // Verificano se ela comeca com Id...
                if (p.Name.StartsWith(id))
                {
                    // Setando o dado do Id
                    id = p.Name;
                    // Quebrando o fluxo
                    break;
                }

            return id;
        }

        public static bool HasAttr(this PropertyInfo item, string attrName)
        {
            if (!attrName.EndsWith("Attribute"))
                attrName += "Attribute";

            return item.CustomAttributes.Any(x => x.AttributeType.Name.Equals(attrName));
        }

        public static string GetAttr(this PropertyInfo item, string attrName)
        {
            if (!attrName.EndsWith("Attribute"))
                attrName += "Attribute";

            var attr = item.Name;
            var _attr_ = item.CustomAttributes.FirstOrDefault(x => x.AttributeType.Name.Equals(attrName));

            if (_attr_ != null)
                attr = _attr_.ConstructorArguments.FirstOrDefault().Value.ToString();

            return attr;
        }

        /// <summary>
        /// Função auxilar para se um determinado valor encontra-se em uma objecto
        /// </summary>
        /// <typeparam name="T">A classe</typeparam>
        /// <param name="model">O modelo que deve ser verificado</param>
        /// <param name="value">O valor que deve ser verificado</param>
        /// <returns></returns>
        public static bool HasValue<T>(this T model, string value) where T : class
        {
            if (model == null || value == null)
                return false;

            // Definindo o estado do retorno padrão
            var result = false;
            // Pegando o tipo
            var _type_ = model.GetType();

            // Percorrendo as propriedades do modelo
            foreach (var p in _type_.GetProperties())
            {
                var v = p?.GetValue(model)?.ToString();
                // Verificando se o valor é igual ao esperado
                if (v == value)
                {
                    // Modificando a variavel de retorno
                    result = true;
                    // Quebrando o ciclo
                    break;
                }
            }

            // Retornado o valor avalido
            return result;
        }

        /// <summary>
        /// Função auxilar para se um determinado valor encontra-se em uma objecto
        /// </summary>
        /// <typeparam name="T">A classe</typeparam>
        /// <param name="model">O modelo que deve ser verificado</param>
        /// <param name="value">O valor que deve ser verificado</param>
        /// <param name="consts">Propriedades especificas que se deseja pesquisar</param>
        /// <returns></returns>
        public static bool HasValue<T>(this T model, string value, string consts) where T : class
        {
            if (model == null || value == null)
                return false;

            // Verificando se foi mandado alguma constante
            if (consts == null)
                // Chamando HasValue sem constante
                return HasValue(model, value);

            // Definindo o estado do retorno padrão
            var result = false;
            // Pegando o tipo
            var _type_ = model.GetType();
            // Verificando se foi mandado alguma restricão
            // Percorrendo as restrições
            foreach (var _prop_ in consts.Split(','))
            {
                // Pegando a propriedade na string
                var _p_ = _prop_.Trim();
                // Verificando se o valor é válido
                if (string.IsNullOrEmpty(_p_))
                    // Pulando o ciclo
                    continue;

                // Pegando a propriedade
                var prop = _type_.GetProperty(_p_);
                // Verificando se ela existe
                var v = prop?.GetValue(model)?.ToString();
                //Verificando se o valor da propriedade é igual ao valor que foi mandado
                if (v == value)
                {
                    // Modificando a variavel de retorno
                    result = true;
                    // Quebrando do ciclo
                    break;
                }
            }
            // Retornado o valor avalido
            return result;
        }

        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> collection, string propName, bool asc) where T : class
        {
            if (string.IsNullOrEmpty(propName))
                propName = $"Cod{typeof(T).Name}";

            return asc ? collection.OrderBy(f => f.GetPropertyValue(propName)) : collection.OrderByDescending(f => f.GetPropertyValue(propName));
        }

        /// <summary>
        /// Função auxilar para se um determinado valor encontra-se em uma objecto
        /// </summary>
        /// <typeparam name="T">A classe</typeparam>
        /// <param name="model">O modelo que deve ser verificado</param>
        /// <param name="value">O valor que deve ser verificado</param>
        /// <returns></returns>
        public static bool ContainValue<T>(this T model, string value) where T : class
        {
            if (model == null || value == null)
                return false;

            value = value.ToLower();

            // Definindo o estado do retorno padrão
            var result = false;
            // Pegando o tipo
            var _type_ = model.GetType();

            // Percorrendo as propriedades do modelo
            foreach (var p in _type_.GetProperties())
            {
                var v = p?.GetValue(model)?.ToString();
                // Checking value
                var res = v?.ToLower().Contains(value);

                // Checking if is valid
                if (res == null)
                    continue;

                // Checking result
                if ((bool)res)
                {
                    // Modificando a variavel de retorno
                    result = true;
                    // Quebrando do ciclo
                    break;
                }
            }

            // Retornado o valor avalido
            return result;
        }

        /// <summary>
        /// Função auxilar para se um determinado valor encontra-se em uma objecto
        /// </summary>
        /// <typeparam name="T">A classe</typeparam>
        /// <param name="model">O modelo que deve ser verificado</param>
        /// <param name="value">O valor que deve ser verificado</param>
        /// <param name="consts">Propriedades especificas que se deseja pesquisar</param>
        /// <returns></returns>
        public static bool ContainValue<T>(this T model, string value, string consts) where T : class
        {
            // Falso caso model ou value for null
            if (model == null || value == null)
                return false;

            value = value.ToLower();

            // Verificando se foi mandado alguma constante
            if (consts == null)
                // Chamando HasValue sem constante
                return ContainValue(model, value);

            // Definindo o estado do retorno padrão
            var result = false;
            // Pegando o tipo
            var _type_ = model.GetType();
            // Verificando se foi mandado alguma restricão
            // Percorrendo as restrições
            foreach (var _prop_ in consts.Split(','))
            {
                // Pegando a propriedade na string
                var _p_ = _prop_.Trim();
                // Verificando se o valor é válido
                if (string.IsNullOrEmpty(_p_))
                    // Pulando o ciclo
                    continue;

                // Pegando a propriedade
                var prop = _type_.GetProperty(_p_);

                // Verificando se a propriedade foi encontrada
                if (prop == null)
                    // Pulando o ciclo
                    continue;

                // Verificando se ela existe
                var v = prop.GetValue(model)?.ToString();
                //Verificando se o valor da propriedade é igual ao valor que foi mandado

                // Checking value
                var res = v?.ToLower().Contains(value);

                // Checking if is valid
                if (res == null)
                    continue;

                // Checking result
                if ((bool)res)
                {
                    // Modificando a variavel de retorno
                    result = true;
                    // Quebrando do ciclo
                    break;
                }
            }
            // Retornado o valor avalido
            return result;
        }


        /// <summary>
        /// Função auxilar para um determinado valor encontra-se em uma objecto
        /// </summary>
        /// <typeparam name="T">A classe</typeparam>
        /// <param name="model">O modelo que deve ser verificado</param>
        /// <param name="value">O valor que deve ser verificado</param>
        /// <returns></returns>
        public static T UpdateFrom<T>(this T dst, T src)
            where T : class
        {
            // Getting the primary key
            var key = dst.GetPrimaryKey();

            // Getting the obj type
            var typeDst = dst.GetType();
            // Getting the obj type
            var typeSrc = src.GetType();

            // Getting the props of the type
            var propsDst = typeDst.GetProperties();
            // Getting the props of the type
            var propsSrc = typeSrc.GetProperties();

            // Looping the props
            for (int i = 0; i < propsDst.Length; i++)
            {
                // Getting the prop
                var pd = propsDst[i];
                // Getting the prop
                var ps = propsSrc[i];

                // Getting the value of the destination object
                var pd_v = pd.GetValue(dst);
                // Getting the value of the source object
                var ps_v = ps.GetValue(src);

                // Verifying if the source isn't null and is diferent of the of the destination
                if (ps_v != null && pd_v != ps_v && pd.Name != key)
                    // Updating the value
                    pd.SetValue(dst, ps_v);
            }

            return dst;
        }

        /// <summary>
        /// Funcão auxiliar para elminar a auto referencia
        /// </summary>
        /// <typeparam name="T">O tipo do modelo</typeparam>
        /// <param name="model">O modelo em si</param>
        /// <param name="parent">O Nome do modelo a ser eliminado</param>
        /// <returns></returns>
        public static T Clearify<T>(this T model, string parent = "") where T : new()
        {
            var type = model.GetType();

            if (type.IsGenericType && model is IEnumerable || type.IsArray)
            {
                foreach (var item in model as IList)
                    Clearify(item, parent);
            }
            else
            {
                var props = type.GetProperties();
                foreach (var p in props)
                {
                    var _arg_ = p.PropertyType.GenericTypeArguments;
                    var val = p.GetValue(model);

                    if (p.Name == parent)
                        p.SetValue(model, null);
                    else if ((_arg_.Length > 0 && !_arg_[0].Namespace.Equals("System")) && val != null)
                    {

                        var pr = val.GetType().GetProperty("Count");

                        if (pr == null)
                            Clearify(val, p.ReflectedType.Name);

                    }
                    else if (!p.PropertyType.Namespace.Equals("System") && val != null)
                        Clearify(val, p.ReflectedType.Name);
                }
            }

            return model;


        }

        public static string ToLowerFirstChar(this string str)
        {
            var result = str[0].ToString().ToLower();
            for (int i = 1; i < str.Length; i++)
            {
                var c = str[i];
                result += c;
            }
            return result;
        }

    }
}
