using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGenetic.Code.Chromosome.HelloWorldImpl
{
    public class HelloWorldSelector : IGeneSelector
    {
        private HelloWorldFitness FitnessCheck = new HelloWorldFitness();
        public List<IChromosome> ExpandGenes(List<IChromosome> chromosomes)
        {
            IChromosome[] result = new IChromosome[1000];
            IChromosome best = chromosomes.First();
            result[0] = best.Copy();

            Random rnd = new Random();
            Parallel.For(1, 1000, (i) =>
            {
                IChromosome copy = best.Copy();

                int mateIndex = rnd.Next(1, chromosomes.Count);

                if (rnd.Next() % 5 == 0)
                {
                    copy.Randomize();
                }

                if (rnd.Next() % 2 == 0)
                {
                    copy.Mutate(1);
                }
                
                copy.Crossover(chromosomes[mateIndex]);

                if (rnd.Next() % 10 == 0)
                {
                    copy.Add(1);
                }

                if (rnd.Next() % 10 == 0)
                {
                    copy.Cut(1);
                }


                result[i] = copy;
            });

            return result.ToList();
        }

        public List<IChromosome> SelectGenes(List<IChromosome> chromosomes, out float bestScore)
        {
            FitnessPair[] pairs = new FitnessPair[chromosomes.Count];

            Parallel.For(0, chromosomes.Count, (i) =>
            {
                float fit = FitnessCheck.TestChromosome(chromosomes[i]);
                    pairs[i] = new FitnessPair() { Chromosome = chromosomes[i], Fitness = fit };
            });

            List<IChromosome> result = new List<IChromosome>();
            pairs = pairs.OrderByDescending(x => x.Fitness).ToArray();

            bestScore = pairs.First().Fitness;

            result = pairs.Take(100).Select(x => x.Chromosome).ToList();
            
            return result;
        }

        class FitnessPair
        {
            public float Fitness;
            public IChromosome Chromosome;
        }
    }
}
