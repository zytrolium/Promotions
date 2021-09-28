using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models.Interfaces
{
    public interface Item<T>
    {
        T GetSku();
        double GetPrice();
    }
}
