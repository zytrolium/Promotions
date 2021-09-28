using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models.Interfaces
{
    public interface ICart<T>
    {
        void AddSkuToCart(T Sku);
        List<T> GetSkus();
    }
}
