using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza
{
    /// <summary>
    /// ну... пицца... duhh...
    /// </summary>
    public class Pizza : MenuItem, IDiscountable
    {
        private const decimal ToppingPrice = 50m;
        private const int ToppingsForExtraDiscount = 3;
        private const decimal ExtraDiscount = 0.05m;

        public int ToppingsCount { get; }

        public Pizza(string name, decimal basePrice, int toppingsCount)
            : base(name, basePrice)
        {
            if (toppingsCount < 0)
                throw new ArgumentException("Число топпингов не может быть отрицательным.", nameof(toppingsCount));
            ToppingsCount = toppingsCount;
        }

        public override decimal GetFinalPrice()
            => BasePrice + ToppingsCount * ToppingPrice;

        public override string GetInfo()
            => $"Пицца «{Name}», топпингов: {ToppingsCount}, итого: {GetFinalPrice():F2} руб.";

        public override string GetCategory() => "Пицца";

        public decimal ApplyDiscount(decimal percent)
        {
            ValidatePercent(percent);

            decimal price = GetFinalPrice();
            price *= 1 - percent / 100m;

            if (ToppingsCount > ToppingsForExtraDiscount)
                price *= 1 - ExtraDiscount;

            return price;
        }

        public string GetDiscountInfo()
            => ToppingsCount > ToppingsForExtraDiscount
                ? $"Пицца «{Name}»: дополнительная скидка {ExtraDiscount * 100:F0}% (топпингов > {ToppingsForExtraDiscount})."
                : $"Пицца «{Name}»: только внешняя скидка.";

        private static void ValidatePercent(decimal percent)
        {
            if (percent < 0 || percent > 100)
                throw new ArgumentOutOfRangeException(nameof(percent), "Скидка должна быть в диапазоне 0..100.");
        }
    }
}
