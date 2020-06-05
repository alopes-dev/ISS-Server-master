using Newtonsoft.Json.Linq;
using System.Linq;

namespace ISS.Application.Extensions
{
    public static class JsonCleanner
    {

        /// <summary>
        /// Helper function to clear the empty objects and arrays before sending to the client
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static JToken JTokenClear(JToken data)
        {

            void Remove(JProperty item)
            {
                if ((item.Value.Type == JTokenType.Array && !item.Value.HasValues) || item.Value.Type == JTokenType.Null)
                {
                    item.Remove();
                }
                else if ((item.Value.Type == JTokenType.Object))
                {
                    JTokenClear(item);
                    if (!item.Value.HasValues)
                        item.Remove();
                }
                else if (item.Value.Type == JTokenType.Array)
                {
                    JTokenClear(item.Value);
                    if (!item.Value[0].HasValues)
                        item.Remove();
                }
            }

            if (data.Type == JTokenType.Object)
            {
                (data as JObject).Properties().ToList().ForEach(x =>
                {

                    Remove(x);
                });
            }
            else
            {
                foreach (var item in data
                    .Children<JObject>()
                    .SelectMany(jo => jo.Properties())
                    .ToList())
                {
                    Remove(item);
                }

            }

            return data;
        }

    }
}
