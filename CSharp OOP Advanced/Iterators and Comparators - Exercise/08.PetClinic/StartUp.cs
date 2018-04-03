using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        int numberOfLines = int.Parse(Console.ReadLine());
        List<Pet> pets = new List<Pet>();
        List<Clinic> clinics = new List<Clinic>();

        for (int i = 0; i < numberOfLines; i++)
        {
            List<string> commandArgs = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = commandArgs[0];

                switch (command)
                {
                    case "Create":
                        Create(commandArgs, pets, clinics);
                        break;
                    case "Add":
                        Clinic currentClinic = clinics.FirstOrDefault(c => c.Name == commandArgs[2]);
                        Pet currentPet = pets.FirstOrDefault(c => c.Name == commandArgs[1]);
                        Console.WriteLine(currentClinic.Add(currentPet));
                        break;
                    case "Release":
                        Clinic currentClinicRelease = clinics.FirstOrDefault(c => c.Name == commandArgs[1]);
                        Console.WriteLine(currentClinicRelease.Release());
                        break;
                    case "HasEmptyRooms":
                        Clinic currentClinicHasRoom = clinics.FirstOrDefault(c => c.Name == commandArgs[1]);
                        Console.WriteLine(currentClinicHasRoom.HasEmptyRooms());
                        break;
                    case "Print":
                        PrintClinicRooms(clinics, commandArgs);
                        break;
                }
         
        }
    }

    private static void Create(List<string> commandArgs, List<Pet> pets, List<Clinic> clinics)
    {
        try
        {
            if (commandArgs[1] == "Pet")
            {
                Pet pet = new Pet(commandArgs[2], int.Parse(commandArgs[3]), commandArgs[4]);
                pets.Add(pet);
            }
            else if (commandArgs[1] == "Clinic")
            {
                Clinic clinic = new Clinic(commandArgs[2], int.Parse(commandArgs[3]));
                clinics.Add(clinic);
            }
        }
        catch (ArgumentException argException)
        {
            Console.WriteLine(argException.Message);
        }
    }

    private static void PrintClinicRooms(List<Clinic> clinics, List<string> commandArgs)
    {
        Clinic currentClinicPrint = clinics.FirstOrDefault(c => c.Name == commandArgs[1]);

        if (commandArgs.Count == 3)
        {
            Console.WriteLine(currentClinicPrint.PrintRoom(int.Parse(commandArgs[2])));
        }
        else
        {
            Console.WriteLine(currentClinicPrint.PrintAllRooms());
        }
    }
}