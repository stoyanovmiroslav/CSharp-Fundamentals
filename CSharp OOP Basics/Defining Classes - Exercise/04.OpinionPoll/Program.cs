using System;
using System.Linq;

namespace _04.OpinionPoll
{
    class Program
    {
        static void Main(string[] args)
        {
            int members = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < members; i++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person();
                person.Name = name;
                person.Age = age;
                family.AddMember(person);
            }
            var overThirty = family.GetOverThirty();

            foreach (var item in overThirty.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}
