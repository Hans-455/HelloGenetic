using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGenetic.Code.Chromosome
{
    public interface IGeneSelector
    {
        List<IChromosome> SelectGenes(List<IChromosome> chromosomes, out float bestScore);
        List<IChromosome> ExpandGenes(List<IChromosome> chromosomes);

    }
}
