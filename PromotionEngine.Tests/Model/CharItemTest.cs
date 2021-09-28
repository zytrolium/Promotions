using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using PromotionEngine.Models;
namespace PromotionEngine.Tests.Model
{
    public class CharItemTest
    {
        [Fact]
        public void GetSku_Of_CharItem()
        {
            //Arrange
            var orgSku = 'A';
            var item = new CharItem(orgSku, 50);

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
            var item = new CharItem('A', orgPice);

            //Act
            var price = item.GetPrice();

            //Assert
            Assert.Equal(orgPice, price);
        }

        [Fact]
        public void Exception_For_Non_Letter_Sku_Of_CharItem()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => new CharItem('1', 550));

            

        }
}
}
