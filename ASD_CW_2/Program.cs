using System;
using System.Collections.Generic;

namespace ASD_CW_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Transaction> transactions = new List<Transaction>();

            Transaction t1 = new Transaction(2500.00, "Salary", true, Convert.ToDateTime("2022-12-25"));

            Console.WriteLine(t1.getId());

            Transaction t2 = new Transaction(250.00, "Food", false, Convert.ToDateTime("2022-12-30"));

            Console.WriteLine(t2.getId());
        }
    }
}

