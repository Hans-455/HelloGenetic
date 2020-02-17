using SimpleGenetic.Code.Chromosome.Constructors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGenetic.Code.Chromosome.HelloWorldImpl
{
    public class HelloWorldFitness : IFitnessFunction
    {
        private StringGeneConstructor constructor = new StringGeneConstructor();
        public float TestChromosome(IChromosome chromosome)
        {
            string target = "Hello World!";

            BitArray arr1 = new BitArray(Encoding.ASCII.GetBytes(target));

            string currentString = (string)constructor.CreateFromChromosome(chromosome);

            BitArray arr2 = new BitArray(Encoding.ASCII.GetBytes(currentString));

            float fitness = 0;

            for(int i = 0; i < arr1.Length; ++i)
            {
                if(i < arr2.Length && arr1[i] == arr2[i])
                {
                    fitness++;
                }
            }

            return fitness;
        }
    }
}
