using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

public class DraftManager
{

    private ModeType mode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;

    public DraftManager()
    {
        harvesters = new Dictionary<string, Harvester>();
        providers = new Dictionary<string, Provider>();
        this.totalMinedOre = 0;
        this.totalStoredEnergy = 0;
        this.mode = ModeType.Full;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        var typeOfHarvester = arguments[0];
        var id = arguments[1];

        try
        {
            var newHarvester = HarvesterFactory.CreateHarvester(arguments);
            harvesters.Add(id, newHarvester);
        }
        catch (Exception ex)
        {
            return (ex.Message);
        }

        return $"Successfully registered {typeOfHarvester} Harvester - {id}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        var typeOfProvider = arguments[0];
        var id = arguments[1];

        try
        {
            var newProvider = ProviderFactory.CreateProvider(arguments);
            providers.Add(id, newProvider);
        }
        catch (Exception ex)
        {
            return (ex.Message);
        }

        return $"Successfully registered {typeOfProvider} Provider - {id}";
    }

    public string Day()
    {
        double orePerDay = 0;
        double harvestersNeededEnergyPerDay = 0;
        double energyPerDay = providers.Values.Sum(p => p.EnergyOutput);

        totalStoredEnergy += energyPerDay;

        harvestersNeededEnergyPerDay += harvesters.Values.Sum(p => p.EnergyRequirement);

        if (totalStoredEnergy >= harvestersNeededEnergyPerDay)
        {
            if (mode == ModeType.Full)
            {
                orePerDay += harvesters.Values.Sum(p => p.OreOutput);
                totalStoredEnergy -= harvestersNeededEnergyPerDay;
            }
            else if(mode == ModeType.Half)
            {
                orePerDay += harvesters.Values.Sum(p => p.OreOutput * 0.5);
                totalStoredEnergy -= harvestersNeededEnergyPerDay * 0.6;
            }

            totalMinedOre += orePerDay;
        }

        var sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {energyPerDay}");
        sb.AppendLine($"Plumbus Ore Mined: {orePerDay}");
        return sb.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        var modeType = arguments[0];
        this.mode = (ModeType)Enum.Parse(typeof(ModeType), modeType);

        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var searchedId = arguments[0];

        if (harvesters.ContainsKey(searchedId))
        {
            return harvesters[searchedId].ToString();
        }
        else if (providers.ContainsKey(searchedId))
        {
            return providers[searchedId].ToString();
        }
        else
        {
            return $"No element found with id - {searchedId}";
        }
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
        sb.AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString().Trim();
    }
}

