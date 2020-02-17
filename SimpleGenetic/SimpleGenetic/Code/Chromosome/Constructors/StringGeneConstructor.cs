using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGenetic.Code.Chromosome.Constructors
{
    public class StringGeneConstructor : IGeneticConstructor
    {
        public object CreateFromChromosome(IChromosome chromosome)
        {
            if(chromosome.GetType() != typeof(BinaryChromosome))
            {
                return null;
            }

            BinaryChromosome binCh = (BinaryChromosome)chromosome;
            string buildStr = Encoding.ASCII.GetString(binCh.GetBytes());
            return buildStr;
        }
    }
}
