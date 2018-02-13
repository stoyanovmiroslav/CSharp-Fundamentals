using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var dict = new Dictionary<string, BankAccount>();

        string input = "";

        while ((input = Console.ReadLine()) != "End")
        {

                string[] splitInput = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string command = splitInput[0];

                switch (command)
                {
                    case "Create":
                        Create(dict, splitInput[1]);
                        break;
                    case "Deposit":
                        Deposit(dict, splitInput);
                        break;
                    case "Withdraw":
                        Withdraw(dict, splitInput);
                        break;
                    case "Print":
                        Print(dict, splitInput);
                        break;
                }

            




        }
    }

    private static void Print(Dictionary<string, BankAccount> dict, string[] splitInput)
    {
        string accountId = splitInput[1];
        if (dict.ContainsKey(accountId))
        {
            Console.WriteLine(dict[accountId]);
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Withdraw(Dictionary<string, BankAccount> dict, string[] splitInput)
    {
        string accountId = splitInput[1];
        decimal amount = decimal.Parse(splitInput[2]);

        if (dict.ContainsKey(accountId))  //check
        {
            if (dict[accountId].Balance >= amount)
            {
                dict[accountId].Balance -= amount;
            }
            else
         	{
                Console.WriteLine("Insufficient balance");
            }
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Deposit(Dictionary<string, BankAccount> dict, string[] splitInput)
    {
        string accountId = splitInput[1];
        if (dict.ContainsKey(accountId))
        {
            dict[accountId].Balance += decimal.Parse(splitInput[2]);
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Create(Dictionary<string, BankAccount> dict, string accountId)
    {
        if (!dict.ContainsKey(accountId))
        {
            BankAccount acc = new BankAccount();
            acc.Id = int.Parse(accountId);
            dict.Add(accountId, acc);
        }
        else
        {
            Console.WriteLine("Account already exists");
        }
    }
}

