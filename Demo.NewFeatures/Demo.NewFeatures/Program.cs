using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.NewFeatures
{
    class Program
    {
        static void Main(string[] args)
        {


            List<ICSharp> sharps = new List<ICSharp> { new CSharp2(), new CSharp3(), new CSharp4(), new CSharp5(), new CSharp6(), };

            sharps.ForEach(c => c.ShowNewFeatures());

            Console.ReadLine();
        }
    }

}
