using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace ISS.Application.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Helper to exclude value into a list
        /// </summary>
        /// <typeparam name="T">The type of the list</typeparam>
        /// <param name="list">The referenced list it self</param>
        /// <param name="func">Function to select the field to exclude</param>
        /// <returns>The list return without the removed items</returns>
        public static IEnumerable<T> Exclude<T, TChild>(this IEnumerable<T> list, Expression<Func<T, TChild>> func)
        {
            // Trying to exclude
            try
            {
                // Looping the values
                foreach (var item in list)
                    // Excluding the values
                    item.ExcludeValue((func.Body as MemberExpression).Member.Name);

            }
            // Handling error
            catch (Exception ex) { Debugger.Log(0, "Error excluding", $"{ex.Message}.\n Inner Exception: {ex.InnerException?.Message}."); }

            //Returning the list
            return list;
        }

        /// <summary>
        /// The Obj value setter
        /// </summary>
        /// <typeparam name="T"> the type of the obj </typeparam>
        /// <param name="obj"> the referenced obj it self, the one that it need to be set </param>
        /// <param name="prop"> the property that need to be set </param>
        /// <param name="value"> the value to set </param>
        public static T SetPropValue<T>(this T obj, string prop, string value)
        {
            try
            {
                //Getting the all the properties
                var _info = typeof(T).GetProperties();
                //Filtering only the property that must to be set
                var p = _info.FirstOrDefault(x => x.Name.Equals(prop));

                if (p != null)
                    //Setting the value
                    p.SetValue(obj, value, null);
            }
            catch (Exception ex)
            { Debugger.Log(0, "Error: ", $"{ex.Message}.\n Inner Exception: {ex.InnerException?.Message}."); }

            return obj;
        }

        static T ExcludeValue<T>(this T obj, string prop) => obj.SetPropValue(prop, null);

    }
}
