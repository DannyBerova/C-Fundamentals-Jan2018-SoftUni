public interface IEntity
{
    int Id { get; }

    double Durability { get; }

    double Produce();

    void Broke();
}