
namespace _07.InfernoInfinity
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using _07.InfernoInfinity.Contracts;
    using _07.InfernoInfinity.Core;
    using _07.InfernoInfinity.Core.Factories;
    using _07.InfernoInfinity.Data;

    public class StartUp
    {
        public static void Main()
        {
            IServiceProvider serviceProvider = ConfigureSurvices();

            IRunnable engine = new Engine( serviceProvider);
            engine.Run();
        }

        private static IServiceProvider ConfigureSurvices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IWeaponFactory, WeaponFactory>();
            services.AddTransient<IGemFactory, GemFactory>();
            services.AddTransient<ICommandInterpreter, CommandInterpreter>();
            services.AddTransient<IReader, Reader>();
            services.AddTransient<IWriter, Writer>();
            services.AddSingleton<IRepository, Repository>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            return serviceProvider;

        }
    }
}
