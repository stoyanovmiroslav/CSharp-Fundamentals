using System;
using System.Text;

namespace _09.CollectionHierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int removeCount = int.Parse(Console.ReadLine());

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            AddElementsInCollection(addCollection, input);
            AddElementsInCollection(addRemoveCollection, input);
            AddElementsInCollection(myList, input);

            RemoveElemetnInCollection(addRemoveCollection, removeCount);
            RemoveElemetnInCollection(myList, removeCount);
        }

        private static void RemoveElemetnInCollection(IAddRemoveCollection collection, int removeCount)
        {
            StringBuilder stringBuilder = new StringBuilder(); 
            for (int i = 0; i < removeCount; i++)
            {
                string element = collection.RemoveElement();
                stringBuilder.Append($"{element} ");
            }
            Console.WriteLine(stringBuilder);
        }

        private static void AddElementsInCollection(IAddCollection collection, string[] input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                int index = collection.AddElement(input[i]);
                stringBuilder.Append($"{index} ");
            }
            Console.WriteLine(stringBuilder);
        }
    }
}