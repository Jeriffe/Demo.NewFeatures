using Demo.Feature_CSharp.Infrastructure;
using System;
using System.Collections.ObjectModel;

namespace Demo.Feature_CSharp
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
            //Async Main
            AsyncMain();

            //Inferred tuple element names(推断元组元素的名称)
            InferredTupleElementNames();

            //Default literals(默认常值)
            DefaultLiteralExpressions();
        }


        private void AsyncMain()
        {
            //这会让你可以直接在 Main 方法里 await， 这在以前是不行的。

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
            //older version 
            {
                int count = default(int);
                const string str = default(string);
                ObservableCollection<string> p = default(ObservableCollection<string>);
                Func<string, bool> whereClause1 = default(Func<string, bool>);
            }
            //new 
            {
                int count = default(int);
                const string str = default(string);
                ObservableCollection<string> p = default(ObservableCollection<string>);
                Func<string, bool> whereClause1 = default;
            }
        }

    }
}
