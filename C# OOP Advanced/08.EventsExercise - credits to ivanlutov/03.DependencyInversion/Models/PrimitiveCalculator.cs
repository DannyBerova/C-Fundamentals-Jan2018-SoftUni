namespace _03DependencyInversion
{
    using _03.DependencyInversion.Contracts;

    class PrimitiveCalculator
    {
        private IStrategy strategy;

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
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
