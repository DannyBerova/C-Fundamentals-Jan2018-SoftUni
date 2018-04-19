using System.Linq;
using NUnit.Framework;

[TestFixture]
public class ProviderControllerTests
{
    private IProviderController controller;
    private IEnergyRepository energyRepository;

    [SetUp]
    public void TestInit()
    {
        this.energyRepository = new EnergyRepository();
        this.controller = new ProviderController(this.energyRepository);
    }

    [Test]
    public void ControllerRegisterProviderValid()
    {
        var argsInput = "Pressure 40 100".Split().ToList();
        this.controller.Register(argsInput);

        var countOfProviders = controller.Entities.Count;

        Assert.AreEqual(1, countOfProviders, "Count of registered providers is not corect!");
    }

    [Test]
    public void ControllerProduceProviderValid()
    {
        var argsInput = "Pressure 40 100".Split().ToList();
        var argsInput2 = "Solar 80 100".Split().ToList();

        this.controller.Register(argsInput);
        this.controller.Register(argsInput2);
        this.controller.Produce();

        var actual = this.controller.TotalEnergyProduced;

        Assert.AreEqual(300, actual, "Total Energy Produced is not corect!");
    }

    [Test]
    public void ControllerProduceMethodRemovesBrokenProviders()
    {
        this.controller.Register("Pressure 40 100".Split().ToList());
        this.controller.Register("Solar 80 100".Split().ToList());
        this.controller.Register("Standart 10 100".Split().ToList());

        for (int i = 0; i <= 10; i++)
        {
            this.controller.Produce();
        }

        int expectedCount = 1;
        var actualAliveProvidersCount = this.controller.Entities.Count;

        Assert.AreEqual(expectedCount, actualAliveProvidersCount, "Alive Providers Count is not corect!");
    }



}

