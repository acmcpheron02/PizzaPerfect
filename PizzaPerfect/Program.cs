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
            UserList userlist = new UserList();
            Menu menu = new Menu(userlist);
            menu.Display();
        }
    }
}
