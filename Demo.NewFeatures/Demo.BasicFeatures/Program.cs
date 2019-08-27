using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.BasicFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            Operator_Feature.Test();

            StructTest st = new StructTest();

            st.Test_Initialize();


            Console.Read();
        }
    }
}
