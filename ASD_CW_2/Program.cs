using System;
using System.Collections.Generic;

namespace ASD_CW_2
{
    class Program
    {
        private static List<Transaction> transactions = new List<Transaction>();
        private static List<Category> categories = new List<Category>();

        static void Main(string[] args)
        {
            menu();
        }

        private static void menu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Add Transaction");
            Console.WriteLine("2) List Transactions");
            Console.WriteLine("3) Edit Transaction");
            Console.WriteLine("4) Delete Transaction");
            Console.WriteLine("5) Add Category");
            Console.WriteLine("6) List Category");

            Console.Write("Select an option: ");

            try
            {
                int userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        addTransaction();
                        menu();
                        break;
                    case 2:
                        listTransaction();
                        menu();
                        break;
                    case 3:
                        editTransaction();
                        menu();
                        break;
                    case 4:
                        deleteTransaction();
                        menu();
                        break;
                    case 5:
                        addCategory();
                        menu();
                        break;
                    case 6:
                        listCategory();
                        menu();
                        break;
                    case 7:
                        listCategory();
                        menu();
                        break;
                    default:
                        Console.WriteLine("");
                        throw new NotImplementedException();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void addTransaction()
        {
            Console.Write("Enter transaction amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter description: ");
            string? desc = Console.ReadLine();
            Console.Write("Is recurring (true or false): ");
            bool recurring = Convert.ToBoolean(Console.ReadLine());
            Console.Write("Enter due-date (yyyy.mm.dd): ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            Transaction t1 = new Transaction(amount, desc, recurring, date);

            transactions.Add(t1);
        }

        private static void editTransaction()
        {

        }

        private static void listTransaction()
        {
            foreach (Transaction t in transactions)
            {
                Console.WriteLine($"{t.getId()} : {t.getDate()} : {t.getAmount()} : {t.getDescription()} : {t.isRecurring()}");
            }
        }

        private static void deleteTransaction()
        {

        }

        private static void addCategory()
        {

        }

        private static void listCategory()
        {

        }
    }
}

