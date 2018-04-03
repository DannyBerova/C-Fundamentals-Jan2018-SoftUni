namespace _07.InfernoInfinity.Core.Commands
{
    using System.Linq;
    using _07.InfernoInfinity.Contracts;
    using _07.InfernoInfinity.Core.Attributes;

    public class AddCommand : Command
    {
        [Inject]
        private IGemFactory gemFactory;
        [Inject]
        private IRepository repository;

        public AddCommand(string[] data, IGemFactory gemFactory, IRepository repository)
            : base(data)
        {
            this.GemFactory = gemFactory;
            this.Repository = repository;
        }

        protected IRepository Repository
        {
            get => repository;
            private set => repository = value;
        }

        protected IGemFactory GemFactory
        {
            get => gemFactory;
            private set => gemFactory = value;
        }

        public override string Execute()
        {
            string nameOfWeapon = this.Data[1];
            int index = int.Parse(this.Data[2]);

            string claryty = this.Data[3].Split().First();
            string gemType = this.Data[3].Split().Last();
            IGem gemToAdd = this.GemFactory.Create(gemType, claryty);

            var weapon = this.Repository.GetWeapon(nameOfWeapon);
            weapon.AddGem(index, gemToAdd);

            return string.Empty;
        }
    }
}
