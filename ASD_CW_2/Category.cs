using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_CW_2
{
    internal class Category
    {
        private string name;
        private bool cType;

        public Category()
        {

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
    }
}
