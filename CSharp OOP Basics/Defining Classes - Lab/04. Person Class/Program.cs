using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        List<BankAccount> myBanckAccounts = new List<BankAccount>();

        for (int i = 0; i < 2; i++)
        {
            BankAccount acc = new BankAccount();
            acc.Id = i;
            acc.Deposit(10 + i);
            myBanckAccounts.Add(acc);
        }

        string personName = "Miro";
        int age = 30;
        Person person = new Person(personName, age, myBanckAccounts);

        Console.WriteLine(person);
    }
}

