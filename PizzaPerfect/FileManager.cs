using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

/*  Description
 *  This class is responsible primarily for file IO operations. It's based in part on the Treehouse video about serialization,
 *      though I moved some things around to where I thought they made sense.
 */

namespace PizzaPerfect
{
    class FileManager
    {
        private string CurrentDirectory { get; set; }
        public string FileName { get; private set; }


        public FileManager()
        {
            CurrentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(CurrentDirectory);
            FileName = Path.Combine(directory.FullName, "PizzaPeople.json");
        }

        public void Save(List<Person> people)
        {
            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(FileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, people);
            }
        }

        public List<Person> Load()
        {
            var people = new List<Person>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(FileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                people = serializer.Deserialize<List<Person>>(jsonReader);
            }

            return people;
        }
    }
}