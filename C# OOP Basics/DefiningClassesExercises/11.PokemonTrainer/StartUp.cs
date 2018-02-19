using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var trainers = new Dictionary<string, Trainer>();
        var input = Console.ReadLine();

        while (input != "Tournament")
        {
            var inputTokens = input.Split();
            if (inputTokens.Length == 4)
            {
                var trainerName = inputTokens[0];
                var pokemonName = inputTokens[1];
                var pokemonElement = inputTokens[2];
                var pokemonHealth = int.Parse(inputTokens[3]);

                var currentTrainer = new Trainer(trainerName);
                var currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = currentTrainer;
                }
                trainers[trainerName].Pokemons.Add(currentPokemon);
            }

            input = Console.ReadLine();
        }

        while ((input = Console.ReadLine()) != "End")
        {

            foreach (var trainer in trainers)
            {
                var trainerToCheck = trainer.Value;
                if (trainerToCheck.Pokemons.Any(p => p.Element == input))
                {
                    trainerToCheck.Badges++;
                }
                else
                {
                    for (int i = 0; i < trainerToCheck.Pokemons.Count; i++)
                    {
                        var pokemonToCheck = trainerToCheck.Pokemons[i];
                        if (pokemonToCheck.Health > 10)
                        {
                            pokemonToCheck.Health -= 10;
                        }
                        else
                        {
                            trainerToCheck.Pokemons.Remove(pokemonToCheck);
                            i--;
                        }
                    }
                }
            }
        }

        var sorted = trainers.OrderByDescending(t => t.Value.Badges);

        foreach (var tr in sorted)
        {
            var trn = tr.Value;
            Console.WriteLine($"{trn.Name} {trn.Badges} {trn.Pokemons.Count}");
        }
    }
}
