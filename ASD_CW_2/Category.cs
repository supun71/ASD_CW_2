using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_CW_2
{
    internal class Category
    {
        private static int _id = 0;
        private int id;
        private string name;
        private bool cType; // category type as boolean value, income as true and expense as false
        private Budget budget;

        // Constructer
        public Category(string name, bool type, double amount)
        {
            this.id = ++_id; // Auto increment transaction id number
            this.name = name;
            this.cType = type;
            this.budget = new Budget(amount); // Craete budget object
        }

        // Get category Id
        public int getId()
        {
            return id;
        }

        // Get category name
        public string getName()
        {
            return name;
        }

        // Get category type as boolean value
        public bool getType()
        {
            return cType;
        }

        // Change category name
        public void setName(string name)
        {
            this.name = name;
        }

        // Change catagory type
        public void setType(bool cType)
        {
            this.cType = cType;
        }

        // Get budget object related category
        public Budget getBudget()
        {
            return budget;
        }
    }
}
