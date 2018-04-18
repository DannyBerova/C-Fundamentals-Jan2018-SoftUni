namespace _05.KingsGambitExtended.Models
{
    using System;
    using _02.KingsGambit.Models;

    public class Footman : Soldier
    {
        private const int DefaultHits = 2;

        public Footman(string name, King kingToDefend)
            : base(name, DefaultHits, kingToDefend)
        {
        }

        public override void OnKingBeingAttacked(object source, EventArgs args)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}