using System;
using System.IO;

namespace BadOrderSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new OrderService();
            string result = service.ProcessOrder("Иван Иванов", "Ноутбук", 20, 50000);
            Console.WriteLine($"Результат: {result}");
        }
    }

    public class OrderService
    {
        public string ProcessOrder(string customerName, string product, int qty, double price)
        {
            // проверка
            if (string.IsNullOrEmpty(customerName)) 
                return "Customer name is empty";

            if (string.IsNullOrEmpty(product))
                return "Product is empty";

            if (qty <= 0)
                return "Quantity must be > 0";

            if (price <= 0)
                return "Price must be > 0";

            // расчёт скидки
            double discount = 0;
            if (qty > 100)
                discount = 0.15;
            else if (qty > 50)
                discount = 0.1;
            else if (qty > 10)
                discount = 0.05;

            double total = qty * price * (1 - discount);
            Console.WriteLine("Заказ оформлен: " + customerName + ", сумма: " + total);

            // сохранение в файл 
            File.WriteAllText("order.txt", customerName + "|" + product + "|" + total);

            return "OK";
        }
    }
}