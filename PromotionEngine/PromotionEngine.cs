using PromotionEngine.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public static class PromotionEngine<T>
    {
        public static double GetPriceOfCart(ICart<T> Cart, List<IPromotion<T>> Promotions, Dictionary<T,double> SkuPrices)
        {
            if (Cart == null)
            {
                throw new ArgumentNullException("Cart", "Null is not allowed for Cart parameter");
            }
            
            if (Cart.GetSkus().Count() == 0)
            {
                return 0;
            }

            if (Promotions == null)
            {
                throw new ArgumentNullException("Promotions", "Null is not allowed for Promotions parameter");
            }

            if (SkuPrices == null)
            {
                throw new ArgumentNullException("SkuPrices", "Null is not allowed for SkuPrices parameter");
            }

            var groupedCartSku = Cart.GetSkus().GroupBy(s => s).ToDictionary(g => g.Key, g => g.Count());

            EnsurePriceExistForAllSkus(groupedCartSku.Keys.ToList(), SkuPrices);
                        
            double totalAmount = 0;
            

            foreach(var p in Promotions)
            {
                var groupedPromotionSkus = p.GetSkus().GroupBy(s => s).ToDictionary(g => g.Key, g => g.Count());
                int qty = 1;
                foreach(var (k,v) in groupedPromotionSkus)
                {
                    if (!(groupedCartSku.ContainsKey(k)))
                    {
                        qty = 0;
                        break;
                    }

                    int temp = groupedCartSku[k] / v;
                    qty = (temp < qty) ? temp : qty;
                }

                if (qty > 0)
                {
                    foreach(var (k,v) in groupedPromotionSkus)
                    {
                        groupedCartSku[k] -= v * qty;
                    }
                    totalAmount += p.GetPrice() * qty;
                }
            }

            foreach(var (k,v) in groupedCartSku)
            {
                totalAmount += SkuPrices[k] * v;
            }
            return totalAmount;
        }

        private static void EnsurePriceExistForAllSkus(List<T> Skus,Dictionary<T,double> SkuPrices)
        {
            foreach(var sku in Skus)
            {
                if (!SkuPrices.ContainsKey(sku))
                {
                    throw new ArgumentException($"Sku: {sku} from he cart, does not exist in the SkuPrices","SkuPrices");
                }
            }
        }
    }
}
