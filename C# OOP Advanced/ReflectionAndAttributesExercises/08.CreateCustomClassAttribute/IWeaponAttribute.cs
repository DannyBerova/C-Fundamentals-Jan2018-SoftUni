namespace _08.CreateCustomClassAttribute
{
    using System.Collections.Generic;

    interface IWeaponAttribute
    {
        string Author { get; }
        string Description { get; }
        IList<string> Reviewers { get; }
        int Revision { get; }

        string PrintInfo(string field);
    }
}
