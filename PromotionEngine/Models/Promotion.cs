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
        private List<T> _skus;
        private double _price;
        public Promotion(List<T> Skus, double Price)
        {
            if (Skus == null)
            {
                throw new ArgumentNullException("Skus", "Skus cannot be null");
            }

            if (Skus.Count == 0)
            {
                throw new ArgumentException("Skus must contain at least one sku", "Skus");
            }
            _skus = Skus;
            _price = Price;
        }

        public double GetPrice()
        {
            return _price;
        }

        public List<T> GetSkus()
        {
            return _skus;
        }
    }
}
