using Models;
using Newtonsoft.Json;

namespace Services
{
    public class FileSystemDB<T> where T : BaseEntity
    {
        private static string _dbFolderPath = $@"..\..\..\..\Models\EntitiesDB";
        private static string _dbFile = $@"\{typeof(T).Name}.json";
        public delegate void PrintMultipleEntities(List<T> entities);

        public FileSystemDB()
        {
           
            if (!Directory.Exists(_dbFolderPath))
            {
                Directory.CreateDirectory(_dbFolderPath);
            }
            if (!File.Exists(_dbFolderPath + _dbFile))
            {
                File.Create(_dbFolderPath + _dbFile).Close();
            }
        
        }

        public static void SerializeEntities(List<T> entities)
        {
            using (StreamWriter serialize = new StreamWriter(_dbFolderPath + _dbFile))
            {
                string data = JsonConvert.SerializeObject(entities, Formatting.Indented);
                serialize.WriteLine(data);
            }
        }


        public static List<T>? DeserializeEntities()
        {
            using (StreamReader sr = new StreamReader(_dbFolderPath + _dbFile))
            {
                string jsonData = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(jsonData);
            }
        }

        public static void Add(T entity)
        {
            List<T>? data = DeserializeEntities();


            if (data != null)
            {
                data.Add(entity);
                SerializeEntities(data);

            }
            else
            {
                throw new ExceptionService("No data found");
            }

        }


        public static void Remove(T entity)
        {
            List<T>? data = DeserializeEntities();

            if (data != null)
            {
                data.Remove(entity);
                SerializeEntities(data);
            }
            else
            {
                throw new ExceptionService("No data found");
            }
        }
        public static T ReturnEntityById(int? index, List<T> data)
        {
            if (data != null)
            {
                T? entity = data.SingleOrDefault(entity => entity.Id == index);
                if (entity == null)
                {
                    throw new ExceptionService("Nothing found");
                }
                else
                {
                    return entity;
                }
            }
            else
            {
                throw new ExceptionService("No data found");
            }
        }

        public static void PrintEntity(T entity)
        {
            Console.WriteLine(entity.PrintInfo());
        }
        public static void PrintEntities(List<T> data, PrintMultipleEntities printMultiple)
        {
            printMultiple(data);
        }
    }
}
