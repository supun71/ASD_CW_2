using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace ASD_CW_2
{
    class Program
    {
        private static List<Transaction> transactions = new List<Transaction>();
        private static List<Category> categories = new List<Category>();

        static void Main(string[] args)
        {
            // Add predefine categories
            categories.Add(new Category("Salary",true, 0.0));
            categories.Add(new Category("Foods", false, 0.0));
            categories.Add(new Category("Transport", false, 0.0));
            categories.Add(new Category("Clothes", false, 0.0));

            // Enter Primary Income
            addPrimaryIncome();

            // Display menu options
            menu();
        }

        // Display menu options
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
            Console.WriteLine("8) Track Progress");
            Console.WriteLine("9) Reload");
            Console.WriteLine("10) Exit");

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
                        progress();
                        menu();
                        break;
                    case 9:
                        addRecurringTransactions();
                        menu();
                        break;
                    case 10:
                        Environment.Exit(0); // Exit method
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

        // Add new transaction
        private static void addTransaction()
        {
            try
            {
                Console.Write("Enter transaction amount: ");
                double amount = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter description: ");
                string desc = Console.ReadLine();

                Console.Write("Choose the category:\n");

                // Display categories with id
                foreach (Category c in categories)
                {
                    Console.WriteLine($"{c.getId()}) {c?.getName()}");
                }

                int categoryId = Convert.ToInt32(Console.ReadLine());

                // Check category is exist or not
                if (!categories.Any(category => category.getId().Equals(categoryId)))
                {
                    Console.WriteLine($"Category is not exist");
                    menu();
                }

                // Get category object related id from category list
                Category category = categories.FirstOrDefault(Category => Category.getId().Equals(categoryId));

                Console.Write("Is recurring (true or false): ");
                bool recurring = Convert.ToBoolean(Console.ReadLine());

                // Set date as current date time value
                DateTime date = DateTime.Now;

                // create transaction object
                Transaction t1 = new Transaction(amount, desc, recurring, date, category);

                // update the budget balance if category type is expense
                if (!category.getType())
                {
                    category.getBudget().setBalance(-amount); // updating the budget balance
                }

                // transaction object added to the list
                transactions.Add(t1);

                Console.WriteLine("Transaction Added Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Add primary income
        private static void addPrimaryIncome()
        {
            try
            {
                Console.Write("Enter Your Primary Income: ");
                double amount = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter description: ");
                string desc = Console.ReadLine();

                // Set date as current date time value
                DateTime date = DateTime.Now;

                // Get category object related id from category list
                Category? category = categories.FirstOrDefault(Category => Category.getName().Equals("Salary"));

                // create transaction object
                Transaction t1 = new Transaction(amount, desc, true, date, category);

                // transaction object added to the list
                transactions.Add(t1);

                Console.WriteLine("Primary Income Added Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Edit existing transaction object
        private static void editTransaction()
        {
            try
            {
                Console.Write("Enter the transaction Id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                // Check transaction is exist or not
                if (!transactions.Any(transaction => transaction.getId().Equals(id)))
                {
                    Console.WriteLine($"Id number {id} not belongs to any transaction");
                    menu();
                }

                // Get transaction object from list
                Transaction transactionObj = transactions.FirstOrDefault(Transaction => Transaction.getId() == id);

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

                        // Check category is exist or not
                        if (!categories.Any(category => category.getName().Equals(categoryName)))
                        {
                            Console.WriteLine($"Category {categoryName} is not available");
                        }
                        else
                        {
                            // Update category with given category name
                            transactionObj.setCategory(categories.FirstOrDefault(Category => Category.getName().Equals(categoryName)));

                            Console.WriteLine($"Category change to {categoryName} Successfully");
                        }

                        editTransaction();
                        break;
                    case 2:
                        Console.Write("Enter due-date (yyyy.mm.dd): ");
                        DateTime date = Convert.ToDateTime(Console.ReadLine());

                        // Update transaction date and time
                        transactionObj.setDateTime(date);

                        Console.WriteLine("Transaction Date/Time Updated Successfully");
                        
                        editTransaction();
                        break;
                    case 3:
                        Console.Write("Enter transaction amount: ");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        // Update transaction amount
                        transactionObj.setAmount(amount);

                        // Update budget balance if transaction category is expense
                        if (!transactionObj.getCategory().getType())
                        {
                            transactionObj.getCategory().getBudget().setBalance(-amount); //updating the budget balance
                        }

                        Console.WriteLine("Transaction Amount Updated Successfully");

                        editTransaction();
                        break;
                    case 4:
                        Console.Write("Enter description: ");
                        string desc = Console.ReadLine();

                        // Update transaction description/note
                        transactionObj.setDescription(desc);

                        Console.WriteLine("Transaction Description Updated Successfully");

                        editTransaction();
                        break;
                    case 5:
                        Console.Write("Is recurring (true or false): ");
                        bool recurring = Convert.ToBoolean(Console.ReadLine());

                        // Update transaction recurring status
                        transactionObj.setRecurring(recurring);

                        Console.WriteLine("Transaction Recurring Status Updated Successfully");

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

        // List recent transactions
        private static void listTransaction()
        {
            try
            {
                foreach (Transaction t in transactions)
                {
                    string rec = t.isRecurring() ? "YES" : "NO"; // transaction recurring status true and false values display as yes and no value

                    Console.WriteLine($"T_ID: {t.getId()} \tT_Date & Time: {t.getDate()} \tT_Amount: {t.getAmount()} \tT_Description: {t.getDescription()} \tT_Recurring: {rec} \tT_Category: {t.getCategory().getName()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Delete given transaction
        private static void deleteTransaction()
        {
            try
            {
                Console.Write("Enter the transaction Id you want to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());

                // Check transaction is exist or not
                if (!transactions.Any(transaction => transaction.getId().Equals(id)))
                {
                    Console.WriteLine($"Id number {id} not belongs to any transaction");
                    menu();
                }

                // Get transaction object from list using id
                Transaction transactionObj = transactions.FirstOrDefault(Transaction => Transaction.getId() == id);

                // Update budget balance if transaction category is expense
                if (!transactionObj.getCategory().getType())
                {
                    transactionObj.getCategory().getBudget().setBalance(transactionObj.getAmount());
                }
                
                // Remove transaction object from list
                transactions.Remove(transactionObj);

                Console.WriteLine($"Transaction {id} deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Add new category
        private static void addCategory()
        {
            try
            {
                Console.Write("Enter category name: ");
                string name = Console.ReadLine();

                Console.Write("Enter category type (Income/Expense): ");
                bool type = Console.ReadLine().Equals("Income") ? true : false;

                // Check category is income type
                if (type)
                {
                    // Create new category and set budget as zero
                    Category c1 = new Category(name, type, 0.0);

                    // Add category to list
                    categories.Add(c1);

                }
                else
                {
                    Console.Write("Enter category Budget: ");
                    double amount = Convert.ToDouble(Console.ReadLine());

                    // Check total budget amount is exceed total Income
                    if ((getTotalBudget() + amount) > getTotalIncome())
                    {
                        Console.WriteLine("Total budget amount exceed income");
                    }
                    else
                    {
                        // Create new category and set given budget amount
                        Category c1 = new Category(name, type, amount);
                        categories.Add(c1);
                    }
                    
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Edit existing category
        private static void editCategory()
        {
            try
            {
                Console.Write("Enter the Category Name You Want to Edit: ");
                string cat_Name = Console.ReadLine();

                // Check category is not exist
                if (!categories.Any(category => category.getName().Equals(cat_Name)))
                {
                    Console.WriteLine($"Category {cat_Name} is not available");
                    menu();
                }
                else
                {
                    // Get category object from list
                    Category catObj = categories.FirstOrDefault(Category => Category.getName() == cat_Name);

                    // Change category attributes
                    changeCategory(catObj);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Change category attributes
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

                    // Update category name
                    catObj.setName(catName);

                    Console.WriteLine("Category name updated successfully");

                    changeCategory(catObj);
                    break;
                case 2:
                    Console.Write("Enter the category Type: ");
                    bool catType = Console.ReadLine().Equals("Income") ? true : false; // Convert category type to boolean value

                    // Update category type
                    catObj.setType(catType);

                    Console.WriteLine("Category type updated successfully");

                    changeCategory(catObj);
                    break;
                case 3:
                    Console.Write("Enter New category Budget: ");
                    double catAmount = Convert.ToDouble(Console.ReadLine());

                    // Check total budget amount exceed total income
                    if ((getTotalBudget() + catAmount) > getTotalIncome())
                    {
                        Console.WriteLine("Total Budget Amount Exceeds Total Income");
                    }
                    else
                    {
                        // Update budget amount
                        catObj.getBudget().setAmount(catAmount);

                        Console.WriteLine("Budget Amount updated successfully");
                    }

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

        // List categories
        private static void listCategory()
        {
            try
            {
                double total = 0;

                Console.WriteLine("\nCategories:");
                foreach (Category c in categories)
                {
                    string type = c.getType() ? "Income" : "Expense"; // Display budget type as Income or expense

                    if (!c.getType())
                    {
                        Console.WriteLine($"*C_Name: {c?.getName()}  \tC_Type: {type} \tC_Budget: {c.getBudget().getAmount()} \tC_Balance: {c.getBudget().getBalance()}");
                    }
                    else
                    {
                        Console.WriteLine($"*C_Name: {c?.getName()}  \tC_Type: {type} \t\tC_Budget: N/A \tC_Balance: N/A"); // Display income type category budget balance as N/A
                    }

                    // calculate total budget balance value
                    total += c.getBudget().getBalance();
                }

                Console.WriteLine(total);// Display total budget balance value
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        // Get total income
        private static double getTotalIncome()
        {
            double total = 0.0;
            
            // Calculate total income value
            foreach (Transaction t in transactions)
            {
                if (t.getCategory().getType())
                {
                    total += t.getAmount();
                }
            }

            return total;
        }

        // Get total budget amount
        private static double getTotalBudget()
        {
            double total = 0.0;

            // Calculate total budget amount
            foreach (Category c in categories)
            {
                total += c.getBudget().getAmount();
            }

            return total;
        }

        // Recurring transactions added as new transactions
        private static void addRecurringTransactions()
        {
            try
            {
                List<Transaction> tempTransactions = new List<Transaction>();

                // Get previous month
                DateTime previousMonth = DateTime.Now.AddMinutes(-1); // demo purposes get previous minute instead of previous month

                foreach (Transaction t in transactions)
                {
                    // Get last month recurring transaction
                    if (t.isRecurring() && t.getDate().ToString("g").Equals(previousMonth.ToString("g")))
                    {
                        // Create new transaction object with previous transaction object values except id
                        Transaction t1 = new Transaction(t.getAmount(), t.getDescription(), t.isRecurring(), DateTime.Now, t.getCategory());

                        // Update budget balance if transaction type is expense
                        if (!t.getCategory().getType())
                        {
                            t.getCategory().getBudget().setBalance(-t.getAmount()); // updating budget balance
                        }

                        tempTransactions.Add(t1); // add new transaction object to temp list
                    }
                }

                // Temp list transaction objects added to transaction list
                foreach (Transaction t in tempTransactions)
                {
                    transactions.Add(t);

                    Console.WriteLine("Last recurring transactions added successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Display Progress
        private static void progress()
        {
            try
            {
                double total = 0.0;

                foreach (Category c in categories)
                {
                    if (!c.getType())
                    {
                        Console.WriteLine($"C_Name: {c.getName()}  \tC_Budget: {c.getBudget().getAmount()} \tC_Balance: {c.getBudget().getBalance()}");
                    }
                    // calculate total budget balance value
                    total += c.getBudget().getBalance();
                }

                Console.WriteLine($"Total Budget: {getTotalBudget()}    \tTotal Balance: {total}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

