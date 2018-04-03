using System.Reflection;

namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var typeClass = typeof(BlackBoxInteger);
            var instance = (BlackBoxInteger)Activator.CreateInstance(typeClass, true);
            var innerValue = typeClass.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First(m => m.Name == "innerValue");

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandArgs = input.Split("_");
                string command = commandArgs[0];
                int currentValue = int.Parse(commandArgs[1]);

                var metod = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(m => m.Name == command);

                metod.Invoke(instance, new object[] { currentValue });
                Console.WriteLine(innerValue.GetValue(instance));
            }
        }
    }
}
