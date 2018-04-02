namespace _07.InfernoInfinity.Core.Commands
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using _07.InfernoInfinity.Contracts;

    class PrintCommand : Command
    {
        private readonly IServiceProvider serviceProvider;

        public PrintCommand(IServiceProvider serviceProvider, string[] data) 
            : base(serviceProvider, data)
        {
            this.serviceProvider = serviceProvider;
        }

        public override string Execute()
        {
            var repo = serviceProvider.GetService<IRepository>();

            IWeapon weapon = GetWeaponToPrint(repo);
            return weapon.ToString();
        }

        private IWeapon GetWeaponToPrint(IRepository repo)
        {
            var weaponName = this.Data[1];
            var weapon = repo.GetWeapon(weaponName);
            return weapon;
        }
    }
}
