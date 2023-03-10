using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_CW_2
{
    internal class Budget
    {
        private double bAmount; // budget amount
        private double balance; // budget balance

        // Constructer
        public Budget(double amount)
        {
            this.bAmount = amount;
            this.balance = amount;
        }

        // Get budget amount
        public double getAmount()
        {
            return bAmount;
        }

        // Get budget balance
        public double getBalance()
        {
            return balance;
        }

        // Update budget amount
        public void setAmount(double bAmount)
        {
            double previousAmount = this.bAmount; // Store current budget amount in temp variable
            this.bAmount = bAmount; // Update budget amount
            this.balance += (-previousAmount + bAmount); // Old and new budget amount difference value add to current balance
        }

        // Update budget balance
        public void setBalance(double tAmount)
        {
            this.balance += tAmount;
        }
    }
}
