namespace _02.ExtendedDatabase
{
    public interface IDatabase<IPerson>
    {
        int CurrentIndex { get; }

       // int Count();

        void Add(IPerson element);

        void Remove();

        IPerson FindByUsername(string name);

        IPerson FindById(long id);
    }
}
