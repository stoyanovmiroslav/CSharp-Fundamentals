using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceEachBullet = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> locksInput = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int mainSalary = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(bulletsInput);
            Queue<int> locks = new Queue<int>(locksInput);

            int startingBullets = bullets.Count();
            int countBulletRelolding = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                countBulletRelolding++;

                int currentLock = locks.Peek();
                int currentBullet = bullets.Pop();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (countBulletRelolding % gunBarrel == 0 && bullets.Count() > 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            int priceBullets = priceEachBullet * (startingBullets - bullets.Count);
            int leftSalary = mainSalary - priceBullets;

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${leftSalary}");
            }
        }
    }
}
