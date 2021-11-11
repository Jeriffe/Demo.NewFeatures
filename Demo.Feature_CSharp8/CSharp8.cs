using System;
using System.Collections.Generic;

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

            IndicesandRanges();

        }

        private void IndicesandRanges()
        {
            var words = new string[]
            {
                            // index from start    index from end
                "The",      // 0                   ^9
                "quick",    // 1                   ^8
                "brown",    // 2                   ^7
                "fox",      // 3                   ^6
                "jumped",   // 4                   ^5
                "over",     // 5                   ^4
                "the",      // 6                   ^3
                "lazy",     // 7                   ^2
                "dog"       // 8                   ^1
            };              // 9 (or words.Length) ^0 --throw exception

            //Indices
            Console.WriteLine($"The last word is {words[^1]}"); //dog

            //Range
            var quickBrownFox = words[1..4];
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
