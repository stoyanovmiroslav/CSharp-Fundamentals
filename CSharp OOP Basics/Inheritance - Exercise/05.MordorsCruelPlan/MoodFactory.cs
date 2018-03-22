using System;
using System.Collections.Generic;
using System.Text;

public class MoodFactory
{
	public string Mood(int gandalfsHappiness)
    {
        if (gandalfsHappiness < -5) return "Angry";
        else if (gandalfsHappiness >= -5 && gandalfsHappiness <= 0) return "Sad";
        else if (gandalfsHappiness >= 1 && gandalfsHappiness <= 15) return "Happy";
        else return "JavaScript";
    }
}