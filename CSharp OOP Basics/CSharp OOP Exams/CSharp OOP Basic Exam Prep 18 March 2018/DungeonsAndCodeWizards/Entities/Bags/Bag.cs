using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public abstract class Bag
{
    private int capacity;
    private IReadOnlyCollection<Item> items;
    public int Load => items.Select(x => x.Weight).Sum();

    protected Bag(int capacity)
    {
        this.Capacity = capacity;
        items = new List<Item>();
    }

    private List<Item> listItem => this.Items as List<Item>;

    public Item GetItem(string name)
    {
        if (items.Any() == false)
        {
            throw new InvalidOperationException("Bag is empty!");
        }
        if (items.Any(x => x.GetType().Name == name) == false)
        {
            throw new ArgumentException($"No item with name {name} in bag!"); // Sould be ArgumentException!
        }

        Item item = items.First(x => x.GetType().Name == name);
        listItem.Remove(item);
        return item;
    }

    public void AddItem(Item item)
    {
        if (this.Load + item.Weight > this.Capacity)
        {
            throw new InvalidOperationException("Bag is full!");
        }
       
        listItem.Add(item);
    }

    public IReadOnlyCollection<Item> Items
    {
        get { return items; }
        private set { items = value; }
    }

    public int Capacity
    {
        get { return capacity; }
        protected set { capacity = value; }
    }
}
