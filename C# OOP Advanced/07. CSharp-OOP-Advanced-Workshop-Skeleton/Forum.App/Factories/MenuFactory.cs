using System;
using System.Linq;
using System.Reflection;
using Forum.App.Contracts;

namespace Forum.App.Factories
{
    class MenuFactory : IMenuFactory
    {
        private IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMenu CreateMenu(string menuName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type menuType = assembly.GetTypes().FirstOrDefault(t => t.Name == menuName);

            if (menuType == null)
            {
                throw new InvalidOperationException("Menu not found!");
            }
            if (!typeof(IMenu).IsAssignableFrom(menuType)) //check .IsAssignableFrom
            {
                throw new InvalidOperationException($"{menuName} is not a menu!");
            }

            ParameterInfo[] ctorParams = menuType.GetConstructors().First().GetParameters();
            object[] args = new object[ctorParams.Length];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
            }

            IMenu menu = (IMenu)Activator.CreateInstance(menuType, args);
            return menu;
        }
    }
}
