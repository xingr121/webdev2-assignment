using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_consoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PaymentCard card = new PaymentCard(50);
            Console.WriteLine(card);
            card.EatLunch();
            Console.WriteLine(card);

            card.DrinkCoffee();
            Console.WriteLine(card);


            card.AddMoney(49.99);
            Console.WriteLine(card);

            card.AddMoney(10000.0);
            Console.WriteLine(card);

            card.AddMoney(-10);
            Console.WriteLine(card);

            Console.ReadLine();
        }
    }
}
