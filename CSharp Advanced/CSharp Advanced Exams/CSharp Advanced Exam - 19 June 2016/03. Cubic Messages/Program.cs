using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._Cubic_Messages
{
    class Program
    {
        static void Main(string[] args)
        {                       
            string input = "";

            while ((input = Console.ReadLine()) != "Over!")
            {
                int messageLength = int.Parse(Console.ReadLine());

                string pattern = @"^(?<firstNUmbers>(?<=)[0-9]+)(?<message>[a-zA-Z]{" + messageLength + @"})(?<secondNimber>(?=)[^A-Za-z\s]*?)$";

                var match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string message = match.Groups["message"].ToString();
                    string firstNumbers = match.Groups["firstNUmbers"].ToString();
                    string secondNimber = match.Groups["secondNimber"].ToString();
                    string verificationCode = TakeVerificationCode(message, firstNumbers, secondNimber);

                    Console.WriteLine($"{message} == {verificationCode}");
                }
            }
        }

        private static string TakeVerificationCode(string message, string firstNumbers, string secondNimber)
        {
            StringBuilder verificationCode = new StringBuilder();

            for (int i = 0; i < firstNumbers.Length; i++)
            {
                if (IsValidNumber(firstNumbers[i], message))
                {
                    int index = int.Parse(firstNumbers[i].ToString());
                    if (index >= 0 && index < message.Length)
                    {
                        string takeVerification = message[index].ToString();
                        verificationCode.Append(takeVerification);
                    }
                    else
                    {
                        verificationCode.Append(" ");
                    }
                }
            }

            for (int i = 0; i < secondNimber.Length; i++)
            {
                if (IsValidNumber(secondNimber[i], message))
                {
                    int index = int.Parse(secondNimber[i].ToString());

                    if (index >= 0 && index < message.Length)
                    {
                        string takeVerification = message[index].ToString();
                        verificationCode.Append(takeVerification);
                    }
                    else
                    {
                        verificationCode.Append(" ");
                    }
                }
            }
            return verificationCode.ToString();
        }

        private static bool IsValidNumber(char v, string message)
        {
            if (Char.IsDigit(v))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
