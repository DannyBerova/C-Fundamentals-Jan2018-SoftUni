using System;
using _06.TrafficLights.Contracts;

namespace _06.TrafficLights.Models
{
    public class TrafficLight : ITrafficLight
    {
        private Light light;

        public TrafficLight(string light)
        {
            this.Light = (Light)Enum.Parse(typeof(Light), light);
        }

        public Light Light
        {
            get => this.light;
            private set => this.light = value;
        }

        public void ChangeLights()
        {
            this.Light += 1;

            this.Light = (int)this.Light > 2 ? 0 : this.Light;

            //if ((int)this.Light > 2)
            //{
            //    this.Light = 0;
            //}
        }

        public override string ToString()
        {
            return $"{this.Light}";
        }
    }
}
