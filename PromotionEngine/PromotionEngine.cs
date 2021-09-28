using PromotionEngine.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public static class PromotionEngine<T>
    {
        public static double GetPriceOfCart(ICart<T> Cart, List<IPromotion<T>> Promotions)
        {
            double totalAmount = 0;
            var groupedCartSku = Cart.GetItemsInCart().GroupBy(c => c.GetSku()).ToDictionary(g => g.Key, g => g.Count());
            var itemPrices = GetItemPricesOfCart(Cart);

            foreach(var p in Promotions)
            {
                var groupedPromotionSkus = p.GetItemList().GroupBy(i => i.GetSku()).ToDictionary(g => g.Key, g => g.Count());
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
                totalAmount += itemPrices[k] * v;
            }
            return totalAmount;
        }

        private static Dictionary<T,double> GetItemPricesOfCart(ICart<T> Cart)
        {
            Dictionary<T, double> itemPrices = new Dictionary<T, double>();
            var distinctSkus = Cart.GetItemsInCart().Select(i => i.GetSku()).Distinct().ToList();
            foreach (var sku in distinctSkus)
            {
                var item = Cart.GetItemsInCart().Where(c => c.GetSku().Equals(sku)).First();
                itemPrices[sku] = item.GetPrice();
            }
            return itemPrices;
        }
    }
}
