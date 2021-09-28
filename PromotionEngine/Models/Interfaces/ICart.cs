using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models.Interfaces
{
    interface ICart<T>
    {
        void addItemToCart(IItem<T> Item);
        List<IItem<T>> getItemsInCart();
    }
}
