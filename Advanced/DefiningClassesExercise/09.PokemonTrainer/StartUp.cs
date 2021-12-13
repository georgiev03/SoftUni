using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                var info = Console.ReadLine().Split();

                if (info[0] == "Tournament")
                {
                    break;
                }

                string trainerName = info[0];
                string pokeName = info[1];
                string pokeElement = info[2];
                int pokeHP = int.Parse(info[3]);

                if (trainers.All(t => t.Name != trainerName))
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }

                Pokemon pokemon = new Pokemon(pokeName, pokeElement, pokeHP);
                var currTrainer = trainers.Find(t => t.Name == trainerName);
                currTrainer.Pokemons.Add(pokemon);
            }

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;

                            if(trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.RemoveAt(i--);
                            }
                        }
                    }
                }
            }

            var sortedTrainers = trainers
                .OrderByDescending(t => t.Badges);

            foreach (var trainer in sortedTrainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }

        }

        
    }
}
