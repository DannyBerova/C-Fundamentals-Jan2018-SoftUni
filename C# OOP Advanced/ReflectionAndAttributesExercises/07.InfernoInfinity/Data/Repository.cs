using _07.InfernoInfinity.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.InfernoInfinity.Data
{
    public class Repository : IRepository
    {
        private List<IWeapon> weapons;

        public Repository()
        {
            this.weapons = new List<IWeapon>();
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.Add(weapon);
        }

        public IWeapon GetWeapon(string weaponName)
        {
          return  this.weapons.FirstOrDefault(w => w.NameOfWeapon == weaponName);
        }

    }
}
