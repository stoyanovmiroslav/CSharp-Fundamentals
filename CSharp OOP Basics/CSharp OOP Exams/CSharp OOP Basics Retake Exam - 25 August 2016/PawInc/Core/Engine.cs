using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private PawIncManager pawIncManager;

    public Engine()
    {
        this.pawIncManager = new PawIncManager();
    }

    public void Start()
    {
        string input;
        while ((input = Console.ReadLine()) != "Paw Paw Pawah")
        {
            string[] splitInput = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

            switch (splitInput[0])
            {
                case "RegisterAdoptionCenter":
                    pawIncManager.RegisterAdoptionCenter(splitInput[1]);
                    break;
                case "RegisterCleansingCenter":
                    pawIncManager.RegisterCleansingCenter(splitInput[1]);
                    break;
                case "RegisterCastrationCenter":
                    pawIncManager.RegisterCastrationCenter(splitInput[1]);
                    break;
                case "RegisterCat":
                    pawIncManager.RegisterCat(splitInput[1], int.Parse(splitInput[2]), int.Parse(splitInput[3]), splitInput[4]);
                    break;
                case "RegisterDog":
                    pawIncManager.RegisterDog(splitInput[1], int.Parse(splitInput[2]), int.Parse(splitInput[3]), splitInput[4]);
                    break;
                case "SendForCleansing":
                    pawIncManager.SendForCleansing(splitInput[1], splitInput[2]);
                    break;
                case "Cleanse":
                    pawIncManager.Cleanse(splitInput[1]);
                    break;
                case "SendForCastration":
                    pawIncManager.SendForCastration(splitInput[1], splitInput[2]);
                    break;
                case "Castrate":
                    pawIncManager.Castrate(splitInput[1]);
                    break;
                case "CastrationStatistics":
                    pawIncManager.CastrationStatistics();
                    break;
                case "Adopt":
                    pawIncManager.Adopt(splitInput[1]);
                    break;
            }
        }
        Console.WriteLine(pawIncManager);
    }
}