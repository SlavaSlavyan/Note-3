using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Pizza
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        private const int MaxItems = 20;

        private readonly List<MenuItem> _items = new();

        public void Add(MenuItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (_items.Count >= MaxItems)
                throw new InvalidOperationException($"В заказе не может быть больше {MaxItems} позиций.");

            _items.Add(item);
        }

        /// <summary>
        /// Возвращает обёртку только для чтения. Список будет рид онли.
        /// </summary>
        public IReadOnlyList<MenuItem> GetItems()
            => new ReadOnlyCollection<MenuItem>(_items);

        public decimal GetTotal()
            => _items.Sum(i => i.GetFinalPrice());

        public void PrintReceipt()
        {
            Console.WriteLine("=== ЧЕК ===");
            foreach (var item in _items)
            {
                Console.WriteLine($"[{item.GetCategory()}] {item.GetInfo()}");
            }
            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"Итого: {GetTotal():F2} руб.");
        }

        public decimal GetTotalWithDiscount(decimal percent)
        {
            if (percent < 0 || percent > 100)
                throw new ArgumentOutOfRangeException(nameof(percent), "Скидка должна быть в диапазоне 0..100.");

            decimal total = 0m;
            foreach (var item in _items)
            {
                total += item is IDiscountable discountable
                    ? discountable.ApplyDiscount(percent)
                    : item.GetFinalPrice();
            }
            return total;
        }

        public MenuItem? FindMostExpensive()
            => _items.Count == 0 ? null : _items.MaxBy(i => i.GetFinalPrice());

        public IReadOnlyList<MenuItem> SortByFinalPrice()
            => _items.OrderByDescending(i => i.GetFinalPrice()).ToList().AsReadOnly();
    }
}
