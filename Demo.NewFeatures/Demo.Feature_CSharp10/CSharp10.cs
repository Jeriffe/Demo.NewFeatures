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
            Console.WriteLine($"**************begin {typeof(CSharp10).Name} new features********************");

            Console.WriteLine($"**************end {typeof(CSharp10).Name} new features********************");
        }
    }



}
