using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPerfect
{
	class UserList
	{
	    private List<Person> Users {get; set;}

		public void CreateUser()
		{
			Console.WriteLine("Please enter the following information:");
			Console.WriteLine("Full name: ");
			var name = Console.ReadLine();
			Console.WriteLine("Email: ");
			var email = Console.ReadLine();

			ToppingList toppingList = new ToppingList();
			List<ITopping> toppings = SurveyToppings(toppingList);

			Person person = new Person(name, email, toppings);
			SaveUser(person);
		}

		public void SaveUser(Person person)
		{
			Console.WriteLine($"Would you like to save {0} to the user list?", person.FullName);
			Console.WriteLine("Type Y for Yes");
			Console.WriteLine("Type N for No");
			do
			{
				string userInput = Console.ReadLine();
				if (userInput.ToLower() == "y")
				{
					Users.Add(person);
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
			} while(true);
		}

		private List<ITopping> SurveyToppings(ToppingList toppingList)
		{
			Console.WriteLine("Please rate the following toppings from 1 to 5, 1 being least liked and 5 being most liked. For any toppings you cannot eat, use 0.");
			int likeness = 0;
			List<ITopping> toppings = new List<ITopping>(toppingList.Toppings.Length);
			for(int i = 0; i < toppingList.Toppings.Length; i++)
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

		public void FindUser()
		{
			Console.WriteLine("Please enter the email address of the user you would like to find.");
			var email = Console.ReadLine();
			var foundUser = Users.Where(u => u.Email == email);
			Console.WriteLine();
			foreach (Person person in foundUser)
			{
				Console.WriteLine(person.FullName);
				foreach (Topping topping in person.ToppingPrefs)
				{
					Console.WriteLine(string.Format("{0}: {1}", topping.Name, topping.LikeScale));
				}
			}
		}	
	}

}