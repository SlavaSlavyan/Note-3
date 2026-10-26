using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza
{
    /// <summary>
    /// напитки
    /// </summary>
    public class Drink : MenuItem
    {
        private const decimal PricePerMl = 0.5m;

        public int VolumeMl { get; }

        public Drink(string name, decimal basePrice, int volumeMl)
            : base(name, basePrice)
        {
            if (volumeMl < 0)
                throw new ArgumentException("Объём не может быть отрицательным.", nameof(volumeMl));
            VolumeMl = volumeMl;
        }

        public override decimal GetFinalPrice()
            => BasePrice + VolumeMl * PricePerMl;

        public override string GetInfo()
            => $"Напиток «{Name}», {VolumeMl} мл, итого: {GetFinalPrice():F2} руб.";

        public override string GetCategory() => "Напиток";
    }
}
