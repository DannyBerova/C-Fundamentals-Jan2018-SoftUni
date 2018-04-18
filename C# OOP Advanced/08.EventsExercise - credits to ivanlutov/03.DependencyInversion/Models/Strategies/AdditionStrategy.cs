namespace _03DependencyInversion
{
    using _03.DependencyInversion.Contracts;
    class AdditionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}
