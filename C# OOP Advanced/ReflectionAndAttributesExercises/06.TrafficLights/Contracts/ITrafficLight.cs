using _06.TrafficLights.Models;

namespace _06.TrafficLights.Contracts
{
    public interface ITrafficLight
    {
        Light Light { get; }

        void ChangeLights();
    }
}
