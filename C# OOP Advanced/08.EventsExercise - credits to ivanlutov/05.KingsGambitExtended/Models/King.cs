namespace _02.KingsGambit.Models
{
    using System;
    using _05.KingsGambitExtended.Contracts;

    public class King : INameble
    {
        public King(string name)
        {
            this.Name = name;
        }

        public event EventHandler BeingAttacked;

        public string Name { get; }

        public void TakeAttack()
        {
            this.OnBeingAttacked();
        }

        protected virtual void OnBeingAttacked()
        {
            Console.WriteLine($"King {this.Name} is under attack!");

            if (this.BeingAttacked != null)
            {
                this.BeingAttacked(this, EventArgs.Empty);
            }
        }
    }
}