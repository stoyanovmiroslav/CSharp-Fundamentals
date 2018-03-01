using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

            string input = "";
            while ((input = Console.ReadLine()) != "Output")
            {
                AccommodationOfPatients(doctors, departments, input);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                PrintOutput(doctors, departments, input);
            }
        }

        private static void PrintOutput(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string input)
        {
            string[] splitInput = input.Split();

            if (splitInput.Length == 1)
            {
                Console.WriteLine(string.Join("\n", departments[splitInput[0]].Where(x => x.Count > 0).SelectMany(x => x)));
            }
            else if (splitInput.Length == 2 && int.TryParse(splitInput[1], out int staq))
            {
                Console.WriteLine(string.Join("\n", departments[splitInput[0]][staq - 1].OrderBy(x => x)));
            }
            else
            {
                Console.WriteLine(string.Join("\n", doctors[splitInput[0] + splitInput[1]].OrderBy(x => x)));
            }
        }

        private static void AccommodationOfPatients(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string input)
        {
            string[] splitInput = input.Split();
            string departament = splitInput[0];
            string patient = splitInput[3];
            string doctor = $"{splitInput[1]}{splitInput[2]}";

            if (!doctors.ContainsKey(doctor))
            {
                doctors[doctor] = new List<string>();
            }
            if (!departments.ContainsKey(departament))
            {
                departments[departament] = new List<List<string>>();
                for (int rooms = 0; rooms < 20; rooms++)
                {
                    departments[departament].Add(new List<string>());
                }
            }

            bool IsThereAnyBed = departments[departament].SelectMany(x => x).Count() < 60;
            if (IsThereAnyBed)
            {
                int room = 0;
                doctors[doctor].Add(patient);

                for (int roomBed = 0; roomBed < departments[departament].Count; roomBed++)
                {
                    if (departments[departament][roomBed].Count < 3)
                    {
                        room = roomBed;
                        break;
                    }
                }
                departments[departament][room].Add(patient);
            }
        }
    }
}
