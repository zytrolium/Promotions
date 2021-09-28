using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using PromotionEngine.Models;
namespace PromotionEngine.Tests.Model
{
    public class ItemTest
    {
        [Fact]
        public void GetSku_Of_Item_With_Char_Sku()
        {
            //Arrange
            var orgSku = 'A';
            var item = new Item<char>(orgSku, 50);

            //Act
            var sku = item.GetSku();

            //Assert
            Assert.Equal(orgSku, sku);
        }

        [Fact]
        public void GetPrice_Of_CharItem()
        {
            //Arrange
            var orgPice = 50;
            var item = new Item<char>('A', orgPice);

            //Act
            var price = item.GetPrice();

            //Assert
            Assert.Equal(orgPice, price);
        }

        [Fact]
        public void Exception_For_Default_Sku_Value()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => new Item<char>(default(char), 550));

            

        }
}
}
