namespace _Logger.Factories
{
    using _Logger.Interfaces;
    using _Logger.Models.LayoutModels;
    using System;

    public class FactoryLayout
    {
        public ILayout Create(string layoutType)
        {
            if (layoutType == "SimpleLayout")
            {
                return new SimpleLayout();
            }
            else if (layoutType == "XmlLayout")
            {
                return new XmlLayout();
            }

            throw new ArgumentException("Invalid type of Layout!");
        }
    }
}