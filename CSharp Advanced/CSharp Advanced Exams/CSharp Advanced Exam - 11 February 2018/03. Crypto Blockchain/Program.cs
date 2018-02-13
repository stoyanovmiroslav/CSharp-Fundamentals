using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Crypto_Blockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string pattern = @"((?<hash>{)|\[)[^{[}\]]*?(?<numbers>[0-9]{3,})[^{[}\]]*?(?(hash)}|])";

            StringBuilder fullText = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                string input = Console.ReadLine();
                fullText.Append(input);
            }

            var maches = Regex.Matches(fullText.ToString(), pattern);
            StringBuilder finalText = new StringBuilder();

            foreach (Match item in maches)
            {
                string numbers = item.Groups["numbers"].ToString();
                int fullMachLenght = item.Length;

                if (numbers.Length % 3 == 0)
                {
                    int startIndex = 0;
                    for (int i = 0; i < numbers.Length / 3; i++)
                    {
                        string currentThreeNumbers = "";
                        string currentNumber = "";
                        for (int j = 0; j < 3; j++)
                        {
                            currentNumber += numbers[j + startIndex].ToString();
                        }
                        startIndex += 3;
                        currentThreeNumbers += currentNumber;
                        int numberTree = int.Parse(currentThreeNumbers);
                        int withouldFullLenght = numberTree - fullMachLenght;
                        string simbol = ((char)withouldFullLenght).ToString();

                        finalText.Append(simbol);
                    }
                }
            }
            Console.WriteLine(finalText);
        }
    }
}
