using Demo.Infrastructure;
using System;
using System.Collections.Generic;

namespace Demo.Feature_CSharp10
{
    public class CSharp10 : ICSharp
    {
        public CSharp10()
        {

        }
        public void ShowNewFeatures()
        {
            Console.WriteLine($"**************begin {this.GetType().Name} new features********************");

            Console.WriteLine($"********************end {this.GetType().Name} new features********************");

        }
    }



}
