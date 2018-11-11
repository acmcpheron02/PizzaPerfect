using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPerfect
{
    class PizzaBuilder
    {
        private readonly UserList _userList;

        public PizzaBuilder(UserList userList)
        {
            _userList = userList;
        }

        public void GetUsers()
        {
            string input;
            string personList = "";
            List<Person> people = new List<Person>();
            Console.Clear();
            Console.WriteLine("Welcome to the pizza builder!");
            do
            {
                Console.WriteLine();
                if (personList != "")
                {
                    Console.WriteLine($"So far you have added {personList}.");
                }
                Console.WriteLine("Add a person to your group by entering their username below.");
                Console.WriteLine("To finish adding people, type F in the console. To quit, type Q.");
                input = Console.ReadLine();
                if (input.ToLower() == "f")
                {
                    do
                    {
                        Console.WriteLine("How many toppings would you like on your pizza?");
                        input = Console.ReadLine();
                        int toppingNumber;
                        if (int.TryParse(input, out toppingNumber))
                        {
                            Build(people, toppingNumber);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That was not a valid number. Please try again.");
                        }
                    } while (true);
                    
                }
                if (input.ToLower() == "q")
                {
                    break;
                }
                else
                {
                    Person foundPerson = _userList.GetPerson(input);
                    if (foundPerson == null)
                    {
                        Console.WriteLine("No user was found with that username. Please try again.");
                    }
                    else
                    {
                        people.Add(foundPerson);
                        if (personList == "")
                        {
                            personList = foundPerson.Username;
                        }
                        else
                        {
                            personList += (", " + foundPerson.Username);
                        }
                    }
                }
            } while (true);
        }

        public Pizza Build(List<Person> people, int toppingNumber)
        {
            return null;
        }
    }
}
