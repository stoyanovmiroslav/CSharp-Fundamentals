using System;
using System.Text;

namespace _01._Jedi_Meditation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder jediMaster = new StringBuilder();
            StringBuilder JediKnight = new StringBuilder();
            StringBuilder JediPadawan = new StringBuilder();
            StringBuilder slavToshkoThePadawan = new StringBuilder();
            bool masterYoda = false;

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < input.Length; j++)
                {
                    string jedis = input[j][0].ToString();

                    switch (jedis)
                    {
                        case "m":
                            jediMaster.Append(input[j] + " ");
                            break;
                        case "k":
                            JediKnight.Append(input[j] + " ");
                            break;
                        case "p":
                            JediPadawan.Append(input[j] + " ");
                            break;
                        case "t":
                        case "s":
                            slavToshkoThePadawan.Append(input[j] + " ");
                            break;
                        case "y":
                            masterYoda = true;
                            break;

                        default:
                            break;
                    }
                }

            }

            if (!masterYoda)
            {
                Console.WriteLine($"{slavToshkoThePadawan}{jediMaster}{JediKnight}{JediPadawan}");
            }
            else
            {
                Console.WriteLine($"{jediMaster}{JediKnight}{slavToshkoThePadawan}{JediPadawan}");
            }
        }
    }
}
