namespace _03BarracksFactory
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using _03BarracksFactory.Contracts;
    using _03BarracksFactory.Core;
    using _03BarracksFactory.Core.Factories;
    using _03BarracksFactory.Data;


    public class StartUp
    {
       public static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureSurvices();

            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);

            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureSurvices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IUnitFactory, UnitFactory>();
            services.AddSingleton<IRepository, UnitRepository>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;

        }
    }
}
