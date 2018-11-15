Welcome to Pizza Perfect, the program that perfectly picks a pizza per provided preferences.

This project is a work in progress, so please use it gently. In particular, I still need to add some better input validation in the menus. A preloaded user file has been included for testing purposes. They have usernames of 'a', 'b', and 'c'. If you would like to start from scratch, you can delete the contents of the PizzaPeople.Json. Otherwise, new users can be added to the file and used between sessions. The backend file will be automatically loaded on startup.

How to use:
*Load the .SLN file in Visual Studio
*Run/debug to an external console

Currently this program contains four main menu items.
*Add a New User
    This will survey the program user to generate a new profile. After answering all questions, the user will be asked if they would like to 
    save the user. This saves the user to the list in memory but it does *not* save the user to the file. This functionality is found under
    menu option 3.
    
*Review an Existing User
    Search for existing users by username
    
*Save changes to the file
    Serialize the current user list to PizzaPeople.Json. This file name can not be changed from within the program, but the code can be changed freely.
    
*Build a Pizza
    Build a group of people you would like to feed, then choose an amount of toppings for the pizza. This will return a string describing the
    ideal pizza for said group.
    
TO-DO ------
*Add more robust and consistent input validation
*Listing a topping as 0 preference should prevent the topping from appearing on a pizza. It does not do that yet.
*Refactor the Topping class to include the SurveyToppings method and not use ToppingList as only a list.
*Enhance the menu to be easier to modify and populate more values programmatically.
*Make an actual Pizza class that pizzas can be stored in, instead of just a string describing the LINQ query results.
*Give more customization options as to how many pizzas are ordered, more/less cheese, vegetarian only, etc.
