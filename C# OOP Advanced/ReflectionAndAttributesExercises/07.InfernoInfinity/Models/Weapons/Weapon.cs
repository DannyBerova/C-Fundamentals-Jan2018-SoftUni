namespace _07.InfernoInfinity.Models.Weapons
{
    using System;
    using System.Linq;
    using _07.InfernoInfinity.Contracts;
    using _07.InfernoInfinity.Models.Enums;
    using _07.InfernoInfinity.Core.Commands;

    [WeaponAttribute("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public abstract class Weapon : IWeapon
    {
        public Weapon(string weaponType, string rarity, string name)
        {
            this.WeaponType = (WeaponType)Enum.Parse(typeof(WeaponType), weaponType);
            this.Rarity = (Rarity)Enum.Parse(typeof(Rarity), rarity);
            this.NameOfWeapon = name;
        }

        public string NameOfWeapon { get; protected set; }

        public WeaponType WeaponType { get; protected set; }

        public int MinDamageStat { get; protected set; }

        public int MaxDamageStat { get; protected set; }

        public IGem[] Sockets { get; protected set; }

        public Rarity Rarity { get; protected set; }

        public int Strength { get; protected set; }

        public int Agility { get; protected set; }

        public int Vitality { get; protected set; }

        public void AddGem(int index, IGem gem)
        {
            if (SocketExist(index))
            {
                this.Sockets[index] = gem;
            }
        }

        public void AddRarityBonus()
        {
            int rarityBonus = (int)this.Rarity;
            this.MinDamageStat *= rarityBonus;
            this.MaxDamageStat *= rarityBonus;
        }

        public void RemoveGem(int index)
        {
            if (SocketExist(index) && this.Sockets[index] != null)
            {
                this.Sockets[index] = null;
            }
        }

        private bool SocketExist(int index)
        {
            return (index >= 0 || index < this.Sockets.Length);
        }

        public override string ToString()
        {
            int minDamage = this.MinDamageStat;
            int maxDamage = this.MaxDamageStat;
            int strength = 0;
            int agility = 0;
            int vitality = 0;

            foreach (var gem in this.Sockets.Where(s => s != null))
            {
                minDamage +=gem.AddMinDamageBoost();
                maxDamage += gem.AddMaxDamageBoost();
                strength += gem.StrengthBonus;
                agility += gem.AgilityBonus;
                vitality += gem.VitalityBonus;
            }

            return $"{this.NameOfWeapon}: {minDamage}-{maxDamage} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
        }
    }
}
