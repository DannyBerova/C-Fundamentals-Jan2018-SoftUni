namespace _05.KingsGambitExtended
{
    using System.Collections.Generic;
    using _02.KingsGambit.Models;
    public class SoldierList : List<Soldier>
    {
        public void OnSoldierKilled(object source, KillEventArgs args)
        {
            args.Soldier.SoldierKilled -= this.OnSoldierKilled;
            args.KingDefended.BeingAttacked -= args.Soldier.OnKingBeingAttacked;
            this.Remove(args.Soldier);
        }
    }
}