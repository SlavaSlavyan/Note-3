using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza
{
    /// <summary>
    /// Абстрактная позиция в меню (товар)
    /// </summary>
    public abstract class MenuItem
    {
        private readonly decimal _basePrice;

        public string Name { get; }

        protected decimal BasePrice => _basePrice;

        protected MenuItem(string name, decimal basePrice)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название не может быть пустым.", nameof(name));
            if (basePrice < 0)
                throw new ArgumentException("Базовая цена не может быть отрицательной.", nameof(basePrice));

            Name = name;
            _basePrice = basePrice;
        }

        public abstract decimal GetFinalPrice();
        public abstract string GetInfo();

        public virtual string GetCategory() => "Позиция меню";
    }
}
