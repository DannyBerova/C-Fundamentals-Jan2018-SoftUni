namespace _07.InfernoInfinity.Contracts
{
    using System.Collections.Generic;

    interface IWeaponAttribute
    {
        string Author { get; }
        string Description { get; }
        List<string> Reviewers { get; }
        int Revision { get; }

        string PrintInfo(string field);
    }
}
