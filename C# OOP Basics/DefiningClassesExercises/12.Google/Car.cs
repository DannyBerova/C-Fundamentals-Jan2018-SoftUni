public class Car
{
    private string carModel;
    private int speed;

    public Car(string carModel, int speed)
    {
        this.CarModel = carModel;
        this.Speed = speed;
    }

    public string CarModel { get; set; }
    public int Speed { get; set; }

    public override string ToString()
    {
        return $"{this.CarModel} {this.Speed}";
    }

}
