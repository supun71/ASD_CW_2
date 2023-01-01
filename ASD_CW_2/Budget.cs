using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_CW_2
{
    internal class Budget
    {
        private double bAmount;
        private double balance;

        public Budget()
        {

        }

        public double getAmount()
        {
            return bAmount;
        }

        public double getBalance()
        {
            return balance;
        }

        public void setAmount(double bAmount)
        {
            this.bAmount = bAmount;
        }

        public void setBalance(double tAmount)
        {
            balance = bAmount - tAmount;
        }
    }
}
