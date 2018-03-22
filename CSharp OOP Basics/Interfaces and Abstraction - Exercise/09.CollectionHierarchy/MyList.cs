using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy
{
    public class MyList : IMyList
    {
        public int CurrentIndex { get; private set; }
        private List<string> collection = new List<string>();

        public IReadOnlyCollection<string> Collection => (IReadOnlyCollection<string>)collection;

        public int AddElement(string element)
        {
            int index = 0;
            collection.Insert(index, element);
            this.CurrentIndex++;
            return index;
        }

        public string RemoveElement()
        {
            string element = collection[0];
            collection.RemoveAt(0);
            this.CurrentIndex--;
            return element;
        }
    }
}
