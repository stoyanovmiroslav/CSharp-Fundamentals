using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        string input = "";
        List<Trainer> trainers = new List<Trainer>();

        while ((input = Console.ReadLine()) != "Tournament")
        {
            string[] pokemonTrainerInfo = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string trainerName = pokemonTrainerInfo[0];
            string pokemonName = pokemonTrainerInfo[1];
            string pokemonElement = pokemonTrainerInfo[2];
            int pokemonHealth = int.Parse(pokemonTrainerInfo[3]);

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if (!trainers.Any(x => x.Name == trainerName))
            {
                Trainer trainer = new Trainer(trainerName, pokemon);
                trainers.Add(trainer);
            }
            else
            {
                var trainer = trainers.First(x => x.Name == trainerName);
                trainer.Pokemons.Add(pokemon);
            }
        }

        string element = "";

        while ((element = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(x => x.Element == element))
                {
                    trainer.NumberOfBadges += 1;
                }
                else
                {
                    trainer.Pokemons.ForEach(x => x.Health -= 10);
                    trainer.Pokemons = trainer.Pokemons.Where(x => x.Health > 0).ToList();
                }
            }
        }

        foreach (var trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
        {
            Console.WriteLine("{0} {1} {2}", trainer.Name, trainer.NumberOfBadges, trainer.Pokemons.Count);
        }
    }
}