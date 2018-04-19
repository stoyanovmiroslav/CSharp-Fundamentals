using _03.DependencyInversion.Contracts;

namespace P03_DependencyInversion
{
	public class AdditionStrategy : IStrategy
    {
        public AdditionStrategy()
        {
        }

        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}