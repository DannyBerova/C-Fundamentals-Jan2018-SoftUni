using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private string model;
    private Engine engine;
    private string weight;
    private string color;

    public Car(string model, Engine engine)
    {
        Model = model;
        Engine = engine;
        Weight = "n/a";
        Color = "n/a";
    }

    public string Model { get => model; set => model = value; }
    public Engine Engine { get => engine; set => engine = value; }
    public string Weight { get => weight; set => weight = value; }
    public string Color { get => color; set => color = value; }

    public override string ToString()
    {
        return $"{Model}:" +
            $"\r\n  {Engine.Model}:" +
            $"\r\n    Power: {Engine.Power}" +
            $"\r\n    Displacement: {Engine.Displacement}" +
            $"\r\n    Efficiency: {Engine.Efficiency}" +
            $"\r\n  Weight: {Weight}" +
            $"\r\n  Color: {Color}";
    }
}