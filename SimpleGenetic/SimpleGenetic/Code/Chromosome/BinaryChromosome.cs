using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGenetic.Code.Chromosome
{
    public class BinaryChromosome: IChromosome
    {
        private BitArray _geneCode;
        private Random _rnd;
        public int BitCount { get { return _geneCode.Count; } }

        public bool this[int index]
        {
            get
            {
                if(index > BitCount)
                {
                    throw new IndexOutOfRangeException();
                }else
                {
                    return _geneCode[index];
                }
            }
        }

        public BinaryChromosome(int bits)
        {
            _geneCode = new BitArray(bits);
            _rnd = new Random();
        }

        public byte[] GetBytes()
        {
            int slices = BitCount / 8;
            if(BitCount % 8 != 0)
            {
                slices++;
            }

            byte[] buffer = new byte[slices];

            _geneCode.CopyTo(buffer, 0);

            return buffer;
        }

        public void Mutate(int mutations)
        {
            int count = mutations;

            for(int i = 0; i < count; ++i)
            {
                int cIndex = _rnd.Next(0, _geneCode.Count);
                bool newBit = _rnd.Next() % 2 == 0;
                _geneCode.Set(cIndex, newBit);
            }
        }

        public void CrossSplit(BinaryChromosome other)
        {
            int lengthP1 = _rnd.Next(_geneCode.Count - 1);

            BitArray newArr = new BitArray(Math.Max(_geneCode.Count, other._geneCode.Count));
            
            for(int i = 0; i < lengthP1; ++i)
            {
                newArr.Set(i, _geneCode.Get(i));
            }

            for(int i = lengthP1; i < other._geneCode.Count; ++i)
            {
                newArr.Set(i, other._geneCode.Get(i));
            }
            
            _geneCode = newArr;
        }

        public void Crossover(IChromosome target)
        {
            if (target.GetType() == (typeof(BinaryChromosome)))
            {
                CrossSplit((BinaryChromosome)target);
            }else
            {
                throw new Exception("Must cross with another binary chromosome");
            }
        }

        public void Cut(int cuts = 1)
        {
            if (cuts <= 0)
            {
                return;
            }
            int count = cuts;
            BitArray newArr = new BitArray(_geneCode.Count - count);

            int[] cutIndexes = new int[count];

            for (int i = 0; i < count; ++i)
            {
                cutIndexes[i] = _rnd.Next(0, newArr.Count);
            }

            Array.Sort(cutIndexes);
            int readIndex = 0;
            int newIndex = 0;

            for (int i = 0; i < newArr.Count; ++i)
            {
                if (newIndex < cutIndexes.Length && i >= cutIndexes[newIndex])
                {
                    readIndex++;
                    newIndex++;
                }
                else
                {
                    newArr.Set(i, _geneCode.Get(readIndex));
                    readIndex++;
                }
            }
            _geneCode = newArr;
        }

        public void Add(int adds = 1)
        {
            if(adds <= 0)
            {
                return;
            }
            int count = adds;
            BitArray newArr = new BitArray(_geneCode.Count + count);

            int[] addIndexes = new int[count];
            
            for(int i = 0; i < count; ++i)
            {
                addIndexes[i] = _rnd.Next(0, newArr.Count);
            }

            Array.Sort(addIndexes);
            int readIndex = 0;
            int newIndex = 0;

            for(int i = 0; i < newArr.Count; ++i)
            {
                if(newIndex < addIndexes.Length && i >= addIndexes[newIndex])
                {
                    newArr.Set(i, _rnd.Next() % 2 == 0);
                    newIndex++;
                }
                else
                {
                    newArr.Set(i, _geneCode.Get(readIndex));
                    readIndex++;
                }
            }

            _geneCode = newArr;
        }

        public void Randomize()
        {
            for(int i = 0; i < _geneCode.Count; ++i)
            {
                _geneCode.Set(i, _rnd.Next() % 2 == 0);
            }
        }

        public override string ToString()
        {
            string result = "";
            for(int i = 0; i < _geneCode.Count; ++i)
            {
                if(_geneCode[i])
                {
                    result += "1";
                }else
                {
                    result += "0";
                }
            }
            return result;
        }

        public IChromosome Copy()
        {
            BinaryChromosome copy = new BinaryChromosome(BitCount);
            for(int i = 0; i < BitCount; ++i)
            {
                copy._geneCode.Set(i, _geneCode[i]);
            }

            return copy;
        }
    }
}
