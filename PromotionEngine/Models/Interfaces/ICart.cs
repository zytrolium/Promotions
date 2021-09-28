using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models.Interfaces
{
    public interface ICart<T>
    {
        void AddItemToCart(IItem<T> Item);
        List<IItem<T>> GetItemsInCart();
    }
}
