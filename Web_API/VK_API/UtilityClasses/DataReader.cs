using System.Text.Json;
using System.IO;
using Newtonsoft.Json;

namespace VK_API
{

    public class DataReader
    {
        public static T LoadData<T>(string filepath)
        {
            string currentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            StreamReader reader = new($"{currentDirectory}{filepath}");
            string jsonstring = reader.ReadToEnd();
            return System.Text.Json.JsonSerializer.Deserialize<T>(jsonstring);
        }

    }
    
}
