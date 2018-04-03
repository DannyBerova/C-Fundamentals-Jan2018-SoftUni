namespace _07.InfernoInfinity.Core.Commands
{
    using _07.InfernoInfinity.Contracts;
    using _07.InfernoInfinity.Core.Attributes;

    class RemoveCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RemoveCommand(string[] data, IRepository repository) 
            : base(data)
        {
            this.Repository = repository;
        }

        protected IRepository Repository
        {
            get => repository;
            private set => repository = value;
        }

        public override string Execute()
        {
            var weaponName = this.Data[1];
            var index = int.Parse(this.Data[2]);
            var weapon = this.Repository.GetWeapon(weaponName);
            weapon.RemoveGem(index);
            return string.Empty;
        }
    }
}
