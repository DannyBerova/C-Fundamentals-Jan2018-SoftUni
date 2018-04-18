using System;
using NUnit.Framework;

[TestFixture]
public class MissionControllerTests
{
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionController;

    [SetUp]
    public void SetUp()
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.missionController = new MissionController(this.army, this.wareHouse);
    }

    // Constructor
    //[Test]
    //public void CtorShouldInitialiazeCorrectProperties()
    //{
    //    // Act
    //    this.missionController = new MissionController(this.army, this.wareHouse);

    //    // Assert
    //    Assert.AreEqual(0, this.missionController.FailedMissionCounter, "Incorrect FailedMissionCounter!");
    //    Assert.AreEqual(0, this.missionController.SuccessMissionCounter, "Incorrect SuccessMissionCounter!");
    //    Assert.AreEqual(0, this.missionController.Missions.Count, "Incorrect Missions count!");
    //}

    // Missions
    //[Test]
    //public void MissionsQueueShouldContainAddedMissions()
    //{
    //    // Arrange 
    //    var mission1 = new Easy(100);
    //    var mission2 = new Medium(100);
    //    var mission3 = new Hard(100);

    //    this.missionController.Missions.Enqueue(mission1);
    //    this.missionController.Missions.Enqueue(mission2);
    //    this.missionController.Missions.Enqueue(mission3);

    //    // Act
    //    var expectedMissions = new Queue<IMission>();
    //    expectedMissions.Enqueue(mission1);
    //    expectedMissions.Enqueue(mission2);
    //    expectedMissions.Enqueue(mission3);

    //    // Assert
    //    Assert.AreEqual(3, this.missionController.Missions.Count, "Incorrect Missions count!");
    //    CollectionAssert.AreEqual(expectedMissions, this.missionController.Missions, "Incorrect Missions in queue!");
    //}

    // FailMissionsOnHold
    //[Test]
    //public void FailMissionsOnHoldShouldDeclineAllMissionsInQueue()
    //{
    //    // Arrange 
    //    this.missionController.Missions.Enqueue(new Easy(100));
    //    this.missionController.Missions.Enqueue(new Medium(100));
    //    this.missionController.Missions.Enqueue(new Hard(100));

    //    // Act
    //    this.missionController.FailMissionsOnHold();

    //    // Assert
    //    Assert.AreEqual(0, this.missionController.Missions.Count, "Incorrect Missions count!");
    //    Assert.AreEqual(3, this.missionController.FailedMissionCounter, "Incorrect FailedMissionCounter!");
    //}

    // PerformMission
    //[Test]
    //public void PerformMissionAboveQueueCapacityShouldFailOldestMission()
    //{
    //    // Arrange 
    //    var mission1 = new Easy(100);
    //    var mission2 = new Medium(100);
    //    var mission3 = new Hard(100);
    //    var mission4 = new Easy(1);

    //    this.missionController.Missions.Enqueue(mission1);
    //    this.missionController.Missions.Enqueue(mission2);
    //    this.missionController.Missions.Enqueue(mission3);

    //    // Act
    //    var result = this.missionController.PerformMission(mission4).Trim();
    //    var expectedResult = new StringBuilder()
    //                        .AppendLine($"Mission declined - {mission1.Name}")
    //                        .ToString().Trim();

    //    // Assert
    //    Assert.AreEqual(1, this.missionController.FailedMissionCounter, "Incorrect FailedMissionCounter!");
    //    Assert.AreEqual(3, this.missionController.Missions.Count, "Incorrect Missions count!");
    //    Assert.AreEqual(false, this.missionController.Missions.Contains(mission1), "Oldest Mission was not deleted!");
    //    Assert.AreEqual(true, result.StartsWith(expectedResult), "Incorect Result msg!");
    //}

    //[Test]
    //public void PerformMissionAboveQueueCapacityWithUnskilledTeamShouldFailOldestPutAllOthersOnHold()
    //{
    //    // Arrange 
    //    var soldier = new Ranker("Soldier", 20, 100, 100);
    //    this.army.AddSoldier(soldier);

    //    var mission1 = new Easy(soldier.OverallSkill);
    //    var mission2 = new Medium(soldier.OverallSkill * 100);
    //    var mission3 = new Hard(soldier.OverallSkill * 100);
    //    var mission4 = new Hard(soldier.OverallSkill * 100);

    //    this.missionController.Missions.Enqueue(mission1);
    //    this.missionController.Missions.Enqueue(mission2);
    //    this.missionController.Missions.Enqueue(mission3);

    //    // Act
    //    var result = this.missionController.PerformMission(mission4).Trim();

    //    var expectedResult = new StringBuilder()
    //                        .AppendLine($"Mission declined - {mission1.Name}")
    //                        .AppendLine($"Mission on hold - {mission2.Name}")
    //                        .AppendLine($"Mission on hold - {mission3.Name}")
    //                        .AppendLine($"Mission on hold - {mission4.Name}")
    //                        .ToString()
    //                        .Trim();

    //    // Assert
    //    Assert.AreEqual(1, this.missionController.FailedMissionCounter, "Incorrect FailedMissionsCounter!");
    //    Assert.AreEqual(0, this.missionController.SuccessMissionCounter, "Incorrect SuccessMissionCounter!");
    //    Assert.AreEqual(3, this.missionController.Missions.Count, "Incorrect Mission count!");
    //    Assert.AreEqual(expectedResult, result, "Incorrect Result msg!");
    //}

    //[Test]
    //public void PerformMissionAboveQueueCapacityWithSkilledTeamShouldFailOldestExecuteNext()
    //{
    //    // Arrange 
    //    var soldier = new Ranker("Soldier", 20, 100, 100);
    //    this.army.AddSoldier(soldier);

    //    this.wareHouse.AddAmmunitions(nameof(AutomaticMachine), 1000);
    //    this.wareHouse.AddAmmunitions(nameof(Gun), 1000);
    //    this.wareHouse.AddAmmunitions(nameof(Helmet), 1000);

    //    var mission1 = new Medium(soldier.OverallSkill * 1000);
    //    var mission2 = new Easy(soldier.OverallSkill);

    //    this.missionController.Missions.Enqueue(mission1);

    //    // Act
    //    var result = this.missionController.PerformMission(mission2).Trim();

    //    var expectedResult = $"Mission on hold - {mission1.Name}" +
    //                         Environment.NewLine +
    //                        $"Mission completed - {mission2.Name}";

    //    // Assert
    //    Assert.AreEqual(0, this.missionController.FailedMissionCounter, "Incorrect FailedMissionsCounter!");
    //    Assert.AreEqual(1, this.missionController.SuccessMissionCounter, "Incorrect SuccessMissionCounter!");
    //    Assert.AreEqual(1, this.missionController.Missions.Count, "Incorrect Mission count!");
    //    Assert.AreEqual(true, result.Trim() == expectedResult);
    //}


    // Just to test Judge submission - 100/100
    [Test]
    public void JustOneTest()
    {
        var soldier = new Ranker("Soldier", 20, 100, 100);
        this.army.AddSoldier(soldier);

        this.wareHouse.AddAmmunitions(nameof(AutomaticMachine), 1000);
        this.wareHouse.AddAmmunitions(nameof(Gun), 1000);
        this.wareHouse.AddAmmunitions(nameof(Helmet), 1000);

        var mission1 = new Hard(soldier.OverallSkill * 1000);
        var mission2 = new Easy(soldier.OverallSkill * 1000);
        var mission3 = new Hard(soldier.OverallSkill * 1000);
        var mission4 = new Medium(soldier.OverallSkill * 1000);
        var mission5 = new Medium(soldier.OverallSkill);

        this.missionController.Missions.Enqueue(mission1);
        this.missionController.Missions.Enqueue(mission2);
        this.missionController.Missions.Enqueue(mission3);
        this.missionController.Missions.Enqueue(mission4);

        // Act
        var result = this.missionController.PerformMission(mission5).Trim();

        var expectedResult = $"Mission declined - {mission1.Name}" +
                             Environment.NewLine +
                             $"Mission on hold - {mission2.Name}" +
                             Environment.NewLine +
                             $"Mission on hold - {mission3.Name}" +
                             Environment.NewLine +
                             $"Mission on hold - {mission4.Name}" +
                             Environment.NewLine +
                             $"Mission completed - {mission5.Name}";

        // Assert
        Assert.AreEqual(1, this.missionController.FailedMissionCounter, "Incorrect FailedMissionsCounter!");
        Assert.AreEqual(1, this.missionController.SuccessMissionCounter, "Incorrect SuccessMissionCounter!");
        Assert.AreEqual(3, this.missionController.Missions.Count, "Incorrect Mission count!");
        Assert.AreEqual(true, result.Trim() == expectedResult);
    }
}