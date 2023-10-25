using Newtonsoft.Json;
namespace ConsoleApp17
{
    internal class Program
    {
        private const string jsonName = "C:\\Users\\User\\Desktop\\ConsoleApp17\\ConsoleApp17\\Files\\names.json";
        static void Main(string[] args)
        {
            Add("Vagif");
            Add("Mata");
            Add("Wamil");


            Search();

        }

        

        private static void Add(string name)
        {
            List<string> names = ReadJson();

            names.Add(name);

            WriteJson(names);
            
        }



        private static void Delete(string name)
        {
            List<string> names = ReadJson();

            names.Remove(name);

            WriteJson(names);
        }


        private static bool Search(string name, Predicate<string> nameValue)
        {
            List<string> names = ReadJson();

            return names.Exists(nameValue);
        }

        private static List<string> ReadJson()
        {
            List<string> names = new List<string>();

            if (File.Exists(jsonName))
            {
                string jsons = File.ReadAllText(jsons);
                names = JsonConvert.DeserializeObject<List<string>>(jsons);
            }

            return names;
        }

        private static void WriteJson(List<string> name)
        {
            string jsons = JsonConvert.SerializeObject(name);
            File.WriteAllText(jsonName, jsons);
        }
    }
}