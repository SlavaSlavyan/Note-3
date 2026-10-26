using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    /// <summary>
    /// Онлайн подписка
    /// </summary>
    internal class SubscriptionProduct : Product
    {
        int _months;
        Money _monthlyPayment;

        public int Months => _months;

        public Money MonthlyPayment => _monthlyPayment;

        public SubscriptionProduct(string initName, float initWeight, Money initMonthlyPrice, int initMonths) : base(initName, initWeight, 0)
        { 
            
        }
    }
}
