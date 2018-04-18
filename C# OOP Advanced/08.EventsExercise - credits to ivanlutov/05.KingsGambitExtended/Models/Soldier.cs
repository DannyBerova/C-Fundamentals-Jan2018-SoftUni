﻿namespace _02.KingsGambit.Models
{
    using System;
    using _05.KingsGambitExtended;
    using _05.KingsGambitExtended.Contracts;

    public abstract class Soldier : INameble
    {
        private readonly King kingDefended;
        private int hitsTaken;

        protected Soldier(string name, int hitsTaken, King kingToDefend)
        {
            this.Name = name;
            this.hitsTaken = hitsTaken;
            this.kingDefended = kingToDefend;
        }

        public event EventHandler<KillEventArgs> SoldierKilled;

        public string Name { get; }

        public abstract void OnKingBeingAttacked(object source, EventArgs args);

        public void TakeAttack()
        {
            this.hitsTaken--;

            if (this.hitsTaken <= 0)
            {
                this.OnSoldierKilled();
            }
        }

        protected virtual void OnSoldierKilled()
        {
            if (this.SoldierKilled != null)
            {
                this.SoldierKilled(this, new KillEventArgs(this, this.kingDefended));
            }
        }
    }
}