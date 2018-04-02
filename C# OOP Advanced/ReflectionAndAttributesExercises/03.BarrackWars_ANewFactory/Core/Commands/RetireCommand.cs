namespace _03BarracksFactory.Core.Commands
{
    using System;
    using _03BarracksFactory.Contracts;

    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RetireCommand(string[] data, IRepository repository) 
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
            var result = string.Empty;
            var unitType = this.Data[1];
            try
            {
                this.Repository.RemoveUnit(unitType);
                result = $"{unitType} retired!";
            }
            catch (Exception ioe)
            {

                throw new InvalidOperationException($"No such units in repository.", ioe);
            }
            return result;
        }
    }
}
