using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] allPeople = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
        string[] allProducts = Console.ReadLine().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

        List<Person> persons = new List<Person>();
        List<Product> products = new List<Product>();

        for (int i = 0; i < allPeople.Length; i++)
        {
            string[] splitPersonMoney = allPeople[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                Person person = new Person(splitPersonMoney[0], decimal.Parse(splitPersonMoney[1]));
                persons.Add(person);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
                Environment.Exit(0);
            }
        }

        for (int i = 0; i < allProducts.Length; i++)
        {
            string[] splitProductCost = allProducts[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                Product product = new Product(splitProductCost[0], decimal.Parse(splitProductCost[1]));
                products.Add(product);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
                Environment.Exit(0);
            }
        }

        string purchases = "";
        while ((purchases = Console.ReadLine()) != "END")
        {
            string[] namePurchases = purchases.Split(" ");

            var person = persons.First(x => x.Name == namePurchases[0]);
            var product = products.First(x => x.Name == namePurchases[1]);

            if (person.Money >= product.Cost)
            {
                person.Products.Add(product);
                person.Money -= product.Cost;
                Console.WriteLine($"{person.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{person.Name} can't afford {product.Name}");
            }
        }

        foreach (var person in persons)
        {
            if (person.Products.Count > 0)
            {
                Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products)}");
            }
            else
            {
                Console.WriteLine($"{person.Name} - Nothing bought");
            }
        }
    }
}