using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;

        private Dictionary<string, Character> party;
        private List<Item> pool;
        private List<string> possibleItems;
        private int rounds;
        //private List<Character> lastStats;

        public DungeonMaster()
        {
            this.party = new Dictionary<string, Character>();
            this.pool = new List<Item>();
           // lastStats = new List<Character>();
            this.possibleItems = new List<string> { "PoisonPotion", "HealthPotion", "ArmorRepairKit" };
            characterFactory = new CharacterFactory();
            itemFactory = new ItemFactory();
            rounds = 0;
        }

        //public List<Character> LastStats { get; set; }

        public string JoinParty(string[] args)
        {
            var faction = args[0];
            var givenType = args[1];
            var name = args[2];

            Character character = characterFactory.CreateCharacter(faction, givenType, name);
            party.Add(name, character);
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];

            Item item = itemFactory.CreateItem(itemName);
            pool.Add(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];

            CheckIfExists(characterName);
            if (pool.Count == 0)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }
            var character = party[characterName];
            var item = pool.LastOrDefault();

            pool.Remove(item);
            character.ReceiveItem(item);
            return $"{characterName} picked up {item.Name}!";

        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            CheckIfExists(characterName);

            var character = party[characterName];
            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            CheckIfExists(giverName);
            CheckIfExists(receiverName);

            var giver = party[giverName];
            var reciever = party[receiverName];
            var item = giver.Bag.GetItem(itemName);
            giver.UseItemOn(item, reciever);
            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            CheckIfExists(giverName);
            CheckIfExists(receiverName);

            var giver = party[giverName];
            var reciever = party[receiverName];
            var item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, reciever);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var lastStats = party.Values
                .OrderByDescending(c => c.IsAlive)
                .ThenByDescending(c => c.Health)
                .ToList();

            var sb = new StringBuilder();
            foreach (var charac in lastStats)
            {
                sb.AppendLine(charac.ToString().Trim());
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            CheckIfExists(attackerName);
            CheckIfExists(receiverName);

            var attacker = party[attackerName];
            var receiver = party[receiverName];

            if (!(attacker is IAttackable sureAttacker))
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            sureAttacker.Attack(receiver);

            var sb = new StringBuilder();
            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
            if (receiver.IsAlive == false)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            CheckIfExists(healerName);
            CheckIfExists(healingReceiverName);

            var healer = party[healerName];
            var healed = party[healingReceiverName];

            if (!(healer is IHealable sureHealer))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            sureHealer.Heal(healed);

            return $"{healer.Name} heals {healed.Name} for {healer.AbilityPoints}! {healed.Name} has {healed.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            var sortedParty = party.Values
                 .Where(c => c.IsAlive)
                 .ToList();

            var sb = new StringBuilder();

            foreach (var charac in sortedParty)
            {
                var healthBeforeRest = charac.Health;
                charac.Rest();
                sb.AppendLine($"{charac.Name} rests ({healthBeforeRest} => {charac.Health})");
            }

            if (sortedParty.Count < 2)
            {
                this.rounds++;
            }

            return sb.ToString().Trim();
        }

        public bool IsGameOver()
        {
            if ((this.rounds > 1) && (this.party.Values.Count(c => c.IsAlive) <= 1))
            {
                return true;
            }

            return false;
        }

        private void CheckIfExists(string characterName)
        {
            if (!party.ContainsKey(characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
        }

    }
}
