using FestivalManager.Core.IO.Contracts;
using System;

namespace FestivalManager.Core.IO
{
    public class StringReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}