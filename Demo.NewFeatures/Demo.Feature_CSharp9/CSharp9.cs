using Demo.Infrastructure;
using System;
using System.Collections.Generic;

namespace Demo.Feature_CSharp9
{
    public class CSharp9 : ICSharp
    {
        public CSharp9()
        {

        }
        public void ShowNewFeatures()
        {
            Console.WriteLine($"**************begin {typeof(CSharp9).Name} new features********************");

            Console.WriteLine($"********************end {this.GetType().Name} new features********************");

        }
    }



}
