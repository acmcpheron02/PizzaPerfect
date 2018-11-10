using System;
using System.Collections;
using System.Collections.Generic;

namespace PizzaPerfect
{
    class Person
    {
        public string FullName { get; private set; }
        public string Username { get; private set; }
        public List<ITopping> ToppingPrefs { get; private set; }

        public Person(string fullName, string username, List<ITopping> toppingPrefs)
        {
            FullName = fullName;
            Username = username;
            ToppingPrefs = toppingPrefs;
        }
    }
}