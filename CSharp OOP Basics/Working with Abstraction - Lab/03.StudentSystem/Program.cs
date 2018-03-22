using System;


class Program
{
    static void Main(string[] args)
    {
        StudentSystem studentSystem = new StudentSystem();
        string intput = "";

        while ((intput = Console.ReadLine()) != "Exit")
        {
            studentSystem.ParseCommand(intput);
        }
    }
}

