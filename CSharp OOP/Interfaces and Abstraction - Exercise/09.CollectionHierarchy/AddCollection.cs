using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        private ICollection<string> collection = new List<string>();
        public IReadOnlyCollection<string> Collection => (IReadOnlyCollection<string>)collection;

        public int AddElement(string element)
        {
            collection.Add(element);
            return collection.Count - 1;
        }
    }
}