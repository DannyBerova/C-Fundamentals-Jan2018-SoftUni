using System.Collections.Generic;

namespace _01.CubicArtillery
{
    internal class Bunker
    {
        public Bunker()
        {

        }
        public Bunker(string name)
        {
            this.Name = name;
            this.Weapons = new Queue<int>();
        }
        public string Name { get; set; }
        public int filledCapacity { get; set; }
        public Queue<int> Weapons { get; set; }
    }
}