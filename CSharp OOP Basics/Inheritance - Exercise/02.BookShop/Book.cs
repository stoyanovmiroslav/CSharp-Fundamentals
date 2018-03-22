using System;
using System.Collections.Generic;
using System.Text;


public class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }

    public string Author
    {
        get { return author; }
        set
        {
            string[] splitValue = value.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (splitValue.Length > 1)
            {
                char secondNameFirstLatter = splitValue[1][0];
                if (char.IsDigit(secondNameFirstLatter))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            author = value;
        }
    }

    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }

    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:f2}");

        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }
}