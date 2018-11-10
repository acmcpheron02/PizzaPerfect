using System;
using System.Collections;
using System.Collections.Generic;

namespace PizzaPerfect
{
  class Person
  {
    public string FullName {get; private set;}
    public string Email {get; private set;}
    public List<ITopping> ToppingPrefs {get; private set;}

    public Person(string fullName, string email, List<ITopping> toppingPrefs){
      FullName = fullName;
      Email = email;
      ToppingPrefs = toppingPrefs;
    }
  }
}