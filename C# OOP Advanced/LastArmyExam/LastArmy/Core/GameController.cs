using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class GameController : IGameController
{
    private readonly IMissionController missionController;
    private readonly ISoldierFactory soldierFactory;
    private readonly IMissionFactory missionFactory;
    private readonly IWriter writer;
    private readonly IWareHouse wareHouse;
    private readonly IArmy army;

    public GameController(IMissionController missionController, ISoldierFactory soldierFactory, IMissionFactory missionFactory,
        IWriter writer, IWareHouse wareHouse, IArmy army)
    {
        this.missionController = missionController;
        this.soldierFactory = soldierFactory;
        this.missionFactory = missionFactory;
        this.wareHouse = wareHouse;
        this.writer = writer;
        this.army = army;
    }

    public void ProcessCommand(string input)
    {
        var arguments = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        var cmd = arguments[0];
        arguments.RemoveAt(0);

        switch (cmd)
        {
            case "Soldier":
                ParseSoldierCommand(arguments);
                break;

            case "WareHouse":
                AddAmmunitionsToWareHouse(arguments);
                break;

            case "Mission":
                TryMissionPerformance(arguments);
                break;
        }
    }

    private void ParseSoldierCommand(IList<string> arguments)
    {
        if (arguments.Count == 5)
        {
            this.AddSoldierToArmy(arguments);
        }
        else
        {
            this.RegenerateTeam(arguments[1]);
        }
    }

    private void TryMissionPerformance(List<string> arguments)
    {
        var type = arguments[0];
        var scoreToComplete = double.Parse(arguments[1]);

        var mission = this.missionFactory.CreateMission(type, scoreToComplete);
        this.writer.StoreMessage(this.missionController.PerformMission(mission));
    }

    private void AddAmmunitionsToWareHouse(IList<string> arguments)
    {
        var name = arguments[0];
        var quantity = int.Parse(arguments[1]);

        this.wareHouse.AddAmmunitions(name, quantity);
    }

    private void RegenerateTeam(string soldierType)
    {
        this.army.RegenerateTeam(soldierType);
    }

    private void AddSoldierToArmy(IList<string> arguments)
    {
        var type = arguments[0];
        var name = arguments[1];
        var age = int.Parse(arguments[2]);
        var experience = double.Parse(arguments[3]);
        var endurance = double.Parse(arguments[4]);

        var soldier = soldierFactory.CreateSoldier(type, name, age, experience, endurance);

        var listOfRequiredWeapons = (List<string>)soldier.GetType().GetProperty("WeaponsAllowed", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(soldier);
        var countOfRequiredWeapons = 0;

        var ammunitionsInWareHouse = (List<IAmmunition>)this.wareHouse.GetType().GetProperty("Amunitions").GetValue(this.wareHouse);

        foreach (var requiredWeapon in listOfRequiredWeapons)
        {
            foreach (var ammunition in ammunitionsInWareHouse)
            {
                if (requiredWeapon == ammunition.Name)
                {
                    countOfRequiredWeapons++;
                    break;
                }
            }
        }

        if (countOfRequiredWeapons != listOfRequiredWeapons.Count)
        {
            throw new ArgumentException(string.Format(OutputMessages.NoWeaponsForSoldierType, type, name));
        }

        foreach (var requiredWeapon in listOfRequiredWeapons)
        {
            var weapon = ammunitionsInWareHouse.FirstOrDefault(w => w.Name == requiredWeapon);
            soldier.Weapons[requiredWeapon] = weapon;
            ammunitionsInWareHouse.Remove(weapon);
        }

        this.army.AddSoldier(soldier);
    }

    public void ProduceSummury()
    {
        List<ISoldier> orderedArmy = this.army.Soldiers.OrderByDescending(s => s.OverallSkill).ToList();
        this.missionController.FailMissionsOnHold();

        this.writer.StoreMessage("Results:");
        this.writer.StoreMessage(string.Format(OutputMessages.SuccessfulMissions, this.missionController.SuccessMissionCounter));
        this.writer.StoreMessage(string.Format(OutputMessages.FailedMissions, this.missionController.FailedMissionCounter));
        this.writer.StoreMessage("Soldiers:");
        foreach (var soldier in orderedArmy)
        {
            this.writer.StoreMessage(soldier.ToString());
        }
    }
}