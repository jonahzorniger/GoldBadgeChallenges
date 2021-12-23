using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItemClasses
{

     //The Menu Items:
    // A meal number, so customers can say "I'll have the #5"
    //A meal name
    //A description
    //A list of ingredients,
    //A price

    public class MenuItem
    {
        public MenuItem() { }

        public MenuItem
            (int mealNumber,
            string mealName,
            string description,
            List<string> ingredients,
            decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;  
            Price = price;
        }
        //unique identifier
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }
    }
}
