using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Items
{
     public class PoisonPotion : Item
    {
        public PoisonPotion() : base(5)
        {
        }

        public override string Name => "PoisonPotion";

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            character.DecreaseHealth(20);
            if (character.Health == 0)
            {
                character.GetDead();
            }
        }
    }
}
