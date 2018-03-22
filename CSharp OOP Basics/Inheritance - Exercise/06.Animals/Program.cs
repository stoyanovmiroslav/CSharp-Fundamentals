using System;
using System.Collections.Generic;


public class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();
        string input = "";
        while ((input = Console.ReadLine()) != "Beast!")
        {
            try
            {
                ReadAndCreateAnimal(animals, input);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }

    private static void ReadAndCreateAnimal(List<Animal> animals, string input)
    {
        string[] animalData = Console.ReadLine().Split();
        switch (input)
        {
            case "Dog":
                Dog dog = new Dog(animalData[0], int.Parse(animalData[1]), animalData[2]);
                animals.Add(dog);
                break;
            case "Cat":
                Cat cat = new Cat(animalData[0], int.Parse(animalData[1]), animalData[2]);
                animals.Add(cat);
                break;
            case "Frog":
                Frog frog = new Frog(animalData[0], int.Parse(animalData[1]), animalData[2]);
                animals.Add(frog);
                break;
            case "Tomcat":
                Tomcat tomcat = new Tomcat(animalData[0], int.Parse(animalData[1]));
                animals.Add(tomcat);
                break;
            case "Kitten":
                Kitten kitten = new Kitten(animalData[0], int.Parse(animalData[1]));
                animals.Add(kitten);
                break;
            default: throw new ArgumentException("Invalid input!");
        }
    }
}