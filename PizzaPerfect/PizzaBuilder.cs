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
            bool exit = false;
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
                            Console.Clear();
                            Console.WriteLine(Build(people, toppingNumber));
                            Console.WriteLine("Press any key to return to the main menu.");
                            Console.ReadKey();
                            exit = true;
                        }
                        else
                        {
                            Console.WriteLine("That was not a valid number. Please try again.");
                        }
                    } while (!exit);

                }
                if (input.ToLower() == "q")
                {
                    break;
                }
                else if (!exit)
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
            } while (!exit);
        }

        public string Build(List<Person> people, int toppingNumber)
        {
            List<Topping> combinedToppings = new List<Topping>();
            foreach (Person person in people)
            {
                foreach (Topping topping in person.ToppingPrefs)
                {
                    combinedToppings.Add(topping);
                }
            }
            //I can't figure out how to factor this in, so right now it looks like 0 will not completely remove toppings. Coming soon.
            //var banned = combinedToppings.Where(p => p.LikeScale == 0);

            var scoredToppings = combinedToppings
                .GroupBy(t => t.Name)
                .Select(tg => new
                {
                    Name = tg.Key,
                    Score = tg.Sum(t => t.LikeScale)
                });

            var topToppings = scoredToppings
                .OrderByDescending(s => s.Score)
                //.Select(s => new {s.Name})
                .Take(toppingNumber);

            var result = topToppings.ToList();
            string resultString = "";

            foreach (var name in result)
            {
                if (resultString == "")
                {
                    resultString = name.Name;
                }
                else
                {
                    resultString += ", " + name.Name;
                }
            }

            return $"Your perfect {toppingNumber} topping pizza should have {resultString} on it.";

            //Select((fruit, index) =>
            //          new { index, str = fruit.Substring(0, index) });

            //var ofInterest = allMyNames
            //        .Distinct()
            //        .Where(x => x.CompareTo(from) >= 0 && x.CompareTo(to) <= 0)
            //        .OrderBy(x => x)
            //        .Take(4);
        }
    }
}
