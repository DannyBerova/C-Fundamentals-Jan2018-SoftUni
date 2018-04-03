namespace _07.InfernoInfinity.Core.Commands
{
    using System.Linq;
    using _07.InfernoInfinity.Contracts;
    using _07.InfernoInfinity.Core.Attributes;

    public class CreateCommand : Command
    {
        [Inject]
        private IWeaponFactory weaponFactory;
        [Inject]
        private IRepository repository;

        public CreateCommand(string[] data, IWeaponFactory weaponFactory, IRepository repository) 
            : base(data)
        {
            this.WeaponFactory = weaponFactory;
            this.Repository = repository;
        }

        protected IRepository Repository
        {
            get => repository;
            private set => repository = value;
        }

        protected IWeaponFactory WeaponFactory
        {
            get => weaponFactory;
            private set => weaponFactory = value;
        }

        public override string Execute()
        {
            string rarity = this.Data[1].Split().First();
            string weaponType = this.Data[1].Split().Last();
            string name = this.Data[2];
            IWeapon weaponToAdd = this.WeaponFactory.Create(weaponType, rarity, name);

            this.Repository.AddWeapon(weaponToAdd);
            return string.Empty;
        }
    }
}
