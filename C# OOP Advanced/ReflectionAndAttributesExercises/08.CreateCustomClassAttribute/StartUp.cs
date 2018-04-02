using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CreateCustomClassAttribute
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var testAttribute = typeof(Weapon);
            var atr = testAttribute.GetCustomAttributes(false).FirstOrDefault();
            WeaponAttribute a = (WeaponAttribute)atr;

            while (input != "END")
            {
                Console.WriteLine(a.PrintInfo(input));

                input = Console.ReadLine();
            }
        }
    }
}
