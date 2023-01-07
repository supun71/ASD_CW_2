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
            categories.Add(new Category("Salary",true));
            categories.Add(new Category("Foods", false, 25000));
            menu();
        }

        private static void menu()
        {
            Console.WriteLine("");
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
            string desc = Console.ReadLine();

            Console.Write("Choose the category:\n");
            listCategory();
            string categoryName = Console.ReadLine();

            Category category = hasCategory(categoryName);

            if (category.Equals(null))
            {
                Console.WriteLine($"Category {categoryName} is not exist");
            }
            
            
            Console.Write("Is recurring (true or false): ");
            bool recurring = Convert.ToBoolean(Console.ReadLine());
            /*Console.Write("Enter due-date (yyyy.mm.dd): ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());*/
            DateTime date = DateTime.Now;

            Transaction t1 = new Transaction(amount, desc, recurring, date, category);

            transactions.Add(t1);
        }

        private static void editTransaction()
        {
            Console.Write("Enter the transaction Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Transaction transactionObj = transactions.FirstOrDefault(Transaction => Transaction.getId() == id);

            if (transactionObj == null)
            {
                Console.WriteLine($"Id number {id} not belongs to any transaction");
            }

            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Change Category");
            Console.WriteLine("2) Change Date");
            Console.WriteLine("3) Edit Amount");
            Console.WriteLine("4) Edit Description");
            Console.WriteLine("5) Change recurring status");

            Console.Write("Select an option: ");

            try
            {
                int userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        Console.Write("Enter category: ");
                        string category = Console.ReadLine();

                        if (hasCategory(category)== null)
                        {
                            Console.WriteLine($"Category {category} is not available");
                        }
                        editTransaction();
                        break;
                    case 2:
                        Console.Write("Enter due-date (yyyy.mm.dd): ");
                        DateTime date = Convert.ToDateTime(Console.ReadLine());
                        transactionObj.setDateTime(date);
                        editTransaction();
                        break;
                    case 3:
                        Console.Write("Enter transaction amount: ");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        transactionObj.setAmount(amount);
                        editTransaction();
                        break;
                    case 4:
                        Console.Write("Enter description: ");
                        string desc = Console.ReadLine();
                        transactionObj.setDescription(desc);
                        editTransaction();
                        break;
                    case 5:
                        Console.Write("Is recurring (true or false): ");
                        bool recurring = Convert.ToBoolean(Console.ReadLine());
                        transactionObj.setRecurring(recurring);
                        editTransaction();
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

        private static void listTransaction()
        {
            foreach (Transaction t in transactions)
            {
                string rec = t.isRecurring() ? "YES" : "NO";
                Console.WriteLine($"T_ID: {t.getId()} \tT_Date & Time: {t.getDate()} \tT_Amount: {t.getAmount()} \tT_Description: {t.getDescription()} \tT_Recurring: {rec} \tT_Category: {t.getCategory().getName()}");
            }
        }

        private static void deleteTransaction()
        {
            Console.Write("Enter the transaction Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Transaction transactionObj = transactions.FirstOrDefault(Transaction => Transaction.getId() == id);

            if (transactionObj == null)
            {
                Console.WriteLine($"Id number {id} not belongs to any transaction");
            }

            transactions.Remove(transactionObj);
        }

        private static void addCategory()
        {
            Console.Write("Enter category name: ");
            string name = Console.ReadLine();
            Console.Write("Enter category type (Income/Expense): ");
            bool type = Console.ReadLine() == "Income" ? true : false;
            if (type)
            {
                Category c1 = new Category(name, type);
                categories.Add(c1);

            }
            else
            {
                Console.Write("Enter category Budget: ");
                double amount = Convert.ToDouble(Console.ReadLine());
                Category c1 = new Category(name, type,amount);
                categories.Add(c1);
            }
            //Category c1 = new Category(name, type);

            //categories.Add(c1);
        }

        private static void listCategory()
        {
            Console.WriteLine("\nCategories:");
            foreach (Category c in categories)
            {
                string type = c.getType() ? "Income" : "Expense";
                Console.WriteLine($"*{c?.getName()}\t: {type}");
            }
        }

        private static Category hasCategory(string name)
        {
            foreach (Category c in categories)
            {
                if (c.getName() == name)
                {
                    Category category = c;
                    return c;
                }
                return null;
            }

            return null;
        }
    }
}

