using PromotionEngine.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
    public class CharItem : IItem<char>
    {
        private char _sku;
        private double _price;
        public CharItem(char Sku, double Price)
        {
            if (!char.IsLetter(Sku))
            {
                throw new ArgumentException($"Only letter allowed for sku. Recieved Sku as: {Sku}", "Sku");
            }
            _sku = Sku;
            _price = Price;
        }
        public double GetPrice()
        {
            return _price;
        }

        public char GetSku()
        {
            return _sku;
        }
    }
}
