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
        private List<IItem<T>> _items;

        public Cart()
        {
            _items = new List<IItem<T>>();
        }

        public Cart(List<IItem<T>> Items)
        {
            _items = (Items == null) ? new List<IItem<T>>() : Items;
        }

        public void addItemToCart(IItem<T> Item)
        {
            _items.Add(Item);
        }

        public List<IItem<T>> getItemsInCart()
        {
            return _items;
        }
    }
}
