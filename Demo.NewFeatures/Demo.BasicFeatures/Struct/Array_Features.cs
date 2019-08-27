using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.BasicFeatures
{
    public class Array_Feature
    {
        public void ArrayCreateInstance(Type type, int capacity)
        {
            int[] myArray = new int[] { 1, 4, 7, 8 };


            Array intArray = Array.CreateInstance(type, capacity);


            Dispaly(intArray);
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray.SetValue(i + 1, i);
            }

            (intArray as int[])[1] = 10;
        }

        private static void Dispaly(Array intArray)
        {
            Console.WriteLine("Rank of the Array is {0}", intArray.Rank);
            Console.WriteLine("LongLength of the Array is {0}", intArray.LongLength);
            Console.WriteLine("Lenght of the Array is {0}", intArray.Length);
        }
    }

    
}
