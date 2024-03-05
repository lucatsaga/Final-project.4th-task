// See https://aka.ms/new-console-template for more information







    using Final_project._4th_task;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
/*
List<Customer> customers = new List<Customer>();
customers.Add(new Customer("Luka", "Tsagareishvili", "01008048787", "1234", 900));
Customer currentCustomer = new Customer();
Console.WriteLine("Please Enter your Private Number");
string insertPrivNum = Console.ReadLine();
bool isExistingCustomer = customers.Any(c => c.PrivateNumber == insertPrivNum);
if (isExistingCustomer) 
{
   
    currentCustomer.PrivateNumber = insertPrivNum;
if (customers.Contains(currentCustomer))
{
    Console.WriteLine("Hello");
}
else
{
    Console.WriteLine("Bad");
}
*/

class Program
{
    
    private const string FilePath = @"../../../customers.txt";

    static void Main()
    {
        char lastOperation;
        
        

        
            List<Customer> customers = LoadCustomers();
            Customer currentCustomer = new Customer();
            FileLogger fileLogger = new FileLogger();



            Console.WriteLine("Welcome To the Bank");

            Console.WriteLine("Please Enter your Private Number");
            string insertPrivNum = Console.ReadLine();
            Customer existingCustomer = customers.FirstOrDefault(c => c.PrivateNumber == insertPrivNum);
            if (existingCustomer != null)
            {
                string enteredPassword;
                do
                {
                    Console.WriteLine("Enter your password");
                    enteredPassword = Console.ReadLine();
                    if (enteredPassword == existingCustomer.Password)
                    {
                        currentCustomer = existingCustomer;
                        Console.WriteLine($"Login successful! Welcome, {currentCustomer.FirstName} {currentCustomer.LastName}");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Please write the correct one");
                    }
                } while (enteredPassword != existingCustomer.Password);
            }
            else
            {
            currentCustomer.PrivateNumber = insertPrivNum;
            do
            {
                Console.WriteLine("Welcome, you are new member of the Bank");
                Random random = new Random();
                string randomPass = random.Next(1000, 10000).ToString();
                existingCustomer = customers.FirstOrDefault(c => c.Password == randomPass);
                if (existingCustomer == null)
                {
                    Console.WriteLine($"Your password is {randomPass}");
                    currentCustomer.Password = randomPass;
                }
                else
                {

                }
            } while (existingCustomer != null);



            Console.WriteLine("Please Fill you First Name");
                string fName = Console.ReadLine();
                currentCustomer.FirstName = fName;
                Console.WriteLine("Please Fill you Last Name");
                string lName = Console.ReadLine();
                currentCustomer.LastName = lName;
                currentCustomer.Balance = 0;
            
                customers.Add(currentCustomer);
                SaveCustomers(customers);

                Console.WriteLine("Registration successful!");

            }
        do
        {
            Console.WriteLine($"Choose Operation. 1.[B] --> To Check Balance" +
                $"2.[P] --> To Put Money into Account" +
                $"3.[T] --> To Withdraw Money" +
                $"4.[H] --> To See History of Operations ");


            char operation = Convert.ToChar(Console.ReadLine());
            switch (operation)
            {
                case 'B':
                    currentCustomer.CheckBalance();
                    FileLogger.Log($"The balance of ID{currentCustomer.Id}, {currentCustomer.FirstName} {currentCustomer.LastName} is {currentCustomer.Balance}Lari", currentCustomer);
                    break;
                case 'P':
                    Console.WriteLine("Enter Amount, how much you want to put to Balance");
                    int putMoney = Convert.ToInt32(Console.ReadLine());
                    currentCustomer.PutMoney(putMoney);
                    FileLogger.Log($"{currentCustomer.FirstName} {currentCustomer.LastName} have added {putMoney} Lari to his/her account. Existing Balance is {currentCustomer.Balance}Lari", currentCustomer);
                    break;
                case 'T':
                    Console.WriteLine("Enter Amount, how much you want to take from Balance");
                    int takeMoney = Convert.ToInt32(Console.ReadLine());
                    currentCustomer.TakeMoney(takeMoney);
                    FileLogger.Log($"{currentCustomer.FirstName} {currentCustomer.LastName} have withdrawn {takeMoney}Lari from his/her account. Existing Balance is {currentCustomer.Balance}Lari", currentCustomer);
                    break;
                case 'H':
                    currentCustomer.History();
                    
                    break;
            }
            Console.WriteLine("Do you want to Proceed the operation? " +
                "1.[Y] --> Continue" +
                "2.[N] --> Exit");
            lastOperation= Convert.ToChar(Console.ReadLine());
        }while (lastOperation == 'Y');








        /*
        foreach (Customer customer in customers)
        {
            Console.WriteLine($"{customer}");
        }
        */
    }
    static List<Customer> LoadCustomers()
    {
        List<Customer> customers = new List<Customer>();

        try 
        { 
        if (File.Exists(FilePath) && new FileInfo(FilePath).Length > 0)
        {
            string[] lines = File.ReadAllLines(FilePath);
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                if (data.Length >= 6)
                {
                    Customer customer = new Customer();
                    {
                        customer.PrivateNumber = data[0];
                        customer.Password = data[1];
                        customer.FirstName = data[2];
                        customer.LastName = data[3];
                        customer.Balance = decimal.Parse(data[4]);
                        
                    };
                        customer.Id = int.Parse(data[5]) >  Customer.nextId ? int.Parse(data[5]) : Customer.nextId;
                        customers.Add(customer);
                }
                else
                {
                    
                }
            }
        }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading customers: {ex.Message}");
        }
        
        return customers;
    }
    


    static void SaveCustomers(List<Customer> customers)
    {
        List<string> lines = new List<string>();
        foreach (Customer customer in customers)
        {
            string line = $"{customer.PrivateNumber},{customer.Password},{customer.FirstName},{customer.LastName},{customer.Balance},{customer.Id}";
            lines.Add(line);
        }
        File.WriteAllLines(FilePath, lines);
    }
}
















/*
        currentCustomer.PrivateNumber = insertPrivNum;
        char lastOperation;


do
{
    if (customers.Contains(currentCustomer))
    {

        Console.WriteLine($"Welcome {customer1.FirstName} {customer1.LastName}. Please insert your Password");
        string password = Console.ReadLine();
        bool correctPass = (password == customer1.Password);
        string rePass;
        if (!correctPass)
        {
            do
            {
                Console.WriteLine("The password is incorrect. Please write correct password.");
                rePass = Console.ReadLine();
                if (rePass == customer1.Password)
                {
                    Console.WriteLine("You have succesfully logged in.");
                }
            } while (rePass != customer1.Password);
        }
        else
        {
            Console.WriteLine("You have succesfully logged in.");
        }
    }
    else
    {
        Random random = new Random();
        string randomPass = random.Next(1000, 10000).ToString();
        customer1.Password = randomPass;
        Console.WriteLine($"You are our new member. Your password is {customer1.Password}");
        Customer.registeredPrivateNumbers.Add(customer1.PrivateNumber);
        Customer.registeredPasswords.Add(customer1.Password);
        Console.WriteLine("Please Enter Your FirstName");
        string fName = Console.ReadLine();
        customer1.FirstName = fName;
        Console.WriteLine("Please Enter Your LastName");
        string lName = Console.ReadLine();
        customer1.LastName = lName;
        customer1.Balance = 0;
        // CustomerLogger.SaveCustomer(customer1); //wina gzit gaketebuli json

    }
    Console.WriteLine("Please Choose Operation 1.[B] --> To Check Balance  2.[P] --> Put Money onto Balance  3.[T] --> To Take Money out of Balance  4.[H] --> To see History of Operations");
    char operation = Convert.ToChar(Console.ReadLine());

    switch (operation)
    {
        case 'B':
            customer1.CheckBalance();

            FileLogger.Log($"The balance of ID{customer1.Id}, {customer1.FirstName} {customer1.LastName} is {customer1.Balance}Lari", customer1);

            break;
        case 'P':
            Console.WriteLine("Enter Amount, how much you want to put to Balance");
            int putMoney = Convert.ToInt32(Console.ReadLine());
            customer1.PutMoney(putMoney);
            FileLogger.Log($"{customer1.FirstName} {customer1.LastName} have added {putMoney} Lari to his/her account. Existing Balance is {customer1.Balance}Lari", customer1);
            break;
        case 'T':
            Console.WriteLine("Enter Amount, how much you want to take from Balance");
            int takeMoney = Convert.ToInt32(Console.ReadLine());
            customer1.TakeMoney(takeMoney);
            FileLogger.Log($"{customer1.FirstName} {customer1.LastName} have withdrawn {takeMoney}Lari from his/her account. Existing Balance is {customer1.Balance}Lari", customer1);
            break;
        case 'H':
            Console.WriteLine("I have to implement this method afterwards");
            break;



    }

    Console.WriteLine("Do you want to proceed the operations? [Y] --> To Proceed, [N] --> To Close the Bank");
    lastOperation = Convert.ToChar(Console.ReadLine());
} while (lastOperation == 'Y');
*/



