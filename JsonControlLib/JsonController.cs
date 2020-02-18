using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonControlLib
{
    public class JsonController
    {
        #region - Fields & Properties

        #endregion

        #region - Methods
        public static string ConvertObjectToString<T>( T convertObject ) where T : class
        {
            try
            {
                return JsonConvert.SerializeObject(convertObject, Formatting.Indented);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T ConvertStringToObject<T>( string input ) where T : new()
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SaveJsonToFolder<T>( string path, string fileName, T input )
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(path, fileName + ".json")))
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings()
                    {
                        Formatting = Formatting.Indented
                    };
                    JsonSerializer serializer = JsonSerializer.Create(settings);
                    serializer.Serialize(writer, input, input.GetType());
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T OpenJsonFile<T>( string path, string name )
        {
            try
            {
                using (StreamReader reader = new StreamReader(Path.Combine(path, name + ".json")))
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings()
                    {
                        Formatting = Formatting.Indented
                    };
                    JsonSerializer serializer = JsonSerializer.Create(settings);
                    JsonTextReader jsonReader = new JsonTextReader(reader);
                    return serializer.Deserialize<T>(jsonReader);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string GetJsonFolder( )
        {
            string current = Directory.GetCurrentDirectory();
            var reflect = System.Reflection.Assembly.GetExecutingAssembly();

            DirectoryInfo parent_1 = Directory.GetParent(reflect.Location);
            DirectoryInfo parent_2 = Directory.GetParent(parent_1.FullName);
            DirectoryInfo parent_3 = Directory.GetParent(parent_2.FullName);
            DirectoryInfo parent_4 = Directory.GetParent(parent_3.FullName);

            string[] dirPaths = Directory.GetDirectories(parent_4.FullName);
            string[] dataModelsOut = Directory.GetDirectories(dirPaths.First(x => x.Contains("DataModels")));

            string output = FindFolder(dataModelsOut, "DefaultInspectionFiles");

            if (!String.IsNullOrWhiteSpace(output))
            {
                if (Directory.Exists(output))
                {
                    return output;
                }
                else
                {
                    throw new FileNotFoundException("Directory doesnt match the DefaultInspectionFiles directory.");
                }
            }
            else
            {
                throw new FileNotFoundException("Directory not found in DataModels.");
            }
        }

        private static string FindFolder( string[] dirs, string name )
        {
            string output = "";
            foreach (string dir in dirs)
            {
                if (dir.Contains(name))
                {
                    output = dir;
                    break;
                }
            }
            return output;
        }
        #endregion

        #region - Full Properties

        #endregion
    }
}
