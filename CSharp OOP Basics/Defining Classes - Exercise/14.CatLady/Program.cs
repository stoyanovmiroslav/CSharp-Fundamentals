using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.CatLady
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat();
            string input = "";

            while ((input = Console.ReadLine()) != "End")
            {
                string[] catInfo = input.Split();
                string breed = catInfo[0];

                switch (breed)
                {
                    case "Siamese":
                        Siamese siamese = new Siamese(catInfo[1], double.Parse(catInfo[2]));
                        cat.Siamese.Add(siamese);
                        break;
                    case "Cymric":
                        Cymric cymric = new Cymric(catInfo[1], double.Parse(catInfo[2]));
                        cat.Cymric.Add(cymric);
                        break;
                    case "StreetExtraordinaire":
                        StreetExtraordinaire streetExtraordinaire = new StreetExtraordinaire(catInfo[1], double.Parse(catInfo[2]));
                        cat.StreetExtraordinaire.Add(streetExtraordinaire);
                        break;
                }
            }

            string printCat = Console.ReadLine();
            PrintOutput(cat, printCat);
        }

        private static void PrintOutput(Cat cat, string printCat)
        {
            if (cat.StreetExtraordinaire.Any(c => c.Name == printCat))
            {
                var streetExtraordinaire = cat.StreetExtraordinaire.First(x => x.Name == printCat);
                Console.WriteLine(streetExtraordinaire);
            }
            else if (cat.Siamese.Any(c => c.Name == printCat))
            {
                var siamese = cat.Siamese.First(x => x.Name == printCat);
                Console.WriteLine(siamese);
            }
            else if (cat.Cymric.Any(c => c.Name == printCat))
            {
                var cymric = cat.Cymric.First(x => x.Name == printCat);
                Console.WriteLine(cymric);
            }
        }
    }
}
