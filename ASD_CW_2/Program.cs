using System;
using System.Collections.Generic;
using System.Linq;

namespace ASD_CW_2
{
    class Program
    {
        private static List<Transaction> transactions = new List<Transaction>();
        private static List<Category> categories = new List<Category>();

        static void Main(string[] args)
        {
            categories.Add(new Category("Salary",true, 0.0));
            categories.Add(new Category("Foods", false, 0.0));
            categories.Add(new Category("Transport", false, 0.0));
            categories.Add(new Category("Clothes", false, 0.0));
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
            Console.WriteLine("6) Edit Category");
            Console.WriteLine("7) List Category");
            Console.WriteLine("8) Exit");

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
                        editCategory();
                        menu();
                        break;
                    case 7:
                        listCategory();
                        menu();
                        break;
                    case 8:
                        Environment.Exit(0);
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
            try
            {
                Console.Write("Enter transaction amount: ");
                double amount = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter description: ");
                string desc = Console.ReadLine();

                Console.Write("Choose the category:\n");

                foreach (Category c in categories)
                {
                    Console.WriteLine($"{c.getId()}) {c?.getName()}");
                }

                int categoryId = Convert.ToInt32(Console.ReadLine());

                if (!categories.Any(category => category.getId().Equals(categoryId)))
                {
                    Console.WriteLine($"Category is not exist");
                    menu();
                }

                Category? category = categories.FirstOrDefault(Category => Category.getId().Equals(categoryId));

                Console.Write("Is recurring (true or false): ");
                bool recurring = Convert.ToBoolean(Console.ReadLine());

                DateTime date = DateTime.Now;

                Transaction t1 = new Transaction(amount, desc, recurring, date, category);

                if (!category.getType())
                {
                    //category.getBudget().setBalance(category.getBudget().getBalance() - amount);
                    category.getBudget().setBalance(-amount); //=================================================updating the budget balance===========================
                }

                transactions.Add(t1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void editTransaction()
        {
            try
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

                int userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        Console.Write("Enter category: ");
                        string categoryName = Console.ReadLine();

                        if (!categories.Any(category => category.getName().Equals(categoryName)))
                        {
                            Console.WriteLine($"Category {categoryName} is not available");
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
            try
            {
                foreach (Transaction t in transactions)
                {
                    string rec = t.isRecurring() ? "YES" : "NO";
                    Console.WriteLine($"T_ID: {t.getId()} \tT_Date & Time: {t.getDate()} \tT_Amount: {t.getAmount()} \tT_Description: {t.getDescription()} \tT_Recurring: {rec} \tT_Category: {t.getCategory().getName()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void deleteTransaction()
        {
            try
            {
                Console.Write("Enter the transaction Id you want to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Transaction transactionObj = transactions.FirstOrDefault(Transaction => Transaction.getId() == id);

                if (transactionObj == null)
                {
                    Console.WriteLine($"Id number {id} not belongs to any transaction");
                }

                //transactionObj.getCategory().getBudget().setBalance(transactionObj.getCategory().getBudget().getBalance() + transactionObj.getAmount());
                if (!transactionObj.getCategory().getType())
                {
                    transactionObj.getCategory().getBudget().setBalance(transactionObj.getAmount());
                }
                
                transactions.Remove(transactionObj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void addCategory()
        {
            try
            {
                Console.Write("Enter category name: ");
                string name = Console.ReadLine();
                Console.Write("Enter category type (Income/Expense): ");
                bool type = Console.ReadLine().Equals("Income") ? true : false;
                if (type)
                {
                    Category c1 = new Category(name, type, 0.0);
                    categories.Add(c1);

                }
                else
                {
                    Console.Write("Enter category Budget: ");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    Category c1 = new Category(name, type, amount);
                    categories.Add(c1);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static void editCategory()
        {
            try
            {
                Console.Write("Enter the Category Name You Want to Edit: ");
                string cat_ID = Console.ReadLine();

                Category catObj = categories.FirstOrDefault(Category => Category.getName() == cat_ID);

                if (catObj == null)
                {
                    Console.WriteLine($"Id number {cat_ID} not belongs to any transaction");
                }

                changeCategory(catObj);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void changeCategory(Category catObj)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Change Category Name");
            Console.WriteLine("2) Change Type");
            Console.WriteLine("3) Edit Budget");
            Console.WriteLine("4) Back to Menu");

            Console.Write("Select an option: ");

            int userInput = Convert.ToInt32(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    Console.Write("Enter New Category Name: ");
                    string catName = Console.ReadLine();

                    catObj.setName(catName);
                    changeCategory(catObj);
                    break;
                case 2:
                    Console.Write("Enter the category Type: ");
                    //string categoryType = Console.ReadLine();
                    bool catType = Console.ReadLine().Equals("Income") ? true : false;
                    catObj.setType(catType);
                    changeCategory(catObj);
                    break;
                case 3:
                    Console.Write("Enter New category Budget: ");
                    double catAmount = Convert.ToDouble(Console.ReadLine());
                    catObj.getBudget().setAmount(catAmount);
                    changeCategory(catObj);
                    break;
                case 4:
                    menu();
                    break;

                default:
                    Console.WriteLine("");
                    throw new NotImplementedException();
            }

        }


        private static void listCategory()
        {
            double total = 0;
            try
            {
                
                Console.WriteLine("\nCategories:");
                foreach (Category c in categories)
                {
                    string type = c.getType() ? "Income" : "Expense";
                    if (!c.getType())
                    {
                        Console.WriteLine($"*C_Name: {c?.getName()}  \tC_Type: {type} \tC_Budget: {c.getBudget().getAmount()} \tC_Balance: {c.getBudget().getBalance()}");
                    }
                    else
                    {
                        Console.WriteLine($"*C_Name: {c?.getName()}  \tC_Type: {type} \t\tC_Budget: N/A \tC_Balance: N/A");
                    }
                    //--------------------------------------------------------total balance value------------------
                    total += c.getBudget().getBalance();


                    //------------------------------------------------------------------------------
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine(total);//-------------------------------------------------------balance value----------------------------
        }

    }
}

