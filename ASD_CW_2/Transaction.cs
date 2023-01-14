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
        private string description;
        private bool recurring;
        private DateTime date;
        private Category category;

        // Constructer
        public Transaction(double amount, string desc,  bool recurring, DateTime date, Category category)
        {
            this.id = ++_id; // Auto increment transaction id number
            this.tAmount = amount;
            this.description = desc;
            this.recurring = recurring;
            this.date = date;
            this.category = category;
        }

        // Get transaction Id
        public int getId()
        {
            return id;
        }

        // Get transaction amount
        public double getAmount()
        {
            return tAmount;
        }

        // Get transaction description/note 
        public string getDescription()
        {
            return description;
        }

        // Check transaction is recurring or not
        public bool isRecurring()
        {
            return recurring;
        }

        // Get transaction date and time
        public DateTime getDate()
        {
            return date;
        }

        // Get category related transaction
        public Category getCategory()
        {
            return category;
        }

        // Edit transaction amount
        public void setAmount(double amount)
        {
            this.tAmount = amount;
        }

        // Edit description or note
        public void setDescription(string description)
        {
            this.description = description;
        }

        // Change recurring status
        public void setRecurring(bool recurring)
        {
            this.recurring = recurring;
        }

        // Change transaction date time
        public void setDateTime(DateTime date)
        {
            this.date = date;
        }

        // Change category realated transaction
        public void setCategory(Category category)
        {
            this.category = category;
        }
    }
}
