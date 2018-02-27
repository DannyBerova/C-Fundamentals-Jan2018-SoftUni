using System.Collections.Generic;

internal interface ILeutenantGeneral : IPrivate
{
    IList<IPrivate> Privates { get; }
}