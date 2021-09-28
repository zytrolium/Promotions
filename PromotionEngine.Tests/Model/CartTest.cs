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
            var orgSkus = new List<char>();
            orgSkus.Add('B');
            orgSkus.Add('C');
            var cart = new Cart<char>(orgSkus);
            //Act
            var skus = cart.GetSkus();

            //Assert
            Assert.Equal(orgSkus.Count, skus.Count);
        }

        [Fact]
        public void Add_Item_To_Cart()
        {
            //Arrange
            var cart = new Cart<char>();

            //Act
            cart.AddSkuToCart('A');
            var skus = cart.GetSkus();

            //Assert
            Assert.Single(skus);
        }
    }
}
