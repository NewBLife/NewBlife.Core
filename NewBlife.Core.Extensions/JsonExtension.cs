using System.Text;
using Newtonsoft.Json;

namespace NewBlife.Core.Extensions
{
    /// <summary>
    /// Json Deserialize and Serialize extension
    /// </summary>
    public static class JsonExtension
    {
        /// <summary>
        /// To the object.
        /// </summary>
        /// <typeparam name="T">object tyep</typeparam>
        /// <param name="jsonStr">The json string.</param>
        /// <returns>Object value</returns>
        public static T ToObject<T>(this string jsonStr)
        {
            return JsonConvert.DeserializeObject<T>(jsonStr);
        }

        /// <summary>
        /// To the json string.
        /// </summary>
        /// <typeparam name="T">object tyep</typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>Json string</returns>
        public static string ToJsonStr<T>(this T obj) where T : class
        {
            string result = string.Empty;
            if (obj != null)
            {
                var errors = new StringBuilder();
                result = JsonConvert.SerializeObject(
                    obj,
                    new JsonSerializerSettings
                    {
                        Error = (s, e) =>
                        {
                            errors.AppendLine(e.ErrorContext.Error.Message);
                            e.ErrorContext.Handled = true;
                        }
                    });

                if (errors.Length > 0)
                {
                    result = errors.Insert(0, result).ToString();
                }
            }
            else
            {
                result = "NULL";
            }

            return result;
        }
    }
}
