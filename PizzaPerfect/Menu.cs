using System;

/*  Description
 *  The menu class is intended both to display options to the user and to route the user to various functions in the program.
 *      I don't foresee needing many more classes passed into the constructor, but I might. I don't know a better way to structure this
 *      so that I'm not passing every object into this one point.
 */

namespace PizzaPerfect
{
	class Menu
	{
		private readonly UserList _userList;
        private readonly FileManager _fileManager;
        private readonly PizzaBuilder _pizzaBuilder;

        //Need these passed in to use their methods.
        public Menu(UserList userList, FileManager fileManager, PizzaBuilder pizzaBuilder)
		{
			_userList = userList;
            _fileManager = fileManager;
            _pizzaBuilder = pizzaBuilder;
		}

		public void Display()
		{
			int userInput;
			do
			{
                Console.Clear();
				Console.WriteLine("Preferred Pizza Picker");
				Console.WriteLine();
				Console.WriteLine("1. Add a New User");
				Console.WriteLine("2. Review an Existing User");
                Console.WriteLine("3. Save changes to the file");
                Console.WriteLine("4. Build a pizza");
                Console.WriteLine("0. Exit");
				userInput = Int32.Parse(Console.ReadLine());
				switch (userInput)
				{
					case 1:
						_userList.CreatePerson();
						break;
					case 2:
						_userList.DisplayUser();
						break;
                    case 3:
                        _fileManager.Save(_userList.People);
                        Console.WriteLine("Saved! Press any key to return to the main menu.");
                        Console.ReadKey();
                        break;
                    case 4:
                        _pizzaBuilder.GetUsers();
                        break;
					case 0:
						Console.WriteLine("See you later! (press any key)");
						Console.ReadKey();
						break;
					default:
						break;
				}
			} while(userInput!=0);
		}
	}
}