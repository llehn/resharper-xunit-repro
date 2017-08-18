using System;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lol.Utils.Extensions
{
    /// <summary>
    /// Extension methods related to json output
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        ///     returns a nicely formatted JSON representation of the object
        ///     use with care since this is slow
        /// </summary>
        /// <param name="obj">object to convert to JSON</param>
        /// <returns>JSON output</returns>
        public static string ToJson(this object obj)
        {
            var type = obj?.GetType().FullName ?? "null";
            
            try
            {
                dynamic o = new ExpandoObject();
                o.Type = type;
                o.Object = obj ?? "null";

                return JsonConvert.SerializeObject(o,
                                                   new JsonSerializerSettings
                                                   {
                                                       Converters = new JsonConverter[] { new StringEnumConverter() },
                                                       Formatting = Formatting.Indented,
                                                       ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                                       PreserveReferencesHandling = PreserveReferencesHandling.None,
                                                       DefaultValueHandling = DefaultValueHandling.Ignore
                                                   });
            }
            catch (Exception)
            {
                dynamic o = new ExpandoObject();
                o.Type = obj?.GetType().FullName ?? "null";
                o.Object = "Error while serializing";

                return JsonConvert.SerializeObject(o,
                                                   new JsonSerializerSettings
                                                   {
                                                       Converters = new JsonConverter[] { new StringEnumConverter() },
                                                       Formatting = Formatting.Indented
                                                   });
            }
        }
    }
}
