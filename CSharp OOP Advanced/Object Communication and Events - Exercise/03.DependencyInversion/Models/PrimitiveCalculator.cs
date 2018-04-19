using _03.DependencyInversion.Contracts;
using _03.DependencyInversion.Core;

namespace P03_DependencyInversion
{
    public class PrimitiveCalculator
    {
        IStrategy strategy;

        public PrimitiveCalculator(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void changeStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public int performCalculation(int firstOperand, int secondOperand)
        {
            int result = strategy.Calculate(firstOperand, secondOperand);
            return result;
        }
    }
}
