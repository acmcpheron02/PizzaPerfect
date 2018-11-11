using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPerfect
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate all the things!
            FileManager fileManager = new FileManager();
            UserList userlist = new UserList(fileManager);
            PizzaBuilder pizzaBuilder = new PizzaBuilder(userlist);
            Menu menu = new Menu(userlist, fileManager, pizzaBuilder);

            //Display the menu to kick everything off. We shouldn't get past this function until we're leaving the program.
            menu.Display();
        }
    }
}
