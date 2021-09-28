using PromotionEngine.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
    public class Item<T> : IItem<T>
    {
        private T _sku;
        private double _price;
        public Item(T Sku, double Price)
        {
            if (Sku.Equals(default(T)))
            {
                throw new ArgumentException($"Sku cannot have the default value of type {Sku.GetType()}", "Sku");
            }
            _sku = Sku;
            _price = Price;
        }
        public double GetPrice()
        {
            return _price;
        }

        public T GetSku()
        {
            return _sku;
        }
    }
}
