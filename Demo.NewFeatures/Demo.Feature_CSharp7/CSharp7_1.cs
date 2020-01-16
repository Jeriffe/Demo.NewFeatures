using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo.CSharp7
{
    public class CSharp7_1 : ICSharp
    {
        public CSharp7_1()
        {

            /*7.1
             * Async Main
             * Default literal expressions
             * Inferred tuple element names
             * Pattern matching on generic type parameters
             */
        }

        public void ShowNewFeatures()
        {
            AsyncMain();

            DefaultLiteralExpressions();

            InferredTupleElementNames();

            PatternMatchingOnGenericTypeParameters();

        }

       

        private void PatternMatchingOnGenericTypeParameters()
        {
            /*Beginning with C# 7.1, the pattern expression 
             * for is and the switch type pattern may have the type of a generic type parameter. 
             * This can be most useful when checking types 
             * that may be either struct or class types, and you want to avoid boxing.*/
        }

        private void InferredTupleElementNames()
        {
            int count = 5;
            string label = "Colors used in the map";
            var pair = (count: count, label: label);

            var enhance_pair = (count, label); // element names are "count" and "label"
        }
        /// <summary>
        /// Default literal expressions are an enhancement to default value expressions. 
        /// These expressions initialize a variable to the default value.
        /// </summary>
        private void DefaultLiteralExpressions()
        {
            //previous write:
            Func<string, bool> whereClause = default(Func<string, bool>);

            //new 
            Func<string, bool> whereClause1 = default;
        }

        private void AsyncMain()
        {
            /*
            static int Main()
            {
                return DoAsyncWork().GetAwaiter().GetResult();
            }

            static async Task<int> Main()
            {
                // This could also be replaced with the body
                // DoAsyncWork, including its await expressions:
                return await DoAsyncWork();
            }

            static async Task Main()
            {
                await SomeAsyncMethod();
            }
            */
        }
    }

}
