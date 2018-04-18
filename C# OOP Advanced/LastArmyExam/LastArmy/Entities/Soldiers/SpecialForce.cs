﻿using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const double OverallSkillMiltiplier = 3.5;
    private const double RegeneratePoint = 30;

    private readonly IReadOnlyList<string> weaponsAllowed = new List<string>()
    {
        nameof(Gun),
        nameof(AutomaticMachine),
        nameof(MachineGun),
        nameof(RPG),
        nameof(Helmet),
        nameof(Knife),
        nameof(NightVision)
    };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    public override double OverallSkill => base.OverallSkill * OverallSkillMiltiplier;

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;

    public override void Regenerate()
    {
        this.Endurance += this.Age + 30;
    }
}