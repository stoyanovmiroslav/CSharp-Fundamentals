﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy
{
    public interface IAddRemoveCollection : IAddCollection
    {
        string RemoveElement();
    }
}
