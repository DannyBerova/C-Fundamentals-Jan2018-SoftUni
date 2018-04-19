using System.Collections.Generic;

public interface IHero
{
    string Name { get; }
    long Agility { get; set; }
    long Damage { get; set; }
    long HitPoints { get; set; }
    long Intelligence { get; set; }
    ICollection<IItem> Items { get; }
    long Strength { get; set; }

    long PrimaryStats { get; }
    long SecondaryStats { get; }

    void AddItem(IItem item);
    void AddRecipe(IRecipe recipe);
}
