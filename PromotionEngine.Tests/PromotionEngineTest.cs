using PromotionEngine.Models;
using PromotionEngine.Models.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngine.Tests
{
    public class PromotionEngineTest
    {
        [Fact]
        public void PromotionEngine_Get_Price_Scenario_A_Test()
        {
            //Arrange
            var skuUnitPrices = SetUpUnitPrices();
            var activePromotions = SetupActivePromotions();
            var cart = new Cart<char>(new List<char>() { 'A', 'B', 'C' });

            //Act
            var cartAmount = PromotionEngine.PromotionEngine<char>.GetPriceOfCart(cart, activePromotions, skuUnitPrices);

            //Assert
            Assert.Equal(100, cartAmount);
        }

        [Fact]
        public void PromotionEngine_Get_Price_Scenario_B_Test()
        {
            //Arrange
            var skuUnitPrices = SetUpUnitPrices();
            var activePromotions = SetupActivePromotions();
            var cart = new Cart<char>(new List<char>() { 'A', 'A', 'A', 'A', 'A', 'B', 'B', 'B', 'B', 'B', 'C' });

            //Act
            var cartAmount = PromotionEngine<char>.GetPriceOfCart(cart, activePromotions, skuUnitPrices);

            //Assert
            Assert.Equal(370, cartAmount);
        }

        [Fact]
        public void PromotionEngine_Get_Price_Scenario_C_Test()
        {
            //Arrange
            var skuUnitPrices = SetUpUnitPrices();
            var activePromotions = SetupActivePromotions();
            var cart = new Cart<char>(new List<char>() { 'A', 'A', 'A', 'B', 'B', 'B', 'B', 'B', 'C', 'D' });
            //Act
            var cartAmount = PromotionEngine<char>.GetPriceOfCart(cart, activePromotions, skuUnitPrices);

            //Assert
            Assert.Equal(280, cartAmount);
        }

        [Fact]
        public void PromotionEngine_Cart_Parameter_Is_Null()
        {
            //Arrange
            var skuUnitPrices = SetUpUnitPrices();
            var activePromotions = SetupActivePromotions();

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => PromotionEngine<char>.GetPriceOfCart(null, activePromotions, skuUnitPrices));
        }

        [Fact]
        public void PromotionEngine_Get_Price_Of_Empty_Cart()
        {
            //Arrange
            var skuUnitPrices = SetUpUnitPrices();
            var activePromotions = SetupActivePromotions();
            var cart = new Cart<char>(new List<char>());
            //Act
            var cartAmount = PromotionEngine<char>.GetPriceOfCart(cart, activePromotions, skuUnitPrices);

            //Assert
            Assert.Equal(0, cartAmount);
        }

        [Fact]
        public void PromotionEngine_Promotions_Parameter_Is_Null()
        {
            //Arrange
            var skuUnitPrices = SetUpUnitPrices();
            var cart = new Cart<char>(new List<char>() { 'A', 'A', 'A', 'B', 'B', 'B', 'B', 'B', 'C', 'D' });
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => PromotionEngine<char>.GetPriceOfCart(cart, null, skuUnitPrices));
        }

        [Fact]
        public void PromotionEngine_SkuPrices_Parameter_Is_Null()
        {
            //Arrange
            var activePromotions = SetupActivePromotions();
            var cart = new Cart<char>(new List<char>() { 'A', 'A', 'A', 'B', 'B', 'B', 'B', 'B', 'C', 'D' });
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => PromotionEngine<char>.GetPriceOfCart(cart, activePromotions, null));
        }

        [Fact]
        public void PromotionEngine_Exception_For_Missing_SkuPrice()
        {
            //Arrange
            var skuUnitPrices = SetUpUnitPrices();
            var activePromotions = SetupActivePromotions();
            var cart = new Cart<char>(new List<char>() { 'A', 'A', 'A', 'B', 'B', 'B', 'B', 'B', 'C', 'D','X' });
            //Act
            //Assert
            Assert.Throws<ArgumentException>(() => PromotionEngine<char>.GetPriceOfCart(cart, activePromotions, skuUnitPrices));
        }

        
        private Dictionary<char,double> SetUpUnitPrices()
        {
            var skuUnitPrices = new Dictionary<char, double>();
            skuUnitPrices.Add('A', 50);
            skuUnitPrices.Add('B', 30);
            skuUnitPrices.Add('C', 20);
            skuUnitPrices.Add('D', 15);
            return skuUnitPrices;
        }

        private List<IPromotion<char>> SetupActivePromotions()
        {
            var activePromotions = new List<IPromotion<char>>();
            activePromotions.Add(new Promotion<char>(new List<char>() { 'A', 'A', 'A' }, 130));
            activePromotions.Add(new Promotion<char>(new List<char>() { 'B', 'B'}, 45));
            activePromotions.Add(new Promotion<char>(new List<char>() { 'C', 'D'}, 30));
            return activePromotions;
        }
    }
}
