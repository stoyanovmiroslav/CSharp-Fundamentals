using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader textStream = new StreamReader("../Resource/text.txt"))
            {
                using (StreamReader wordsSream = new StreamReader("../Resource/words.txt"))
                {
                    using (StreamWriter streamWriter = new StreamWriter("../Resource/result.txt"))
                    {
                        var dict = new Dictionary<string, int>();
                        string[] text = textStream.ReadToEnd().ToLower().Split(new char[] { ',', '.', ':', '!', '?', '-', ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                        string[] word = wordsSream.ReadToEnd().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i < word.Length; i++)
                        {
                            int counter = 0;

                            for (int j = 0; j < text.Length; j++)
                            {
                                if (text[j] == word[i])
                                {
                                    counter++;
                                }

                            }
                            dict.Add(word[i], counter);
                        }

                        foreach (var item in dict.OrderByDescending(x => x.Value))
                        {
                            streamWriter.WriteLine("{0} - {1}", item.Key, item.Value);
                        }
                    }
                }
            }
        }
    }
}
