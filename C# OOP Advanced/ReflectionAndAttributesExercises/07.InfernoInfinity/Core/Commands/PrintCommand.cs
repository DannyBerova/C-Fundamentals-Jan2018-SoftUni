namespace _07.InfernoInfinity.Core.Commands
{
    using _07.InfernoInfinity.Contracts;
    using _07.InfernoInfinity.Core.Attributes;

    class PrintCommand : Command
    {
        [Inject]
        private IRepository repository;

        public PrintCommand(string[] data, IRepository repository) 
            : base(data)
        {
            this.Repository = repository;
        }

        public IRepository Repository
        {
            get => this.repository;
            private set => this.repository = value;
        }

        public override string Execute()
        {
            var weaponName = this.Data[1];
            var weapon = this.Repository.GetWeapon(weaponName);

            return weapon.ToString();
        }

    }
}
