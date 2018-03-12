using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NetworkManager
{
    private Network network;
    public NetworkManager()
    {
        this.Network = new Network();
    }

    public Network Network
    {
        get { return this.network; }
        private set { this.network = value; }
    }


    internal void RegisterHeavyHardware(List<string> commandArgs)
    {
        var name = commandArgs[0];
        var capacity = int.Parse(commandArgs[1]);
        var memory = int.Parse(commandArgs[2]);
        var heavyHardware = new Heavy(name, capacity, memory);
        Network.HardwareComponents.Add(name, heavyHardware);
    }

    internal void RegisterPowerHardware(List<string> commandArgs)
    {
        var name = commandArgs[0];
        var capacity = int.Parse(commandArgs[1]);
        var memory = int.Parse(commandArgs[2]);
        var powerHardware = new Power(name, capacity, memory);
        Network.HardwareComponents.Add(name, powerHardware);
    }

    internal void RegisterExpressSoftware(List<string> commandArgs)
    {
        var hardwareName = commandArgs[0];
        var name = commandArgs[1];
        var capacity = int.Parse(commandArgs[2]);
        var memory = int.Parse(commandArgs[3]);
        var expressSoftware = new Express(name, capacity, memory);
        AddSoftwareToTheGivenHardware(hardwareName, expressSoftware);
    }

    internal void RegisterLightSoftware(List<string> commandArgs)
    {
        var hardwareName = commandArgs[0];
        var name = commandArgs[1];
        var capacity = int.Parse(commandArgs[2]);
        var memory = int.Parse(commandArgs[3]);
        var lightSoftware = new Light(name, capacity, memory);

        AddSoftwareToTheGivenHardware(hardwareName, lightSoftware);
    }

    private void AddSoftwareToTheGivenHardware(string hardwareName, Software software)
    {
        if (Network.HardwareComponents.ContainsKey(hardwareName))
        {
            var searchedHardware = Network.HardwareComponents[hardwareName];

            var freeCapacity = searchedHardware.MaxCapacity - searchedHardware.CapacityTaken();
            var freeMemory = searchedHardware.MaxMemory - searchedHardware.OperationalMemoryInUse();

            if (freeCapacity >= software.CapacityConsumption
                && freeMemory >= software.MemoryConsumption)
            {
                searchedHardware.Softwares.Add(software);
            }
        }
    }

    internal void ReleaseSoftwareComponent(List<string> commandArgs)
    {
        var hardwareName = commandArgs[0];
        var softwareName = commandArgs[1];

        if (Network.HardwareComponents.ContainsKey(hardwareName))
        {
            var searchedHardware = Network.HardwareComponents[hardwareName];
            var searchedSoftware = searchedHardware.Softwares.SingleOrDefault(s => s.Name == softwareName);
            if (searchedSoftware != null)
            {
                searchedHardware.Softwares.Remove(searchedSoftware);
            }
        }
    }

    internal void Dump(List<string> commandArgs)
    {
        var hardwareName = commandArgs[0];
        network.Dump(hardwareName);
    }

    internal void Restore(List<string> commandArgs)
    {
        var hardwareName = commandArgs[0];
        network.Restore(hardwareName);
    }

    internal void Destroy(List<string> commandArgs)
    {
        var hardwareName = commandArgs[0];
        network.Destroy(hardwareName);
    }

    internal string Analyze()
    {
        return network.Analyze();
    }

    internal string DumpAnalyze()
    {
        return network.DumpAnalyze();
    }

    internal string SystemSplit()
    {
        return network.SystemSplit();
    }
}

