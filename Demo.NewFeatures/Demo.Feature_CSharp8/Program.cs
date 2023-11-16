using Demo.Feature_CSharp;
using Demo.Feature_CSharp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Feature_CSharp8
{
    class Program
    {
        // Main function 
        static async Task Main(string[] args)
        {
            List<ICSharp> sharps = new List<ICSharp> { new CSharp8(), };

            sharps.ForEach(c => c.ShowNewFeatures());

            Console.ReadLine();

            Console.ReadKey();
        }
    }
}
