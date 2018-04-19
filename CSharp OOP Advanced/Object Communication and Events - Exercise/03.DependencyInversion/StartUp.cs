using System;
using P03_DependencyInversion;
using _03.DependencyInversion.Core;

namespace _03.DependencyInversion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            PrimitiveCalculator primitiveCalculator = new PrimitiveCalculator(new AdditionStrategy());

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandArgs = input.Split();

                if (commandArgs[0] == "mode")
                {
                    char @operator = commandArgs[1][0];

                    switch (@operator)
                    {
                        case '+':
                            primitiveCalculator.changeStrategy(new AdditionStrategy());
                            break;
                        case '-':
                            primitiveCalculator.changeStrategy(new SubtractionStrategy());
                            break;
                        case '*':
                            primitiveCalculator.changeStrategy(new MultiplicationStrategy());
                            break;
                        case '/':
                            primitiveCalculator.changeStrategy(new DivisionStrategy());
                            break;
                    }
                }
                else
                {
                    int firstNumber = int.Parse(commandArgs[0]);
                    int secondNumber = int.Parse(commandArgs[1]);

                    int result = primitiveCalculator.performCalculation(firstNumber, secondNumber);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
