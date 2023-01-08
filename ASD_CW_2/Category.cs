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
        private bool cType;
        private Budget budget;

        public Category(string name, bool type, double amount)
        {
            this.id = ++_id;
            this.name = name;
            this.cType = type;
            this.budget = new Budget(amount);
        }

        public int getId()
        {
            return id;
        }

        public string getName()
        {
            return name;
        }

        public bool getType()
        {
            return cType;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setType(bool cType)
        {
            this.cType = cType;
        }

        public Budget getBudget()
        {
            return budget;
        }
    }
}
