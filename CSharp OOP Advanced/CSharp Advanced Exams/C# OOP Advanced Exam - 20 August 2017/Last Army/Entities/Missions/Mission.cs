using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Mission : IMission
{
    protected Mission(double scoreToComplete)
    {
        this.ScoreToComplete = scoreToComplete;
    }

    public double ScoreToComplete { get; }

    public abstract double EnduranceRequired { get; }

    public abstract double WearLevelDecrement { get; }

    public abstract string Name { get; }
}