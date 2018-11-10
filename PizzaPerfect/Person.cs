using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PizzaPerfect
{
    class Person
    {
        public string FullName { get; private set; }
        public string Username { get; private set; }
        public List<Topping> ToppingPrefs { get; private set; }
    
        public Person(string fullName, string username, List<Topping> toppingPrefs)
        {
            FullName = fullName;
            Username = username;
            ToppingPrefs = toppingPrefs;
        }

        //public Person()
        //{
        //    FullName = null;
        //    Username = null;
        //    ToppingPrefs = null;
        //}
    }
}