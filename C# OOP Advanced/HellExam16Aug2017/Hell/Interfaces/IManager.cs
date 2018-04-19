using System.Collections.Generic;

public interface IManager
{
    string AddHero(IList<string> argList);
    string AddItem(IList<string> argsList);
    string AddRecipe(IList<string> argsList);
    string Inspect(IList<string> argslList);
    string Quit(object argList);
}

