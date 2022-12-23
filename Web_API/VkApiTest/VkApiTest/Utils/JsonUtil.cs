using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace VkApiTest.Utils
{
    public static class JsonUtil
    {
        public static string ReadField(string json, string key)
        {
            StringReader reader = new StringReader(json);
            JsonReader jsonReader = new JsonTextReader(reader);
            JObject post = (JObject)JObject.ReadFrom(jsonReader);
            return post[key].ToString();
        }
        public static string ReadField(string json, string[] keys) 
        {
            StringReader reader = new StringReader(json);
            JsonReader jsonReader = new JsonTextReader(reader);
            JToken post = (JToken)JObject.ReadFrom(jsonReader);
            foreach (string key in keys) 
            {
                post = post[key];
            }
            return post.ToString();
        }

    }
}
