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
    public class CharPromotionTest
    {
        [Fact]
        public void GetSkus_Of_Promotion_Items()
        {
            //Arrange
            var orgItems = new List<IItem<char>>();
            orgItems.Add(new CharItem('C', 20));
            orgItems.Add(new CharItem('D', 25));
            var p = new CharPromotion(orgItems, 30);
            //Act
            var items = p.GetItemList();

            //Assert
            for(int i = 0; i < items.Count; i++)
            {
                Assert.Equal(orgItems[i].GetSku(), items[i].GetSku());
            }
        }

        [Fact]
        public void GetPrice_Of_Promotion()
        {
            //Arrange
            var orgItems = new List<IItem<char>>();
            orgItems.Add(new CharItem('C', 20));
            orgItems.Add(new CharItem('D', 25));
            var orgPrice = 30;
            var p = new CharPromotion(orgItems, orgPrice);
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
            Assert.Throws<ArgumentNullException>(() => new CharPromotion(null, 50));

        }
    }
}
