using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    /// <summary>
    /// Абстрактный класс для всех товаров.
    /// </summary>
    internal abstract class Product
    {
        private string _name;
        private float _weight;
        private Money _price;
        protected bool _isDeliveryNeeded = false;

        public string Name => _name;
        public float Weight => _weight;
        public bool IsDeliveryNeeded => _isDeliveryNeeded;

        /// <param name="initName">Имя товара</param>
        /// <param name="initWeight">Вес товара</param>
        /// <param name="initPrice">Цена товара</param>
        /// <exception cref="ArgumentNullException">Имя товара не должно быть пустым</exception>
        /// <exception cref="ArgumentOutOfRangeException">Вес товара должен быть больше 0</exception>
        public Product(string initName, float initWeight, Money initPrice)
        {
            if (string.IsNullOrEmpty(initName)) throw new ArgumentNullException(initName, "Product name cannot be null or empty");
            _name = initName;

            if (initWeight <= 0) throw new ArgumentOutOfRangeException(initWeight.ToString(), "Product weigth cannot be null or empty");
            _weight = initWeight;

            _price = initPrice;
        }

        public virtual Money CalculatePrice() { return _price; }
    }
}