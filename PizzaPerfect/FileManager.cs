using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        //public List<Person> Load()
        //{
        //    UserList userList = new UserList();
        //    using (StreamReader file = File.OpenText(@"c:\movie.json"))
        //    {
        //        JsonSerializer serializer = new JsonSerializer();
        //        UserList userList = (UserList)serializer.Deserialize(file, typeof(UserList));
        //    }
        //    return userList;
        //}

        //public void Save(UserList userList)
        //{
        //    // serialize JSON to a string and then write string to a file
        //    File.WriteAllText(FileName, JsonConvert.SerializeObject(userList));

        //    // serialize JSON directly to a file
        //    using (StreamWriter file = File.CreateText(FileName))
        //    {
        //        JsonSerializer serializer = new JsonSerializer();
        //        serializer.Serialize(file, userList);
        //    }
        //}

        //public List<Person> OldLoad()
        //{
        //    var listPersons = new List<Person>();
        //    var serializer = new JsonSerializer();
        //    using (var reader = new StreamReader(FileName))
        //    using (var jsonReader = new JsonTextReader(reader))
        //    {
        //        listPersons = serializer.Deserialize<List<Person>>(jsonReader);
        //    }
        //    return listPersons;
        //}

        //public void OldSave(List<Person> persons)
        //{
        //    var serializer = new JsonSerializer();
        //    using (var writer = new StreamWriter(FileName))
        //    using (var jsonWriter = new JsonTextWriter(writer))
        //    {
        //        serializer.Serialize(jsonWriter, persons);
        //    }
        //}

        //        public List<Person> Load(string fileName)
        //        {
        //            var fileUsers = new List<Person>();
        //            using (var reader = new StreamReader(fileName))
        //            {
        //                string line = "";
        //                reader.ReadLine();
        //                while ((line = reader.ReadLine()) != null)
        //                {
        //                    var person = new Person();
        //                    string[] values = line.Split(',');

        //                    DateTime gameDate;
        //                    if (DateTime.TryParse(values[0], out gameDate))
        //                    {
        //                        person.GameDate = gameDate;
        //                    }
        //                    person.TeamName = values[1];
        //                    HomeOrAway homeOrAway;
        //                    if (Enum.TryParse(values[2], out homeOrAway))
        //                    {
        //                        person.HomeOrAway = homeOrAway;
        //                    }
        //                    int parseInt;
        //                    if (int.TryParse(values[3], out parseInt))
        //                    {
        //                        person.Goals = parseInt;
        //                    }


        //                }
        //            }
        //            return soccerResults;
        //        }
    }
}
