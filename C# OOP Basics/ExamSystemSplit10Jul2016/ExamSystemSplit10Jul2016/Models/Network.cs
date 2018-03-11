using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Network
{
    private IDictionary<string, Hardware> hardwareComponents;
    private IDictionary<string, Hardware> theDump;

    public Network()
    {
        this.HardwareComponents = new Dictionary<string, Hardware>();
        this.TheDump = new Dictionary<string, Hardware>();
    }
    public IDictionary<string, Hardware> HardwareComponents
    {
        get { return hardwareComponents; }
        private set { hardwareComponents = value; }
    }

    public IDictionary<string, Hardware> TheDump
    {
        get { return theDump; }
        private set { theDump = value; }
    }

    public void Dump(string hardwareName)
    {
        if (hardwareComponents.ContainsKey(hardwareName))
        {
            var dumpedHardware = hardwareComponents[hardwareName];
            hardwareComponents.Remove(hardwareName);
            theDump.Add(hardwareName, dumpedHardware);
        }
    }

    public void Destroy(string hardwareName)
    {
        if (theDump.ContainsKey(hardwareName))
        {
            theDump.Remove(hardwareName);
        }
    }

    public void Restore(string hardwareName)
    {
        if (theDump.ContainsKey(hardwareName))
        {
            var restoredHardware = theDump[hardwareName];
            theDump.Remove(hardwareName);
            hardwareComponents.Add(hardwareName, restoredHardware);
        }
    }

    public string Analyze()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Analysis");

        var hardwareCount = this.HardwareComponents.Count;
        sb.AppendLine($"Hardware Components: {hardwareCount}");

        var softwareCount = this.HardwareComponents.Sum(c => c.Value.Softwares.Count);
        sb.AppendLine($"Software Components: {softwareCount}");

        var totalOperationalMemoryInUse = this.HardwareComponents.Sum(c => c.Value.OperationalMemoryInUse());
        var maximumMemory = this.HardwareComponents.Sum(c => c.Value.MaxMemory);

        var totalCapacityTaken = this.HardwareComponents.Sum(c => c.Value.CapacityTaken());
        sb.AppendLine($"Total Operational Memory: {totalOperationalMemoryInUse} / {maximumMemory}");

        var maximumCapacity = this.HardwareComponents.Sum(c => c.Value.MaxCapacity);
        sb.AppendLine($"Total Capacity Taken: {totalCapacityTaken} / {maximumCapacity}");

        return sb.ToString().Trim();
    }

    public string DumpAnalyze()
    {
        //        Dump Analysis
        //        Power Hardware Components: { countOfPowerHardwareComponents}
        //        Heavy Hardware Components: { countOfHeavyHardwareComponents}
        //        Express Software Components: { countOfExpressSoftwareComponents}
        //        Light Software Components: { countOfLightSoftwareComponents}
        //        Total Dumped Memory: { totalDumpedMemory}
        //        Total Dumped Capacity: { totalDumpedCapacity}”

        var sb = new StringBuilder();
        sb.AppendLine("Dump Analysis");

        var powerHardwareCount = this.TheDump.Where(h => h.Value is Power).Count();
        sb.AppendLine($"Power Hardware Components: {powerHardwareCount}");

        var heavyHardwareCount = this.TheDump.Where(h => h.Value is Heavy).Count();
        sb.AppendLine($"Heavy Hardware Components: {heavyHardwareCount}");

        var expressSoftwareCount = this.TheDump.Sum(h => h.Value.Softwares.Where(s => s is Express).Count());
        sb.AppendLine($"Express Software Components: {expressSoftwareCount}");

        var lightSoftwareCount = this.TheDump.Sum(h => h.Value.Softwares.Where(s => s is Light).Count());
        sb.AppendLine($"Light Software Components: {lightSoftwareCount}");

        var totalDumpedMemory = this.TheDump.Values.Sum(c => c.OperationalMemoryInUse());
        sb.AppendLine($"Total Dumped Memory: {totalDumpedMemory}");

        var totalDumpedCapacity = this.TheDump.Values.Sum(c => c.CapacityTaken());
        sb.AppendLine($"Total Dumped Capacity: {totalDumpedCapacity}");

        return sb.ToString().Trim();
    }

    public string SystemSplit()
    {
        var orderedHardwares = this.HardwareComponents.Values.OrderByDescending((h => h.Type)).ToList();
        var sb = new StringBuilder();
        foreach (var hardware in orderedHardwares)
        {
            sb.AppendLine($"Hardware Component - {hardware.Name}");

            var expressSoftwares = hardware.Softwares.Where(s => s.Type == "Express");
            sb.AppendLine($"Express Software Components - {expressSoftwares.Count()}");

            var lightSoftwares = hardware.Softwares.Where(s => s.Type == "Light");
            sb.AppendLine($"Light Software Components - {lightSoftwares.Count()}");

            sb.AppendLine($"Memory Usage: {hardware.OperationalMemoryInUse()} / {hardware.MaxMemory}");
            sb.AppendLine($"Capacity Usage: {hardware.CapacityTaken()} / {hardware.MaxCapacity}");
            sb.AppendLine($"Type: {hardware.Type}");

            var result = " None";
            if (hardware.Softwares.Count != 0)
            {
                result = string.Join(",", hardware.Softwares);
            }

            sb.AppendLine($"Software Components:{result}");
        }

        return sb.ToString().Trim();
    }
}

