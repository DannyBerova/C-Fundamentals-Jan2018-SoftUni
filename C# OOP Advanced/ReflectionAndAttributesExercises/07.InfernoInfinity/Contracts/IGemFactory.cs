namespace _07.InfernoInfinity.Contracts
{
    public interface IGemFactory
    {
        IGem Create(string typeOfGem, string clarity);
    }
}
