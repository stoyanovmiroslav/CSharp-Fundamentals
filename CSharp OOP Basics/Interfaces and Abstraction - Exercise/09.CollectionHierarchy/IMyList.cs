using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy
{
    public interface IMyList : IAddRemoveCollection
    {
        int CurrentIndex { get; }
    }
}
