using SimpleGenetic.Code.Chromosome;
using SimpleGenetic.Code.Chromosome.HelloWorldImpl;
using SimpleGenetic.Code.Chromosome.Optimization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckBinaryChromosome();
            
            Console.ReadLine();

            RunHelloWorldTest();

            Console.ReadLine();
        }

        private static void RunHelloWorldTest()
        {
            List<IChromosome> initialPopulation = new List<IChromosome>();

            for(int i = 0; i < 1000; ++i)
            {
                BinaryChromosome bin = new BinaryChromosome(256);
                bin.Randomize();

                initialPopulation.Add(bin);
            }

            IChromosome winner = GeneticOptimizer.Optimize(initialPopulation, new HelloWorldSelector(), 96, (f) => Console.WriteLine($"Current Best = {f}"));
        }

        private static void CheckBinaryChromosome()
        {
            BinaryChromosome bin = new BinaryChromosome(16);
            Console.WriteLine(bin.ToString());
            bin.Randomize();
            Console.WriteLine(bin.ToString());
            bin.Add(1);
            Console.WriteLine(bin.ToString());
            bin.Add(2);
            Console.WriteLine(bin.ToString());
            bin.Cut(2);
            Console.WriteLine(bin.ToString());
            bin.Cut(1);
            Console.WriteLine(bin.ToString());

            bin.Mutate(1);
            Console.WriteLine(bin.ToString());
            bin.Mutate(2);
            Console.WriteLine(bin.ToString());
            bin.Mutate(2);
            Console.WriteLine(bin.ToString());
        }
    }

    
}
