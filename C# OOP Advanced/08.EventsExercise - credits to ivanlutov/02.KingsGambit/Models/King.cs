namespace _02.KingsGambit.Models
{
    using System;

    public class King
    {
        public event EventHandler UnderAttack;
        public string Name { get; set; }

        public King(string name)
        {
            this.Name = name;
        }

        public void OnUnderAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");

            if (UnderAttack != null)
            {
                UnderAttack(this, new EventArgs());
            }
        }
    }
}