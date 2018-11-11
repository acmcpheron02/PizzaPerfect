using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

/*  Description:
 *  This class contains our list of users, named People below. It also contains methods to insert and retrieve data. Eventually you will be able to Update and Delete as well. 
 */

namespace PizzaPerfect
{
    class UserList
    {
        public List<Person> People { get; private set; }

        public UserList(FileManager fileManager)
        {
            People = fileManager.Load();
            //code below instantiates an empty People list if there is no file to load.
            if (People == null)
            {
                People = new List<Person>();
            }
        }

        public void CreatePerson()
        {
            Console.WriteLine("Please enter the following information:");
            Console.WriteLine("Username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Full name: ");
            var name = Console.ReadLine();

            ToppingList toppingList = new ToppingList();
            List<Topping> toppings = SurveyToppings(toppingList);

            Person person = new Person(name, username, toppings);
            SavePerson(person);
        }

        //Choosing whether or not to save the person to the list in memory specifically. This does not write to the file. For that, see FileManager.Save()
        public void SavePerson(Person person)
        {
            Console.WriteLine("Would you like to add {0} to the user list?", person.Username);
            Console.WriteLine("Type Y for Yes");
            Console.WriteLine("Type N for No");
            do
            {
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "y")
                {
                    People.Add(person);
                    break;
                }
                else if (userInput.ToLower() == "x")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a valid input. Please try again.");
                }
            } while (true);
        }

        //This code is pretty bad and I'm not proud of it, but it is working and I don't have the spare time to refactor this into something better.
        //TODO: Put SurveyToppings() out of it's misery.
        private List<Topping> SurveyToppings(ToppingList toppingList)
        {
            Console.WriteLine("Please rate the following toppings from 1 to 5, 1 being least liked and 5 being most liked. For any toppings you cannot eat, use 0.");
            int likeness = 0;
            List<Topping> toppings = new List<Topping>(toppingList.Toppings.Length);
            for (int i = 0; i < toppingList.Toppings.Length; i++)
            {
                Console.WriteLine(toppingList.Toppings[i] + ": ");
                likeness = Int32.Parse(Console.ReadLine());
                Topping toAdd = new Topping(
                    toppingList.Toppings[i],
                    likeness,
                    true,
                    true
                );
                toppings.Add(toAdd);
            }
            return toppings;
        }

        public Person GetPerson(string searchedUser)
        {
            var foundUsers = People.Where(u => u.Username == searchedUser);
            if (foundUsers.Count() == 1)
            {
                return foundUsers.First();
            }
            else
            {
                return null;
            }
        }

        public void DisplayUser()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Please enter the username of the user you would like to find.");
                var username = Console.ReadLine();
                var foundUser = People.Where(u => u.Username == username);
                Console.WriteLine();
                foreach (Person person in foundUser)
                {
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine(person.FullName);
                    foreach (Topping topping in person.ToppingPrefs)
                    {
                        Console.WriteLine(string.Format("{0}: {1}", topping.Name, topping.LikeScale));
                    }
                    Console.WriteLine("---------------------------------------");
                }

                Console.WriteLine();
                Console.WriteLine("Would you like to start another search?");
                Console.WriteLine("Type Y for Yes");
                Console.WriteLine("Type anything else to exit");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "y")
                {
                    continue;
                }
                else
                {
                    break;
                }
            } while (true);
        }
    }

}