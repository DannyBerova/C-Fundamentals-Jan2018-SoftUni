using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private const string FullMode = "Full";
    private const string HalfMode = "Half";
    private const string EnergyMode = "Energy";
    private const double FullRatio = 1.0;
    private const double HalfRatio = 0.5;
    private const double EnergyRatio = 0.2;

    private IHarvesterFactory harvesterFactory;
    private IEnergyRepository energyRepository;
    private List<IHarvester> allHarvesters;
    private double oreProduced;
    private string currentMode;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.harvesterFactory = new HarvesterFactory();
        this.energyRepository = energyRepository;
        this.allHarvesters = new List<IHarvester>();
        this.oreProduced = 0;
        this.currentMode = FullMode;
    }

    public IReadOnlyCollection<IEntity> Entities => this.allHarvesters.AsReadOnly();

    public double OreProduced => this.oreProduced;

    //public IReadOnlyCollection<IHarvester> AllHarvesters => this.allHarvesters.AsReadOnly();

    public string ChangeMode(string mode)
    {
        this.currentMode = mode;

        var brokenHarvesters = new List<IHarvester>();
        foreach (var harvester in allHarvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch
            {
                brokenHarvesters.Add(harvester);
            }
        }

        foreach (var entity in brokenHarvesters)
        {
            this.allHarvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChanged, mode);
    }

    public string Produce()
    {
        var neededEnergy = this.CalculateNeededEnergy();

        if (this.energyRepository.EnergyStored < neededEnergy)
        {
            return string.Format(Constants.OreOutputToday, 0);
        }

        this.energyRepository.TakeEnergy(neededEnergy);

        var oreOutput = this.CalculateOreOutput();
        this.oreProduced += oreOutput;

        return string.Format(Constants.OreOutputToday, oreOutput);
    }

    private double CalculateOreOutput()
    {
        var oreOutput = this.allHarvesters.Sum(h => h.OreOutput);

        switch (this.currentMode)
        {
            case HalfMode:
                oreOutput *= HalfRatio;
                break;
            case EnergyMode:
                oreOutput *= EnergyRatio;
                break;
            case FullMode:
                oreOutput *= FullRatio;
                break;
            default:
                break;
        }

        return oreOutput;
    }

    private double CalculateNeededEnergy()
    {
        var neededEnergy = this.allHarvesters.Sum(h => h.EnergyRequirement);

        switch (this.currentMode)
        {
            case HalfMode:
                neededEnergy *= HalfRatio;
                break;
            case EnergyMode:
                neededEnergy *= EnergyRatio;
                break;
            case FullMode:
                neededEnergy *= FullRatio;
                break;
            default:
                break;
        }

        return neededEnergy;
    }

    public string Register(IList<string> args)
    {
        var harvester = this.harvesterFactory.GenerateHarvester(args);

        if (harvester != null)
        {
            this.allHarvesters.Add(harvester);
            return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
        }
        return null;
    }

    public override string ToString()
    {
        return $"Total Mined Plumbus Ore: {this.OreProduced}";
    }
}