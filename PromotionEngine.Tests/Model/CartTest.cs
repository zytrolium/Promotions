using PromotionEngine.Models;
using PromotionEngine.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PromotionEngine.Tests.Model
{
    public class CartTest
    {
        [Fact]
        public void Get_Items_Of_Cart()
        {
            //Arrange
            var orgItems = new List<IItem<char>>();
            orgItems.Add(new Item<char>('B', 30));
            orgItems.Add(new Item<char>('C', 20));
            var cart = new Cart<char>(orgItems);
            //Act
            var items = cart.GetItemsInCart();

            //Assert
            Assert.Equal(orgItems.Count, items.Count);
        }

        [Fact]
        public void Add_Item_To_Cart()
        {
            //Arrange
            var cart = new Cart<char>();

            //Act
            cart.AddItemToCart(new Item<char>('A', 50));
            var items = cart.GetItemsInCart();

            //Assert
            Assert.Single(items);
        }
    }
}
