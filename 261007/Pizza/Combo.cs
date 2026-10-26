using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Pizza
{
    /// <summary>
    /// Комбо
    /// </summary>
    public class Combo : MenuItem
    {
        private const decimal ComboDiscount = 0.15m;

        private readonly List<MenuItem> _children;

        public Combo(string name, params MenuItem[] items)
            : base(name, SumFinal(items))
        {
            if (items == null || items.Length == 0)
                throw new ArgumentException("Комбо должно содержать хотя бы одну позицию.", nameof(items));
            if (items.Any(i => i == null))
                throw new ArgumentNullException(nameof(items), "Комбо не может содержать null.");

            _children = new List<MenuItem>(items);
        }

        public IReadOnlyList<MenuItem> Items => _children.AsReadOnly();

        public override decimal GetFinalPrice()
            => _children.Sum(i => i.GetFinalPrice()) * (1 - ComboDiscount);

        public override string GetInfo()
            => $"Комбо «{Name}», позиций: {_children.Count}, скидка {ComboDiscount * 100:F0}%, итого: {GetFinalPrice():F2} руб.";

        public override string GetCategory() => "Комбо";

        private static decimal SumFinal(MenuItem[]? items)
        {
            if (items == null) return 0m;
            return items.Where(i => i != null).Sum(i => i.GetFinalPrice());
        }
    }
}
