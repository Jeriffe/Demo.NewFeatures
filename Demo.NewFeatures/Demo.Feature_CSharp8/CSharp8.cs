using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Feature_CSharp8
{
    public class CSharp8 : ICSharp
    {
        public CSharp8()
        {

        }
        public void ShowNewFeatures()
        {
            ReadonlyMembers();

            UsingDeclarations();

            StaticLocalFunctions();

            DisposableRefStructs();

            NullableReferenceTypes();

            AsynchronousStreams();

        }

        private void AsynchronousStreams()
        {
            throw new NotImplementedException();
        }

        private void NullableReferenceTypes()
        {
            throw new NotImplementedException();
        }

        private void DisposableRefStructs()
        {
            /*A struct declared with the ref modifier may not implement any interfaces and so cannot implement IDisposable. 
             * Therefore, to enable a ref struct to be disposed, 
             * it must have an accessible void Dispose() method. This also applies to readonly ref struct declarations.*/
        }

        private void StaticLocalFunctions()
        {
            int y = 5;
            int x = 7;
            var sum =  Add(x, y);

            static int Add(int left, int right) => left + right;
        }

        private void UsingDeclarations()
        {
            /* A using declaration is a variable declaration preceded by the using keyword.
             * It tells the compiler that the variable being declared should be disposed at the end of the enclosing scope.
             */

        }

        private void ReadonlyMembers()
        {
            var rm = new Struct_ReadonlyMembers();

            Console.WriteLine(rm.Distance);
        }

        static void WriteLinesToFile(IEnumerable<string> lines)
        {
            using var file = new System.IO.StreamWriter("WriteLines2.txt");
            foreach (string line in lines)
            {
                if (!line.Contains("Second"))
                {
                    file.WriteLine(line);
                }
            }

            // file is disposed here
        }
    }


    public struct Struct_ReadonlyMembers
    {
        public double X { get; set; }
        public double Y { get; set; }

        //Notice that the readonly modifier is necessary on a read only property.
        public double Distance => Math.Sqrt(X * X + Y * Y);

        public override string ToString() =>
            $"({X}, {Y}) is {Distance} from the origin";
    }

}
