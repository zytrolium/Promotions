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
    public class PromotionTest
    {
        [Fact]
        public void GetSkus_Of_Promotion_Items()
        {
            //Arrange
            var orgSkus = new List<char>();
            orgSkus.Add('C');
            orgSkus.Add('D');
            var p = new Promotion<char>(orgSkus, 30);
            //Act
            var skus = p.GetSkus();

            //Assert
            for(int i = 0; i < skus.Count; i++)
            {
                Assert.Equal(orgSkus[i], skus[i]);
            }
        }

        [Fact]
        public void GetPrice_Of_Promotion()
        {
            //Arrange
            var orgSkus = new List<char>();
            orgSkus.Add('C');
            orgSkus.Add('D');
            var orgPrice = 30;
            var p = new Promotion<char>(orgSkus, orgPrice);
            //Act
            var price = p.GetPrice();

            //Assert
            Assert.Equal(orgPrice, price);
        }

        [Fact]
        public void NullException_For_Non_Initialized_ItemList()
        {
            //Arrenge
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new Promotion<char>(null, 50));

        }
    }
}
