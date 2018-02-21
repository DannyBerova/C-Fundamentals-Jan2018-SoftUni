using System;
using System.Collections.Generic;

public class Dough
{
    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public string FlourType
    {
        get
        {
            return this.flourType;
        }
        private set
        {
            if (value != "white" && value != "wholegrain")
            {
                throw new Exception("Invalid type of dough.");
            }

            this.flourType = value;

        }
    }

    public string BakingTechnique
    {
        get
        {
            return this.bakingTechnique;
        }
        private set
        {
            if (value != "crispy" && value != "chewy" && value != "homemade")
            {
                throw new Exception("Invalid type of dough.");
            }

            this.bakingTechnique = value;
        }
    }

    public double Weight
    {
        get
        {
            return this.weight;
        }
        private set
        {
            if (value < 1 || value > 200)
            {
                throw new Exception("Dough weight should be in the range [1..200].");
            }

            this.weight = value;
        }
    }

    public double DoughCalories()
    {
        return (2 * this.Weight) * FlourModifier() * BakingTechniqueModifier();
    }

    private double BakingTechniqueModifier()
    {
        if (this.FlourType == "white")
        {
            return 1.5;
        };

        return 1.0;
    }

    private double FlourModifier()
    {
        if (this.BakingTechnique == "crispy")
        {
            return 0.9;
        }
        else if (this.BakingTechnique == "chewy")
        {
            return 1.1;
        }
        else
        {
            return 1.0;
        }
    }
}
