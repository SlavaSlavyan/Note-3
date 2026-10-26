using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shop
{
    /// <summary>
    /// Класс для хранения рублей.
    /// </summary>
    internal struct Money
    {
        private decimal _amount;

        public decimal Amount
        {
            get => _amount;

            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), "Money value cannot be negative.");
                _amount = value;
            }
        }

        /// <param name="initAmount">Начальное значение денег</param>
        public Money(decimal initAmount)
        {
            Amount = initAmount;
        }

        public static Money operator +(Money a, Money b)
        {
            return new Money(a.Amount + b.Amount);
        }

        public static Money operator -(Money a, Money b)
        {
            return new Money(a.Amount - b.Amount);
        }

        public static Money operator *(Money money, int factor)
        {
            return new Money(money.Amount * factor);
        }

        public static Money operator *(Money money, decimal factor)
        {
            return new Money(money.Amount * factor);
        }

        public override string ToString()
        {
            return string.Create(CultureInfo.GetCultureInfo("ru-RU"), $"{Amount:N2} rub");
        }

        public static implicit operator Money(decimal value) => new Money(value);
    }
}
