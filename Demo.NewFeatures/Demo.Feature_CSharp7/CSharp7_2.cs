using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo.CSharp7
{
    public class CSharp7_2 : ICSharp
    {
        public CSharp7_2()
        {

        }
        public void ShowNewFeatures()
        {
            /*7.2
            * Non-trailing named arguments
            * Leading underscores in numeric literals
            * private protected access modifier
            * Conditional ref expressions
            */
            WriteSafeAndEfficientCSharpCode();

            NonTrailingNamedArguments();

            //Digital Separator
            LeadingUnderscoresInNumericLiterals();

            PrivateProtectedAccessModifier();

            ConditionalRefExpressions();
        }

        private void ConditionalRefExpressions()
        {
            int[] arr = new int[2] { 1, 2 };
            int[] otherArr = new int[2] { 1, 2 };

            ref var r = ref (arr != null ? ref arr[0] : ref otherArr[0]);
        }

        private void PrivateProtectedAccessModifier()
        {
            /* private protected indicates 
             * that a member may be accessed by containing class or derived classes 
             * that are declared in the same assembly. 
             * While protected internal allows access by derived classes or classes 
             * that are in the same assembly, private protected limits access to derived types declared in the same assembly.
             */
        }

        //
        private void LeadingUnderscoresInNumericLiterals()
        {
            //The implementation of support for digit separators in C# 7.0 
            //didn't allow the _ to be the first character of the literal value.
            //Hex and binary numeric literals may now begin with an _.
            int binaryValue = 0b_0101_0101;
        }

        private void NonTrailingNamedArguments()
        {
            //Old_C#4.x
            var v = Volume(a: 3, c: 5, b: 4);
            var v1 = Volume(3, b: 4, c: 5);

            //New_C#7.2
            var v2 = Volume(3, b: 4, 5);//we don't need to specific parameter C

            int Volume(int a, int b, int c)
            {
                return a * b * c;
            }
        }

        private void WriteSafeAndEfficientCSharpCode()
        {
            //Declare readonly structs for immutable value types
            new ReadonlyPoint2D(2, 4);

            //Use ref readonly return statements for large structures when possible
        }
    }

    readonly public struct ReadonlyPoint2D
    {
        public ReadonlyPoint2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; }
        public double Y { get; }
    }

}
