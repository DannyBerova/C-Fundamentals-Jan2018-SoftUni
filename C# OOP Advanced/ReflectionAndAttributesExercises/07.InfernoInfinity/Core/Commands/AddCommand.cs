using _07.InfernoInfinity.Contracts;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace _07.InfernoInfinity.Core.Commands
{
   public class AddCommand : Command
    {
        private readonly IServiceProvider serviceProvider;


        public AddCommand(IServiceProvider serviceProvider, string[] data) 
            : base(serviceProvider, data)
        {
            this.serviceProvider = serviceProvider;
        }

        public override string Execute()
        {
            var gemFactory = serviceProvider.GetService<IGemFactory>();
            var repo = serviceProvider.GetService<IRepository>();
            AddNewGem(gemFactory, repo);
            return string.Empty;
        }

        private void AddNewGem(IGemFactory gemFactory, IRepository repo)
        {
            string nameOfWeapon = this.Data[1];
            int index = int.Parse(this.Data[2]);
            string claryty = this.Data[3].Split().First();
            string gemType = this.Data[3].Split().Last();
            IGem gemToAdd = gemFactory.Create(gemType, claryty);
            var weapon = repo.GetWeapon(nameOfWeapon);
            weapon.AddGem(index, gemToAdd);
        }
    }
}
