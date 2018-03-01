using System;

class Program
{
    static void Main(string[] args)
    {
        string[] foodLine = Console.ReadLine().Split();
        int gandalfsHappiness = 0;

        for (int food = 0; food < foodLine.Length; food++)
        {
            gandalfsHappiness = FindFoodAndGetPoints(foodLine, gandalfsHappiness, food);
        }

        MoodFactory moodFactory = new MoodFactory();
        string moodsName = moodFactory.Mood(gandalfsHappiness);

        Console.WriteLine(gandalfsHappiness);
        Console.WriteLine(moodsName);
    }

    private static int FindFoodAndGetPoints(string[] foodLine, int gandalfsHappiness, int food)
    {
        if (Enum.TryParse(typeof(FoodFactory), foodLine[food], true, out _))
        {
            FoodFactory foodFactory = (FoodFactory)Enum.Parse(typeof(FoodFactory), foodLine[food], true);
            gandalfsHappiness += (int)foodFactory;
        }
        else
        {
            gandalfsHappiness -= 1;
        }

        return gandalfsHappiness;
    }
}