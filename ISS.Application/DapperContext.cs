using Dapper;
using ISS.Application.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ISS.Application
{
    public static class SqlConnectionExtensions
    {
        public static async Task<T> InsertAsync<T>(this SqlConnection connection, T model)
            where T : class
        {
            // INSERT INTO [dbo].[TableName] (...Fields) VALUES (...Values)
            var sql = SqlQueries.Insert(model);
            // Executing the query
            await connection.ExecuteScalarAsync(sql);
            // Getting the key
            var key = model.GetPrimaryKey();
            // Getting the inserted row
            return await connection.GetAsync<T>(model.GetPropertyValue(key).ToString(), key);
        }

        public static async Task<T> GetAsync<T>(this SqlConnection connection, string value, string field = null)
            where T : class
        {
            // Checking if the value is valid
            if (value == null) return null;
            // Instantiating the model
            var instance = Activator.CreateInstance(typeof(T));
            // Building the query
            var sql = SqlQueries.Select(typeof(T).Name, field ?? instance.GetPrimaryKey(), value);
            // Executing the query
            return await connection.QueryFirstOrDefaultAsync<T>(sql);
        }

        public static async Task<IEnumerable<T>> GetAsync<T>(this SqlConnection connection)
            where T : class
        {
            // SELECT * FROM [dbo].[TableName]
            var sql = SqlQueries.Select(typeof(T).Name);
            // Executing the query
            return await connection.QueryAsync<T>(sql);
        }

        public static async Task<T> RemoveAsync<T>(this SqlConnection connection, T model, string id, string field = null)
            where T : class
        {
            // DELETE [dbo].[TableName] WHERE [FieldName] = [FieldValue]
            var sql = SqlQueries.Remove(model, id, field);
            // Executing the query
            await connection.ExecuteScalarAsync(sql);
            return model;
        }

        public static async Task<T> UpdateAsync<T>(this SqlConnection connection, T model, string id, string field = null)
            where T : class
        {
            // UPDATE [dbo].[TableName] SET ...Fields = ...Values WHERE [FieldName] = [FieldValue]
            var sql = SqlQueries.Update(model, id, field);
            // Executing the query
            await connection.ExecuteScalarAsync(sql);
            return model;
        }
    }

    public class DapperContext : IDisposable
    {
        private readonly string _connectionString;
        public static DapperContext Instance { get; set; }

        public DapperContext(string connectionString)
        {
            _connectionString = connectionString;
            Instance = this;
        }

        public SqlConnection Connection => new SqlConnection(_connectionString);
        #region Database Accessors
        /// <summary>
        /// Buscar um registro sobre <typeparamref name="T"/>
        /// </summary>
        /// <param name="value">O valor a ser procurado</param>
        /// <param name="field">O campo a ser combinado na pesquisa</param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string value, string field = null)
            where T : class
        {
            // Checking if the value is valid
            if (value == null) return null;
            // Instantiating the model
            var instance = Activator.CreateInstance(typeof(T));
            // Building the query
            var sql = SqlQueries.Select(typeof(T).Name, field ?? instance.GetPrimaryKey(), value);
            // Executing the query
            return await Connection.QueryFirstOrDefaultAsync<T>(sql);
        }

        /// <summary>
        /// Buscar registros sobre o <typeparamref name="T"/> adicionando uma express�o depois do select ...
        /// </summary>
        /// <typeparam name="T">Define a tabela.</typeparam>
        /// <param name="fun">A func�o que ser� usada para inclus�o</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAsync<T>(Action<T> fun, string value = null, string field = null)
            where T : class
        {
            // SELECT * FROM [dbo].[TableName]
            string sql = SqlQueries.Select(typeof(T).Name);
            if (value != null)
            {
                var instance = Activator.CreateInstance(typeof(T));
                // SELECT * FROM [dbo].[TableName] WHERE [FieldName] = [FieldValue]
                sql = SqlQueries.Select(typeof(T).Name, field ?? instance.GetPrimaryKey(), value);
            }

            // Executing the query
            var model = await Connection.QueryAsync<T>(sql);
            if (fun != null)
                // Looping the results to add the function configuration
                foreach (var item in model)
                    // Calling the setting function
                    fun.Invoke(item);

            return model;
        }

        /// <summary>
        /// Buscar registros sobre o <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">Define a tabela.</typeparam>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAsync<T>()
            where T : class
        {
            // SELECT * FROM [dbo].[TableName]
            var sql = SqlQueries.Select(typeof(T).Name);
            // Executing the query
            return await Connection.QueryAsync<T>(sql);
        }

        /// <summary>
        /// Inserir um registro sobre <typeparamref name="T"/>
        /// </summary>
        /// <param name="model">O objecto que ser� inserido</param>
        /// <returns></returns>
        public async Task<T> InsertAsync<T>(T model)
            where T : class
        {
            // INSERT INTO [dbo].[TableName] (...Fields) VALUES (...Values)
            var sql = SqlQueries.Insert(model);
            // Executing the query
            await Connection.ExecuteScalarAsync(sql);
            // Getting the key
            var key = model.GetPrimaryKey();
            // Getting the inserted row
            return await this.GetAsync<T>(model.GetPropertyValue(key).ToString(), key);
        }

        public void Dispose()
        {
            Connection.Close();
        }
        #endregion
    }

    public static class DapperExtensions
    {
        public static TBase DapperInclude<TBase, TModel>(this TBase model, Expression<Func<TBase, TModel>> exp)
            where TBase : class
            where TModel : class
        {
            if (model == null)
                return model;

            // Getting the instance
            var inst = DapperContext.Instance;
            // Getting the connection of the model
            var conn = inst.Connection;
            // Getting the type of the model
            var type = model.GetType();
            // Getting the main expression
            var expName = (exp.Body as MemberExpression).Member.Name;
            // Getting the property using that name
            var prop = type.GetProperty(expName);
            // Getting the name of the  prop that needs to be refered with
            var propRef = type.GetProperty(prop.GetAttr("ForeignKeyAttribute"));
            // Getting the value that it's needs to be combined
            var propRefValue = propRef?.GetValue(model) as string;

            // Invoking the model to be added
            var expProp = exp.Compile().Invoke(model);

            // Checking if it's a kind of list
            if (expProp is IList || expProp is ICollection || expProp is IEnumerable)
            {
                // Getting the Objecte in the list
                var _base_ = typeof(TModel).GetGenericArguments()[0];
                // Making a list of that
                var listType = typeof(List<>).MakeGenericType(_base_);
                // Creating an instance of that
                var res = (IList)Activator.CreateInstance(listType);

                //--------------------------------------------
                // Getting the inverse prop
                var out_prop = prop.GetAttr("InversePropertyAttribute");
                // Getting the other class
                var out_class = prop.PropertyType.GenericTypeArguments[0];
                // Getting the virtual prop in the class
                var out_vir_prop = out_class.GetProperty(out_prop);
                // Getting the main prop
                var out_foreign_prop = out_vir_prop.GetAttr("ForeignKeyAttribute");
                var type_value = type.GetProperty(model.GetPrimaryKey())?.GetValue(model);
                //--------------------------------------------

                // Getting the sql query
                var sql = SqlQueries.SelectWhere(out_class.Name, $"WHERE {out_foreign_prop}='{type_value}'");
                // Getting the data
                var _res_ = conn.QueryAsync(sql).Await();

                // Looping the data
                foreach (var item in _res_)
                {
                    // Creating a map value
                    var values = (IDictionary<string, object>)item;
                    // Instantiatinz an object of the list
                    var obj = Activator.CreateInstance(_base_);
                    // Getting the object type
                    var objType = obj.GetType();

                    foreach (var p in values)
                        // Getting the prop to set
                        objType.GetProperty(p.Key)?.SetValue(obj, p.Value);

                    // Adding to the list
                    res.Add(obj);
                }

                // Setting the model after all changes
                prop.SetValue(model, res);
            }
            else
            {
                if (propRefValue == null || prop.GetValue(model) != null)
                    return model;

                TModel res = inst.GetAsync<TModel>(propRefValue).Await();
                // Setting the model after all changes
                prop.SetValue(model, res);
            }

            return model;
        }

        public static TBase DapperInclude<TBase, TModel>(this TBase model, Expression<Func<TBase, TModel>> exp, SqlConnection con)
            where TBase : class
            where TModel : class
        {
            if (model == null)
                return model;
            // Getting the connection of the model
            var conn = con;
            // Getting the type of the model
            var type = model.GetType();
            // Getting the main expression
            var expName = (exp.Body as MemberExpression).Member.Name;
            // Getting the property using that name
            var prop = type.GetProperty(expName);
            // Getting the name of the  prop that needs to be refered with
            var propRef = type.GetProperty(prop.GetAttr("ForeignKeyAttribute"));
            // Getting the value that it's needs to be combined
            var propRefValue = propRef?.GetValue(model) as string;

            // Invoking the model to be added
            var expProp = exp.Compile().Invoke(model);

            // Checking if it's a kind of list
            if (expProp is IList || expProp is ICollection || expProp is IEnumerable)
            {
                // Getting the Objecte in the list
                var _base_ = typeof(TModel).GetGenericArguments()[0];
                // Making a list of that
                var listType = typeof(List<>).MakeGenericType(_base_);
                // Creating an instance of that
                var res = (IList)Activator.CreateInstance(listType);

                //--------------------------------------------
                // Getting the inverse prop
                var out_prop = prop.GetAttr("InversePropertyAttribute");
                // Getting the other class
                var out_class = prop.PropertyType.GenericTypeArguments[0];
                // Getting the virtual prop in the class
                var out_vir_prop = out_class.GetProperty(out_prop);
                // Getting the main prop
                var out_foreign_prop = out_vir_prop.GetAttr("ForeignKeyAttribute");
                var type_value = type.GetProperty(model.GetPrimaryKey())?.GetValue(model);
                //--------------------------------------------

                // Getting the sql query
                var sql = SqlQueries.SelectWhere(out_class.Name, $"WHERE {out_foreign_prop}='{type_value}'");
                // Getting the data
                var _res_ = conn.QueryAsync(sql).Await();

                // Looping the data
                foreach (var item in _res_)
                {
                    // Creating a map value
                    var values = (IDictionary<string, object>)item;
                    // Instantiatinz an object of the list
                    var obj = Activator.CreateInstance(_base_);
                    // Getting the object type
                    var objType = obj.GetType();

                    foreach (var p in values)
                        // Getting the prop to set
                        objType.GetProperty(p.Key)?.SetValue(obj, p.Value);

                    // Adding to the list
                    res.Add(obj);
                }

                // Setting the model after all changes
                prop.SetValue(model, res);
            }
            else
            {
                if (propRefValue == null || prop.GetValue(model) != null)
                    return model;

                TModel res = con.GetAsync<TModel>(propRefValue).Await();
                // Setting the model after all changes
                prop.SetValue(model, res);
            }

            return model;
        }

        public static TModel DapperThenInclude<TBase, TModel>(this TBase model, Expression<Func<TBase, TModel>> exp)
            where TBase : class
            where TModel : class
        {

            if (model == null)
                throw new ArgumentNullException($"{typeof(TBase).Name} Não pode ser nulo");

            var prop = (exp.Body as MemberExpression).Member.Name;

            if (model is IList || model is ICollection || model is IEnumerable)
            {
                TModel res = null;

                var list = (model as IList);
                if (list != null)
                    foreach (var item in list)
                    {

                        var tBase = item.GetType();
                        var tModel = tBase.GetProperty(prop).PropertyType;

                        ParameterExpression parameter = Expression.Parameter(tBase, exp.Parameters[0].Name);
                        MemberExpression property = Expression.Property(parameter, (exp.Body as MemberExpression).Member.Name);

                        var delegateType = typeof(Func<,>).MakeGenericType(tBase, tModel);
                        var new_exp = Expression.Lambda(delegateType, property, parameter);

                        typeof(DapperExtensions).GetMethod(nameof(DapperInclude))
                            .MakeGenericMethod(tBase, tModel)
                            .Invoke(null, new[] { item, new_exp });

                        res ??= tBase.GetProperty(prop).GetValue(item) as TModel;

                    }

                return res;
            }

            model.DapperInclude(exp);
            return (model.GetType().GetProperty(prop).GetValue(model) as TModel);
        }

        /// <summary>
        /// Helper to await till the async function is completed
        /// </summary>
        /// <typeparam name="T">The model into the Task</typeparam>
        /// <param name="result">The return object</param>
        /// <returns></returns>
        public static T Await<T>(this Task<T> result)
            where T : class
        {
            // Running the function
            result.Wait();
            // Returning the result
            return result.Result;
        }
    }
}