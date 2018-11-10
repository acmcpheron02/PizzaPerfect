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
            FileManager fileManager = new FileManager();
            UserList userlist = new UserList(fileManager);
            Menu menu = new Menu(userlist, fileManager);
            menu.Display();
        }
    }
}
