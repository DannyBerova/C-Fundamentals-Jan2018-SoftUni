namespace _07.InfernoInfinity.Core.Commands
{
    using _07.InfernoInfinity.Models.Weapons;
    using System;
    using System.Linq;

    class DescriptionCommand : Command
    {
        private readonly IServiceProvider serviceProvider;

        public DescriptionCommand(IServiceProvider serviceProvider, string[] data) : base(serviceProvider, data)
        {
            this.serviceProvider = serviceProvider;
        }

        public override string Execute()
        {
            var field = this.Data[0];

            var weaponAtr = typeof(Weapon).GetCustomAttributes(false).FirstOrDefault();
            WeaponAttribute fieldToPrint = (WeaponAttribute)weaponAtr;

            var result = fieldToPrint.PrintInfo(field);

            return result;
        }
    }
}
