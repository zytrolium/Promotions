using PromotionEngine.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
    public class CharPromotion : IPromotion<char>
    {
        private List<IItem<char>> _itemList;
        private double _price;
        public CharPromotion(List<IItem<char>> ItemList, double Price)
        {
            if (ItemList == null)
            {
                throw new ArgumentNullException("ItemList", "ItemList cannot be null");
            }
            _itemList = ItemList;
            _price = Price;
        }

        public List<IItem<char>> GetItemList()
        {
            return _itemList;    
        }

        public double GetPrice()
        {
            return _price;
        }
    }
}
