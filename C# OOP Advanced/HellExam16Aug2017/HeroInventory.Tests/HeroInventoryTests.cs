using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class HeroInventoryTests
{
    private HeroInventory sut;

    [SetUp]
    public void TestInit()
    {
        this.sut = new HeroInventory();
    }

    [Test]
    public void InitValuesMustBeZero()
    {
        Assert.AreEqual(0, this.sut.TotalAgilityBonus);
        Assert.AreEqual(0, this.sut.TotalStrengthBonus);
        Assert.AreEqual(0, this.sut.TotalDamageBonus);
        Assert.AreEqual(0, this.sut.TotalHitPointsBonus);
        Assert.AreEqual(0, this.sut.TotalIntelligenceBonus);
    }

    [Test]
    public void TestAllBonusValuesAreValid()
    {
        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);

        this.sut.AddCommonItem(item);

        Assert.AreEqual(1, this.sut.TotalStrengthBonus);
        Assert.AreEqual(2, this.sut.TotalAgilityBonus);
        Assert.AreEqual(3, this.sut.TotalIntelligenceBonus);
        Assert.AreEqual(4, this.sut.TotalHitPointsBonus);
        Assert.AreEqual(5, this.sut.TotalDamageBonus);
    }

    [Test]
    public void AddCommonItems()
    {
        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);

        this.sut.AddCommonItem(item);
        Type clazz = typeof(HeroInventory);
        var field = clazz.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);
        var collection = (Dictionary<string, IItem>)field.GetValue(this.sut);

        Assert.AreEqual(1, collection.Count);
    }

    [Test]
    public void AddRecipeItems()
    {
        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);
        CommonItem item2 = new CommonItem("item2", 1, 2, 3, 4, 5);
        IRecipe recipe = new RecipeItem("recipe", 10, 20, 30, 40, 50, new List<string>() { item.Name, item2.Name });

        this.sut.AddCommonItem(item);
        this.sut.AddCommonItem(item2);
        this.sut.AddRecipeItem(recipe);

        Type clazz = typeof(HeroInventory);

        var fieldItemColl = clazz.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);
        var collectionItem = (Dictionary<string, IItem>)fieldItemColl.GetValue(this.sut);

        var fieldRecipeColl
            = clazz.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Skip(1)
            .FirstOrDefault();
        var collectionRecipe = (Dictionary<string, IRecipe>)fieldRecipeColl.GetValue(this.sut);

        Assert.AreEqual(10, this.sut.TotalStrengthBonus);
        Assert.AreEqual(20, this.sut.TotalAgilityBonus);
        Assert.AreEqual(30, this.sut.TotalIntelligenceBonus);
        Assert.AreEqual(40, this.sut.TotalHitPointsBonus);
        Assert.AreEqual(50, this.sut.TotalDamageBonus);
        Assert.AreEqual(1, collectionItem.Count);
        Assert.AreEqual(1, collectionRecipe.Count);
    }

    [Test]
    public void AddNewItemToCompleteRecipe()
    {
        var item = new CommonItem("item", 1, 2, 3, 4, 5);
        IRecipe recipe = new RecipeItem("recipe", 10, 20, 30, 40, 50, new List<string>() { "item", "item2" });
        var item2 = new CommonItem("item2", 1, 2, 3, 4, 5);

        this.sut.AddCommonItem(item);
        this.sut.AddRecipeItem(recipe);
        this.sut.AddCommonItem(item2);

        Assert.AreEqual(50, this.sut.TotalDamageBonus);
    }
}

