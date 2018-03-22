using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy
{
    public interface IAddCollection
    {
        IReadOnlyCollection<string> Collection { get; }
        int AddElement(string element);
    }
}
