using System;
using System.Collections.Generic;

namespace Pizza
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();

            var margherita = new Pizza("Маргарита", 400m, 3);
            var cola = new Drink("Кола", 50m, 300);
            var tiramisu = new Dessert("Тирамису", 320m, isTodayFresh: true);
            var pepperoni = new Pizza("Пепперони", 300m, 2);
            var cheesecake = new Dessert("Чизкейк", 280m, isTodayFresh: false);
            var water = new Drink("Вода", 30m, 500);
            var combo = new Combo("Обеденный", pepperoni, water);

            order.Add(margherita);
            order.Add(cola);
            order.Add(tiramisu);
            order.Add(pepperoni);
            order.Add(cheesecake);
            order.Add(water);
            order.Add(combo);

            order.PrintReceipt();

            Console.WriteLine();
            Console.WriteLine($"Скидка 10%: {order.GetTotalWithDiscount(10m):F2} руб.");

            Console.WriteLine();
            var most = order.FindMostExpensive();
            Console.WriteLine($"Самая дорогая позиция: {most?.GetInfo()}");

            Console.WriteLine();
            Console.WriteLine("Позиции по убыванию стоимости:");
            foreach (var item in order.SortByFinalPrice())
            {
                Console.WriteLine($"  {item.GetCategory}: {item.GetFinalPrice():F2} руб.");
            }

            Console.WriteLine();
            Console.WriteLine("Информация о скидках:");
            foreach (var item in order.GetItems())
            {
                if (item is IDiscountable d)
                    Console.WriteLine($"  {d.GetDiscountInfo()}");
            }

            // проверка того что просто так хер чё изменишь
            var readonlyList = order.GetItems();
            if (readonlyList is ICollection<MenuItem> collection)
            {
                try
                {
                    collection.Add(new Pizza("Тест", 100m, 0));
                }
                catch (NotSupportedException)
                {
                    Console.WriteLine();
                    Console.WriteLine("Попытка изменить список извне заблокирована: NotSupportedException.");
                }
            }
        }
    }
}
