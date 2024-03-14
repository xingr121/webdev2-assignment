using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_consoleApp
{
    internal class PaymentCard
    {
        private double balance;

       
        public PaymentCard(double openingBalance)
        {
            balance = openingBalance;
        }

       
        public override string ToString()
        {
            return $"The card has a balance of {balance} euros";
        }

        // Method to decrease balance when eating lunch
        public void EatLunch()
        {
            if (balance >= 10.60)
            {
                balance -= 10.60;
            }
        }

        // Method to decrease balance when drinking coffee
        public void DrinkCoffee()
        {
            if (balance >= 2.0)
            {
                balance -= 2.0;
            }
        }

        // Method to add money to the card's balance
        public void AddMoney(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                if (balance > 150)
                {
                    balance = 150;
                }
            }
        }
    }
}
