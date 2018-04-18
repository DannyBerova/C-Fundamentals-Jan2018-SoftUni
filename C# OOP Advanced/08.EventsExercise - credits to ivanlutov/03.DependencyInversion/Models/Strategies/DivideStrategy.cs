namespace _03DependencyInversion
{
    using System;
    using _03.DependencyInversion.Contracts;
    public class DivideStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            if (secondOperand == 0)
            {
                throw new ArgumentException("The divisor cannot be 0!");
            }

            return firstOperand / secondOperand;
        }
    }
}