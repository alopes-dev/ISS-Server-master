namespace ISS.Application.Helpers
{
    /// <summary>
    /// Helper to set a value of a specific property of an obj
    /// </summary>
    public static class ClassExtensions
    {
        /// <summary>
        /// Atribuição de nulos para propriedades virtuais.
        /// </summary>
        /// <param name="model">O modelo com possíveis propriedades virtuais.</param>
        /// <returns></returns>
        public static void ClearVirtual<T>(this T model)
            where T : class
        {
            // Pegando as propriedades do objecto
            foreach (var prop in model.GetType().GetProperties())
            {
                // Verificar se é virtual
                if (prop.GetMethod.IsVirtual)
                    // Anulando a propriedade
                    prop.SetValue(model, null);
            }
        }
        /// <summary>
        /// The Obj value setter
        /// </summary>
        /// <typeparam name="T"> the type of the obj </typeparam>
        /// <param name="obj"> the obj it self, the one that it need to be set </param>
        /// <param name="prop"> the property that need to be set </param>
        /// <param name="value"> the value to set </param>
        public static T SetPropValue<T>(this T obj, string prop, object value)
        {
            //Getting the all the properties
            var _info = obj.GetType().GetProperty(prop);

            if (_info != null)
                //Setting the value
                _info.SetValue(obj, value, null);
            return obj;
        }
    }
}
