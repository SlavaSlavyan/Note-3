using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza
{
    /// <summary>
    /// дессерты
    /// </summary>
    public class Dessert : MenuItem, IDiscountable
    {
        private const decimal NotFreshPriceFactor = 0.7m;
        private const decimal NotFreshDiscount = 0.10m;

        public bool IsTodayFresh { get; }

        public Dessert(string name, decimal basePrice, bool isTodayFresh)
            : base(name, basePrice)
        {
            IsTodayFresh = isTodayFresh;
        }

        public override decimal GetFinalPrice()
            => IsTodayFresh ? BasePrice : BasePrice * NotFreshPriceFactor;

        public override string GetInfo()
        {
            string freshText = IsTodayFresh ? "свежий" : "не свежий";
            return $"Десерт «{Name}», {freshText}, итого: {GetFinalPrice():F2} руб.";
        }

        public override string GetCategory() => "Десерт";

        public decimal ApplyDiscount(decimal percent)
        {
            if (percent < 0 || percent > 100)
                throw new ArgumentOutOfRangeException(nameof(percent), "Скидка должна быть в диапазоне 0..100.");

            decimal price = GetFinalPrice();
            price *= 1 - percent / 100m;

            if (!IsTodayFresh)
                price *= 1 - NotFreshDiscount;

            return price;
        }

        public string GetDiscountInfo()
            => IsTodayFresh
                ? $"Десерт «{Name}»: только внешняя скидка."
                : $"Десерт «{Name}»: дополнительная скидка {NotFreshDiscount * 100:F0}% (распродажа).";
    }
}
