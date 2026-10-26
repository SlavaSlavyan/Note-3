using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza
{
    /// <summary>
    /// интерфейс для скидки
    /// </summary>
    public interface IDiscountable
    {
        decimal ApplyDiscount(decimal percent);
        string GetDiscountInfo();
    }
}
