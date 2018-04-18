using System.Collections.Generic;

public interface IMissionController
{
    int FailedMissionCounter { get; }
    Queue<IMission> Missions { get; }
    int SuccessMissionCounter { get; }

    void FailMissionsOnHold();
    string PerformMission(IMission mission);
}