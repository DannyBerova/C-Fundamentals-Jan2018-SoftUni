using DungeonsAndCodeWizards.Models;
using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
   public class CharacterFactory
    {
        public Character CreateCharacter(string factionInput, string givenType, string name)
        {
            if (factionInput != "CSharp" && factionInput != "Java")
            {
                throw new ArgumentException($"Invalid faction \"{factionInput}\"!");
            }

            Faction faction = (Faction)Enum.Parse(typeof(Faction), factionInput);

            switch (givenType)
            {
                case "Warrior":
                    return new Warrior(name, faction);
                case "Cleric":
                    return new Cleric(name, faction);
                default:
                    throw new ArgumentException($"Invalid character type \"{givenType}\"!");
            }
        }
    }
}
