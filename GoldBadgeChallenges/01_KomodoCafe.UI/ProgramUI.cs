
using _01_KomodoCafe.Repository;
using MenuItemClasses;
using System;
using System.Collections.Generic;

namespace _01_KomodoCafe.UI
{
    public class ProgramUI
    {
        private readonly MenuItemRepository _menuItemRepository;


        public ProgramUI()
        {
            _menuItemRepository = new MenuItemRepository();
        }

        public void Run()
        {
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Komodo Cafe!!\n" +
                    "Please enter a number to perform one of the following: \n\n" +
                    "1. Add a Menu Item\n" +
                    "2. View All Menu Items\n" +
                    "3. Delete Menu Item\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        ViewMenuItems();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    default:
                        Console.WriteLine(userInput + " is a  invalid input please try  again");
                        Console.ReadLine();
                        break;
                }

                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
            }
        }

        private void DeleteMenuItem()
        {
            Console.WriteLine("Please enter a Meal Number:");
            int inputMealNumber = Convert.ToInt32(Console.ReadLine());
            MenuItem existingMenuItemDelete = _menuItemRepository.GetMenuItem(inputMealNumber);
            if (existingMenuItemDelete != null)
            {
                _menuItemRepository.DeleteMenuItem(inputMealNumber);
                Console.WriteLine("This meal has been deleted!");
            }
            else
            {
                Console.WriteLine("This meal does not exist!");
            }
        }

        private void ViewMenuItems()
        {
            foreach (MenuItem currentMenuItem in _menuItemRepository.GetAllMenuItems())
            {
                Console.WriteLine(currentMenuItem.MealNumber);
                Console.WriteLine(currentMenuItem.MealName);
                Console.WriteLine(currentMenuItem.Description);
                Console.WriteLine(currentMenuItem.Price);
                Console.WriteLine(String.Join(",",currentMenuItem.Ingredients));
            }
        }

        private void AddMenuItem()
        {
            Console.WriteLine("You have selected to add a menu item!");
            Console.WriteLine("Please enter the meal name: ");
            string mealName = Console.ReadLine();
            Console.WriteLine("Please enter a description of the meal item:");
            string mealDescription = Console.ReadLine();
            Console.WriteLine("Please enter the meal number:");
            int mealNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the list of ingrediants:");
            string[] ingrediants = Console.ReadLine().Split(',');
            Console.WriteLine("Please enter a price for the menu item:");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            MenuItem menuItemToAdd = new MenuItem(mealNumber, mealName, mealDescription, new List<string>(ingrediants), price);

            _menuItemRepository.AddMenuItem(menuItemToAdd);

            Console.WriteLine("You have added a new menu item!");
        }
    }
}
