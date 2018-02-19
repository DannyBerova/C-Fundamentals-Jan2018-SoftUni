public class Pokemon
{
    private string pokemonName;
    private string pokemonType;

    public Pokemon(string pokemonName, string pokemonType)
    {
        this.PokemonName = pokemonName;
        this.pokemonType = pokemonType;
    }

    public string PokemonName
    {
        get => this.pokemonName;
        set => this.pokemonName = value;
    }

    public string PokemonType
    {
        get => this.pokemonType;
        set => this.pokemonType = value;
    }

    public override string ToString()
    {
        return $"{this.PokemonName} {this.PokemonType}";
    }

}

