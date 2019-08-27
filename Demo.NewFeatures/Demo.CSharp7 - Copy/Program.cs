using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.CSharp7
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            List<ICSharp> sharps = new List<ICSharp> { new CSharp7(), };

            sharps.ForEach(c => c.ShowNewFeatures());

            Console.ReadLine();

            return 0;

        }

    }
}