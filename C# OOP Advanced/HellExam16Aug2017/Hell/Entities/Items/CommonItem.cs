﻿ public class CommonItem : AbstractItem, IItem
    {
        public CommonItem(string name, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus) 
            : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
        {
        }
    }
