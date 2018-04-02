namespace _07.InfernoInfinity.Core.Commands
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using _07.InfernoInfinity.Contracts;

    class RemoveCommand : Command
    {
        private readonly IServiceProvider serviceProvider;

        public RemoveCommand(IServiceProvider serviceProvider, string[] data) 
            : base(serviceProvider, data)
        {
            this.serviceProvider = serviceProvider;
        }

        public override string Execute()
        {
            var repo = serviceProvider.GetService<IRepository>();
            RemoveGemFromWeapon(repo);
            return string.Empty;
        }

        private void RemoveGemFromWeapon(IRepository repo)
        {
            var weaponName = this.Data[1];
            var index = int.Parse(this.Data[2]);
            var weapon = repo.GetWeapon(weaponName);
            weapon.RemoveGem(index);
        }
    }
}
