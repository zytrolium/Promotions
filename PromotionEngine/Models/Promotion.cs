using PromotionEngine.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
    public class Promotion<T> : IPromotion<T>
    {
        private List<IItem<T>> _itemList;
        private double _price;
        public Promotion(List<IItem<T>> ItemList, double Price)
        {
            if (ItemList == null)
            {
                throw new ArgumentNullException("ItemList", "ItemList cannot be null");
            }
            _itemList = ItemList;
            _price = Price;
        }

        public List<IItem<T>> GetItemList()
        {
            return _itemList;    
        }

        public double GetPrice()
        {
            return _price;
        }
    }
}
