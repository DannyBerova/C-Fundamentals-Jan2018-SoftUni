using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        private bool isAlive;
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.IsAlive = true;
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
        }

        public virtual double RestHealMultiplier => 0.2;


        public Faction Faction
        {
            get { return faction; }
            private set { faction = value; }
        }

        public Bag Bag
        {
            get { return bag; }
            protected set { bag = value; }
        }

        public double AbilityPoints
        {
            get { return abilityPoints; }
            private set { abilityPoints = value; }
        }

        public double Armor
        {
            get { return armor; }
            private set
            {
                if (value <= 0)
                {
                    this.armor = 0;
                }
                else if (value > baseArmor)
                {
                    this.armor = baseArmor;
                }
                else
                {
                    this.armor = value;
                }
            }
        }

        public double BaseArmor
        {
            get { return baseArmor; }
            private set { baseArmor = value; }
        }

        public double Health
        {
            get { return health; }
            private set
            {
                if (value <= 0)
                {
                    this.health = 0;
                    this.IsAlive = false;
                }
                else if (value >= baseHealth)
                {
                    this.health = baseHealth;
                }
                else
                {
                    this.health = value;
                }
            }
        }

        public double BaseHealth
        {
            get { return baseHealth; }
            private set { baseHealth = value; }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            private set { isAlive = value; }
        }

        public void TakeDamage(double hitPoints)
        {
            this.IsCapableForAction();

            if (hitPoints > this.armor)
            {
                hitPoints -= this.Armor;
                this.Armor = 0;
                if (hitPoints >= this.Health)
                {
                    //this.DecreaseHealth(hitPoints);
                    this.Health = 0;
                    this.IsAlive = false;
                }
                else
                {
                    this.DecreaseHealth(hitPoints);
                }
            }
            else
            {
                this.Armor -= hitPoints;
            }

        }

        public void Rest()
        {
            this.IsCapableForAction();

            this.Health = Math.Min(this.Health + this.BaseHealth * RestHealMultiplier, this.BaseHealth);
        }

        public void UseItem(Item item)
        {
            this.IsCapableForAction();

            item.AffectCharacter(this);

        }

        public void UseItemOn(Item item, Character character)
        {
            this.IsCapableForAction();

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            this.IsCapableForAction();

            character.Bag.AddItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.IsCapableForAction();

            this.Bag.AddItem(item);

        }

        public void IncreaseHealth(double amount)
        {
            this.Health += Math.Min(amount, this.BaseHealth);
        }

        public void DecreaseHealth(double amount)
        {
            this.Health -= amount;
        }

        public void RestoreArmor()
        {
            this.Armor = this.BaseArmor;
        }

        public void GetDead()
        {
            this.isAlive = false;
        }

        protected void IsCapableForAction()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public override string ToString()
        {
            var status = string.Empty;
            if (isAlive)
            {
                status = "Alive";
            }
            else
            {
                status = "Dead";
            }
            return $"{name} - HP: {health}/{baseHealth}, AP: {armor}/{baseArmor}, Status: {status}";
        }
    }
}
