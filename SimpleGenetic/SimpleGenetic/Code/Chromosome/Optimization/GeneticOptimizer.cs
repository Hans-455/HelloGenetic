using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGenetic.Code.Chromosome.Optimization
{
    public class GeneticOptimizer
    {
        public static IChromosome Optimize(List<IChromosome> initialPopulation, IGeneSelector selector, float target, Action<float> notifyAction = null)
        {
            bool running = true;

            List<IChromosome> workingSet = new List<IChromosome>();
            workingSet.AddRange(initialPopulation);

            while(running)
            {
                workingSet = selector.SelectGenes(workingSet, out float bestScore);
                
                if(notifyAction != null)
                {
                    notifyAction(bestScore);
                }
                
                if(bestScore >= target)
                {
                    return workingSet.First();
                }

                workingSet = selector.ExpandGenes(workingSet);
            }

            return null;
        }
    }

    
}
