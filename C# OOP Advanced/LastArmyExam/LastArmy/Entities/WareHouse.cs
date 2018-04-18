using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private readonly IAmmunitionFactory ammunitionFactory;

    public WareHouse()
        : this(new AmmunitionFactory())
    {
    }

    public WareHouse(IAmmunitionFactory ammunitionFactory)
    {
        this.ammunitionFactory = ammunitionFactory;
        this.Amunitions = new List<IAmmunition>();
    }

    public IList<IAmmunition> Amunitions { get; set; }

    public void AddAmmunitions(string name, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            this.Amunitions.Add(this.ammunitionFactory.CreateAmmunition(name));
        }
    }

    public void EquipArmy(IArmy army)
    {
        foreach (ISoldier soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        bool isEquiped = true;

        List<string> missingAmmunitions = soldier.Weapons.Where(w => w.Value == null).Select(w => w.Key).ToList();

        foreach (var missingWeapon in missingAmmunitions)
        {
            foreach (var ammunition in this.Amunitions)
            {
                if (missingWeapon == ammunition.Name)
                {
                    var weapon = this.Amunitions.FirstOrDefault(w => w.Name == missingWeapon);
                    soldier.Weapons[missingWeapon] = weapon;
                    this.Amunitions.Remove(weapon);
                    break;
                }
                else
                {
                    isEquiped = false;
                }
            }
        }

        return isEquiped;
    }
}