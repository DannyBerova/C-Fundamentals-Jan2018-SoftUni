using System;

public class Player
{
    private const string NAME_ERROR = "A {0} should not be empty.";


    private string name;
    private double overalSkillLevel;

    public Player(string name, Stat endurance, Stat sprint, Stat dribble, Stat passing, Stat shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
        this.CalcAverageStat();
    }

    public Stat Endurance { get; }
    public Stat Sprint { get; }
    public Stat Dribble { get; }
    public Stat Passing { get; }
    public Stat Shooting { get; }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format(NAME_ERROR, nameof(this.name)));
            }
            this.name = value;
        }
    }

    public double OveralSkillLevel
    {
        get { return this.overalSkillLevel; }
        set { this.overalSkillLevel = value; }
    }

    public void CalcAverageStat()
    {
        double sum = this.Endurance.Level + this.Sprint.Level + this.Dribble.Level + this.Passing.Level + this.Shooting.Level;
        this.OveralSkillLevel = Math.Round(sum / 5, 0);
    }





}

