using MenuItemClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe.Repository
{
    public class MenuItemRepository
    {
        private readonly List<MenuItem> _menuItemRepository = new List<MenuItem>();
        

        //Create
        public void AddMenuItem(MenuItem menuItemToAdd)
        {
            _menuItemRepository.Add(menuItemToAdd);
        }
        //Read
        public MenuItem GetMenuItem(int mealNumber)
        {
            foreach(MenuItem menuItem in _menuItemRepository)
            {
                if(menuItem.MealNumber == mealNumber)
                {
                    return menuItem;
                }
            }
            return null;
        }
        //Delete
        public void DeleteMenuItem(int mealNumber)
        {
            MenuItem menuItemToDelete = null;
            foreach (MenuItem menuItem in _menuItemRepository)
            {
                if(menuItem.MealNumber == mealNumber)
                {
                    menuItemToDelete = menuItem;
                }
            }
            if(menuItemToDelete != null)
            {
                _menuItemRepository.Remove(menuItemToDelete);
            }
        }

        public List<MenuItem> GetAllMenuItems() 
        {
            return _menuItemRepository;
        }

        public int GetRepositoryCount() { return _menuItemRepository.Count; }    
       
    }
}
