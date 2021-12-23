
using _01_KomodoCafe.Repository;
using MenuItemClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_KomodoCafe.Tests
{
    [TestClass]
    public class KomodoCafeRepoTest
    {
        [TestMethod]//Create
        public void AddMenuItem_GivenMenuItem_AddsMenuItem()
        {
            //Arrange
            MenuItem expectedMenuItem = new MenuItem(1, null, null, null, 0);
            MenuItemRepository repository = new MenuItemRepository();

            //Act
             repository.AddMenuItem(expectedMenuItem);
             MenuItem actualMenuItem = repository.GetMenuItem(1);

            //Assert
            Assert.AreEqual (actualMenuItem, expectedMenuItem);

        }

        [TestMethod]//Read
        public void GetMenuItem_GivenMealNumber_ReturnsMenuItem()
        {
            //Arrange
            MenuItem expectedMenuItem = new MenuItem(1, null, null, null, 0);
            MenuItemRepository repository = new MenuItemRepository();
            //Action
            repository.AddMenuItem(expectedMenuItem);
            MenuItem actualMenuItem = repository.GetMenuItem(1);
            //Assert
            Assert.AreEqual (actualMenuItem, expectedMenuItem);

        }

        [TestMethod]//Delete
        public void DeleteMenuItem_GivenMealNumber_DeletesMenuItem()
        {
            //Arrange
            MenuItemRepository repository = new MenuItemRepository();
            repository.AddMenuItem(new MenuItem(1, null, null, null, 0));
            //Act
            repository.DeleteMenuItem(1);
            //Assert
            Assert.AreEqual(0, repository.GetRepositoryCount());
        }
    }
}
