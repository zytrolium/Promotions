using PromotionEngine.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
    public class Cart<T> : ICart<T>
    {
        private List<T> _skus;

        public Cart()
        {
            _skus = new List<T>();
        }

        public Cart(List<T> Skus)
        {
            _skus = (Skus == null) ? new List<T>() : Skus;
        }

        public void AddSkuToCart(T Sku)
        {
            if (default(T).Equals(Sku))
            {
                throw new ArgumentException($"Sku cannot contain default value of type {Sku.GetType()}", "Sku");
            }
            _skus.Add(Sku);
        }

        public List<T> GetSkus()
        {
            return _skus;
        }
    }
}
