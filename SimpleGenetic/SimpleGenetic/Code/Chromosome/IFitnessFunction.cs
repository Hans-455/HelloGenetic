using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGenetic.Code.Chromosome
{
    public interface IFitnessFunction
    {
        float TestChromosome(IChromosome chromosome);
    }
}
