using Demo.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Demo.CSharp7
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sharps = new List<ICSharp> { new CSharp7(), };

            sharps.ForEach(c => c.ShowNewFeatures());

            Console.ReadLine();

        }

    }
}