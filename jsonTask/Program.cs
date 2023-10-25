using Newtonsoft.Json;
using NUglify.JavaScript;

namespace jsonTask
{
    internal class Program
    {
        //C:\Users\Murad\Desktop\Task_Interface_Static\jsonTask\jsonTask\files\ for reminder about path.
        static void Main(string[] args)
        {
            List<string> list = new List<string> { "Adil", "Heyder", "Sabir", "Murad" };

            string _generalpath = Directory.GetCurrentDirectory();
            DirectoryInfo directory = Directory.GetParent(_generalpath).Parent.Parent;
            File.Create(@$"{directory}\files\name.json").Close();
            _generalpath = (@$"{directory}\files\name.json");
            WriteToDB(list, _generalpath);
            Add("Oktay", _generalpath);
            Delete("Adil", _generalpath);
            Console.WriteLine(Search("Heyder", _generalpath));

        }

        public static void Add(string name, string generalpath)
        {
            List <string> _readfromdb = ReadFromDb(generalpath);
            _readfromdb.Add(name);
            WriteToDB(_readfromdb, generalpath);
        }

        
        public static bool Search(string name, string generalpath)
        {
            List<string> _readfromdb = ReadFromDb(generalpath);
            string name2 = _readfromdb.Find(x => x == name);
            if( name is not null ) { return true;}
            return false;
        }

        public static void Delete(string name, string generalpath)
        {
            List<string> _readfromdb = ReadFromDb(generalpath);
            string item = _readfromdb.Find(x => x == name);
            if ( item is not null ) { _readfromdb.Remove(item); }
        }


        public static List<string> ReadFromDb(string _path)
        {
            string dates;
            using (StreamReader reader = new StreamReader(_path))
            {
                dates = reader.ReadToEnd();
            }

            List<string> result = JsonConvert.DeserializeObject<List<string>>(dates);
            return result;
        }

        public static void WriteToDB(List <string> stringlist,string _generalpath)
        {
            string result = JsonConvert.SerializeObject(stringlist);
            using (StreamWriter writer = new StreamWriter(_generalpath))
            {
                writer.Write(result);
            }
        }

    }



}    