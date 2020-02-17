using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGenetic.Code.Chromosome
{
    public interface IChromosome
    {
        void Mutate(int mutations = 1);
        void Crossover(IChromosome target);
        void Cut(int cuts = 1);
        void Add(int adds = 1);
        void Randomize();
        IChromosome Copy();
    }
}
