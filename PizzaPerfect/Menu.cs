using System;

namespace PizzaPerfect
{
	class Menu
	{
		private readonly UserList _userList;
        private readonly FileManager _fileManager;

        public Menu(UserList userList, FileManager fileManager)
		{
			_userList = userList;
            _fileManager = fileManager;
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
                    case 3:
                        _fileManager.Save(_userList.Users);
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