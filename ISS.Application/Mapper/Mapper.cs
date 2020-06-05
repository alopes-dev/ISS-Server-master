using System;
using System.Diagnostics;

namespace MapBuilder
{
    /// <summary>
    /// Map two objects passing the values of a source to a destination
    /// </summary>
    public interface IMapper
    {
        /// <summary>
        /// Copy an object to a new one
        /// </summary>
        /// <typeparam name="TSource">The source object type</typeparam>
        /// <param name="src">The source object</param>
        /// <param name="match">Force the mapping of the object (First parameter going to be passed the source object and the second the destination) </param>
        /// <returns>The destination object</returns>
        TSource Copy<TSource>(TSource src, Func<Mapper> match = null)
            where TSource : class;
    }

    /// <summary>
    /// Map two objects passing the values of a source to a destination
    /// </summary>
    public class Mapper : IMapper
    {
        public TSource Copy<TSource>(TSource src, Func<Mapper> match = null) where TSource : class
        {
            var dst = (TSource)Activator.CreateInstance(typeof(TSource));

            try
            {

                //Getting the all the properties
                foreach (var item in src.GetType().GetProperties())
                {

                    var value = item.GetValue(src);

                    if (value == null)
                        continue;

                    var prop = dst.GetType().GetProperty(item.Name);

                    prop.SetValue(dst, value);

                    Debugger.Log(0, "Mapping primitive obj:", item.Name);

                }

            }
            catch (Exception e)
            { Debugger.Log(0, "Error while mapping:", e.Message); }

            return dst;
        }

    }

}
