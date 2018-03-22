using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private List<string> collection = new List<string>();
        public IReadOnlyCollection<string> Collection => (IReadOnlyCollection<string>)collection;

        public int AddElement(string element)
        {
            int index = 0;
            collection.Insert(index, element);
            return index;
        }

        public string RemoveElement()
        {
            string element = collection[collection.Count - 1];
            collection.RemoveAt(collection.Count - 1);
            return element;
        }
    }
}
