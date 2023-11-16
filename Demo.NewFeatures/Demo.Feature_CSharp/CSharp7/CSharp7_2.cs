using Demo.Feature_CSharp.Infrastructure;

namespace Demo.Feature_CSharp
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
            * private protected access modifier
            * Conditional ref expressions
            * Digit Separator After Base Specifier(Leading Digit Separator)
            */

            WriteSafeAndEfficientCSharpCode();

            NonTrailingNamedArguments();

            //Digital Separator
            LeadingUnderscoresInNumericLiterals();

            PrivateProtectedAccessModifier();

            ConditionalRefExpressions();
        }

        private void WriteSafeAndEfficientCSharpCode()
        {
            //Declare readonly structs for immutable value types
            new ReadonlyPoint2D(2, 4);

            //Use ref readonly return statements for large structures when possible
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

            /*
            class Employee
            {
                public int Id { get; set; }
                protected int Name { get; set; }
                internal DateTime DOB { get; set; }
                private Decimal Salary { get; set; }
                protected internal int DepatmentId { get; set; }
                private protected string ProjectName { get; set; }
            }
            */
        }

        //
        private void LeadingUnderscoresInNumericLiterals()
        {
            /*
            123      // permitted in C# 1.0 and later
            1_2_3    // permitted in C# 7.0 and later
            0x1_2_3  // permitted in C# 7.0 and later
            0b101    // binary literals added in C# 7.0
            0b1_0_1  // permitted in C# 7.0 and later
            */

            /*in C# 7.2, _ is permitted after the `0x` or `0b`
            0x_1_2   // permitted in C# 7.2 and later
            0b_1_0_1 // permitted in C# 7.2 and later
            */
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
