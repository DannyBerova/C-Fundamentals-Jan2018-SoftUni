namespace _07.InfernoInfinity.Core.Commands
{
    using System;
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;
    using _07.InfernoInfinity.Contracts;

    public class CreateCommand : Command
    {
        private readonly IServiceProvider serviceProvider;

        public CreateCommand(IServiceProvider serviceProvider, string[] data) 
            : base(serviceProvider, data)
        {
            this.serviceProvider = serviceProvider;
        }

        public override string Execute()
        {
            var weaponFactory = serviceProvider.GetService<IWeaponFactory>();
            var repo = serviceProvider.GetService<IRepository>();
            AddCreatedWeaponToRepo(weaponFactory, repo);
            return string.Empty;
        }

        private void AddCreatedWeaponToRepo(IWeaponFactory weaponFactory, IRepository repo)
        {
            string rarity = this.Data[1].Split().First();
            string weaponType = this.Data[1].Split().Last();
            string name = this.Data[2];
            IWeapon weaponToAdd = weaponFactory.Create(weaponType, rarity, name);
            repo.AddWeapon(weaponToAdd);
        }
    }
}
