using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_CW_2
{
    internal class Transaction
    {
        private static int _id = 0;
        private int id;
        private double tAmount;
        private string? description;
        private bool recurring;
        private DateTime date;

        public Transaction(double amount, string? desc, bool recurring, DateTime date)
        {
            this.id = ++_id;
            this.tAmount = amount;
            this.description = desc;
            this.recurring = recurring;
            this.date = date;
        }

        public int getId()
        {
            return id;
        }

        public double getAmount()
        {
            return tAmount;
        }

        public string? getDescription()
        {
            return description;
        }

        public bool isRecurring()
        {
            return recurring;
        }

        public DateTime getDate()
        {
            return date;
        }

        public void setAmount(double amount)
        {
            this.tAmount = amount;
        }

        public void setDescription(string description)
        {
            this.description = description;
        }

        public void setRecurring(bool recurring)
        {
            this.recurring = recurring;
        }

        public void setDateTime(DateTime date)
        {
            this.date = date;
        }
    }
}
