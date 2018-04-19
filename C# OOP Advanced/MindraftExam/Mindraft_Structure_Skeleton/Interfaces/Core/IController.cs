using System.Collections.Generic;

public interface IController
{
    IReadOnlyCollection<IEntity> Entities { get; }
    string Register(IList<string> args);

    string Produce();
}