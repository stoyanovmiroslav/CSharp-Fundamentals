using System;
using System.IO;
using System.Linq;

namespace _04._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var streamRead = new FileStream("../Resource/copyMe.png", FileMode.Open))
            {
                using (var streamCreate = new FileStream("../Resource/newCopyMe.png", FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];
                        int readBytes = streamRead.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        streamCreate.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
