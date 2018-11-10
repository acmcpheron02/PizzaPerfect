using System;

namespace PizzaPerfect
{
	class Menu
	{
		private readonly UserList _userList;

		public Menu(UserList userList)
		{
			_userList = userList;
		}

		public void Display()
		{
			int userInput;
			do
			{
				Console.WriteLine("Preferred Pizza Picker");
				Console.WriteLine();
				Console.WriteLine("1. Add a New User");
				Console.WriteLine("2. Review an Existing User");
				Console.WriteLine("0. Exit");
				userInput = Int32.Parse(Console.ReadLine());
				switch (userInput)
				{
					case 1:
						_userList.CreateUser();
						break;
					case 2:
						_userList.FindUser();
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