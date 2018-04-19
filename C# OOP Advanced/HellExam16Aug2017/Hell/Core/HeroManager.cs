using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HeroManager : IManager
{
    public Dictionary<string, IHero> heroes;

    public HeroManager()
    {
        this.heroes = new Dictionary<string, IHero>();
    }

    public string AddHero(IList<string> argList)
    {
        string result = null;

        string heroName = argList[0];
        string heroType = argList[1];

        try
        {
            Type clazz = Type.GetType(heroType);
            var constructors = clazz.GetConstructors();
            IHero hero = (IHero)constructors[0].Invoke(new object[] { heroName });
            this.heroes.Add(hero.Name, hero);

            result = string.Format(Constants.HeroCreateMessage, heroType, hero.Name);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItem(IList<string> argsList)
    {
        string result = null;

        string itemName = argsList[0];
        string heroName = argsList[1];
        int strengthBonus = int.Parse(argsList[2]);
        int agilityBonus = int.Parse(argsList[3]);
        int intelligenceBonus = int.Parse(argsList[4]);
        int hitPointsBonus = int.Parse(argsList[5]);
        int damageBonus = int.Parse(argsList[6]);

        IItem newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus);
        this.heroes[heroName].AddItem(newItem);

        result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
        return result;
    }

    public string AddRecipe(IList<string> argsList)
    {
        string result = null;

        string itemName = argsList[0];
        string heroName = argsList[1];
        int strengthBonus = int.Parse(argsList[2]);
        int agilityBonus = int.Parse(argsList[3]);
        int intelligenceBonus = int.Parse(argsList[4]);
        int hitPointsBonus = int.Parse(argsList[5]);
        int damageBonus = int.Parse(argsList[6]);
        List<string> requiredItems = argsList.Skip(7).ToList();

        IRecipe newRecipe = new RecipeItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus, requiredItems);
        this.heroes[heroName].AddRecipe(newRecipe);

        result = string.Format(Constants.RecipeCreatedMessage, newRecipe.Name, heroName);
        return result;
    }

    public string Inspect(IList<string> argslList)
    {
        string heroName = argslList[0];

        return this.heroes[heroName].ToString();
    }


    public string Quit(object argList)
    {
        StringBuilder sb = new StringBuilder();

        int counter = 1;

        var orderedHeroes = this.heroes
            .OrderByDescending(h => h.Value.PrimaryStats)
            .ThenByDescending(h => h.Value.SecondaryStats)
            .ToDictionary(x => x.Key, y => y.Value);

        foreach (var hero in orderedHeroes)
        {
            sb.AppendLine($"{counter++}. {hero.Value.GetType().Name}: {hero.Key}");
            sb.AppendLine($"###HitPoints: {hero.Value.HitPoints}");
            sb.AppendLine($"###Damage: {hero.Value.Damage}");
            sb.AppendLine($"###Strength: {hero.Value.Strength}");
            sb.AppendLine($"###Agility: {hero.Value.Agility}");
            sb.AppendLine($"###Intelligence: {hero.Value.Intelligence}");

            if (hero.Value.Items.Count == 0)
            {
                sb.AppendLine($"###Items: None");
            }
            else
            {
                sb.Append($"###Items: ");
                var items = hero.Value.Items.Select(i => i.Name).ToList();
                sb.AppendLine(string.Join(", ", items));
            }
        }

        return sb.ToString().Trim();
    }

}