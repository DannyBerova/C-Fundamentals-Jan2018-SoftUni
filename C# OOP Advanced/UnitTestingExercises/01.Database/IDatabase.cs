namespace _01.Database
{
    public interface IDatabase
    {
        void Add(int element);
        void Remove();
        int[] Fetch();
    }
}
