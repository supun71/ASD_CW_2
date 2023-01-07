﻿using System;
using System.Collections.Generic;

namespace ASD_CW_2
{
    class Program
    {
        private static List<Transaction> transactions = new List<Transaction>();
        private static List<Category> categories = new List<Category>();

        static void Main(string[] args)
        {
            categories.Add(new Category("Salary",true, 0.0));
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
            Console.WriteLine("7) Exit");

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
                listCategory();
                string categoryName = Console.ReadLine();

                Category category = hasCategory(categoryName);

                if (category.Equals(null))
                {
                    Console.WriteLine($"Category {categoryName} is not exist");
                }

                Console.Write("Is recurring (true or false): ");
                bool recurring = Convert.ToBoolean(Console.ReadLine());

                DateTime date = DateTime.Now;

                Transaction t1 = new Transaction(amount, desc, recurring, date, category);

                category.getBudget().setBalance(category.getBudget().getBalance() - amount);

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
                Console.Write("Enter the transaction Id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Transaction transactionObj = transactions.FirstOrDefault(Transaction => Transaction.getId() == id);

                if (transactionObj == null)
                {
                    Console.WriteLine($"Id number {id} not belongs to any transaction");
                }

                transactionObj.getCategory().getBudget().setBalance(transactionObj.getCategory().getBudget().getBalance() + transactionObj.getAmount());

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

        private static void listCategory()
        {
            try
            {
                Console.WriteLine("\nCategories:");
                foreach (Category c in categories)
                {
                    string type = c.getType() ? "Income" : "Expense";
                    if (c.getBudget().getAmount() > 0)
                    {
                        Console.WriteLine($"*{c?.getName()}\t: {type}\t: {c.getBudget().getBalance()}");
                    }
                    else
                    {
                        Console.WriteLine($"*{c?.getName()}\t: {type}\t: N/A");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
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

