namespace _03.DependencyInversion.Contracts
{
    public interface IStrategy
    {
        int Calculate(int firstOperand, int secondOperand);
    }
}