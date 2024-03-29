﻿using Demo.Feature_CSharp.Infrastructure;
using System;
using System.Threading.Tasks;

namespace Demo.Feature_CSharp
{
    public class CSharp7 : ICSharp
    {
        public CSharp7()
        {

        }

        public void ShowNewFeatures()
        {
            Console.WriteLine($"********************begin {this.GetType().Name} new features********************");

            //Out variables
            OutVariables();

            //模式匹配
            PatternMatching();

            //Tuples
            Tuples();

            //Discards解构
            Discards();

            //局部函数
            LocalFunctions();
            
            //Literal improvements
            NumericLiteralSyntaxImprovements();

            //局部变量和引用返回
            Reflocalsandreturns();

            GeneralizedAsyncReturnTypes();

            //More expression-bodied members(更多的函数成员的表达式体)
            MoreExpressionBodiedMembers();

            ThrowExpressions();

            Console.WriteLine($"********************end {this.GetType().Name} new features********************");
        }

        private void OutVariables()
        {
            var input = "123";

            //old way
            /*In older versions of C#,  Before you can call a method with out parameters you first have to declare variables to pass to it. 
             * Since you typically aren’t initializing these variables,you also cannot use var to declare them, but need to specify the full type:
             */
            int result_out;
            if (int.TryParse(input, out result_out))
            {
                Console.WriteLine(result_out);
            }


            //new way
            if (int.TryParse(input, out int result))
            {
                Console.WriteLine(result);
            }

            if (int.TryParse(input, out var result_var))
            {
                Console.WriteLine(result_var);
            }

        }

        private static void PatternMatching()
        {
            object a = 1;
            //1.is表达式(is expressions can now have a pattern on the right hand side, instead of just a type)
            //扩展的is操作符是as和if的组合： 先做as转换，再做if判断
            if (a is int c) //这里,判断为int后就直接赋值给c
            {
                int d = c + 10;

                Console.WriteLine(d);
            }


            //2.switch
            //Starting with C# 7.0, the match expression can be any non-null expression.
            //patterns可以用在case子句
            //case 子句可以附加条件判断式
            void SwitchPro(object shape)
            {
                switch (shape)
                {
                    case Circle circle:
                        Console.WriteLine($"circle with radius {circle.Radius}");
                        break;
                    case Rectangle s when (s.Length == s.Height):
                        Console.WriteLine($"{s.Length} x {s.Height} square");
                        break;
                    case Rectangle r:
                        Console.WriteLine($"{r.Length} x {r.Height} rectangle");
                        break;
                    default:
                        Console.WriteLine("<unknown shape>");
                        break;
                    case null:
                        throw new ArgumentNullException(nameof(shape));
                }
            }
        }

        private void Tuples()
        {
            //1.ValueTuple 支持语义上的字段命名
            //2.ValueTuple是值类型的(Struct)

            (int One, int Two) named_tuple = (1, 2);
            var named_tuple_right = (one: 1, two: 2);

            (int T1, int T2) named_tuple2 = ValueTuple.Create(1, 2);
            (int S1, int S2) named_tuple3 = new ValueTuple<int, int>(1, 2);

            Console.WriteLine($"Named Tuple{nameof(named_tuple)} names: { named_tuple.One}, {named_tuple.Two}");
            Console.WriteLine($"Named Tuple{nameof(named_tuple2)} names: { named_tuple2.T1}, {named_tuple2.T2}");
            Console.WriteLine($"Named Tuple{nameof(named_tuple3)} names: { named_tuple3.S1}, {named_tuple3.S2}");


            (string, string, string) LookupName(long id) // tuple return type
            {
                string first = "F", middle = "Mid", last = "L";

                return (first, middle, last); // tuple literal
            }
            var names = LookupName(id: 1);
            Console.WriteLine($"found {names.Item1} {names.Item3}.");//编译后的元组字段名称还是Item1,Item2,Item3


            (string first, string middle, string last) LookupName2(long id) // tuple elements have names
            {
                string first = "F", middle = "Mid", last = "L";

                return (first, middle, last); // tuple literal
            }
            var names2 = LookupName2(id: 1);
            Console.WriteLine($"found {names2.first} {names2.last}.");
        }

        private (string a, int b) Discards()
        {
            //解构可以应用于任何.NET类型， 前提是需要有Deconstruct方法成员(实例或者扩展)
            var (Name, Age) = new Discard_A { Name = "Joe", Age = 32 };
            Console.WriteLine($"name: {Name}, age: {Age}");

            var (_, _, _, pop1, _, pop2) = Deconstruct_QueryCityDataForYears("New York City", 1960, 2010);

            return (Name, Age);
        }

        public static void LocalFunctions()
        {
            int data = LocalFunction_Internal(100, 200);
            Console.WriteLine(data);

            //定义局部函数,LocalFunction_Internal,局部函数定义在上下文函数内的任何位置
            int LocalFunction_Internal(int a, int b)
            {
                return a + b;
            }
        }

        public const int OneHundredTwentyEight = 0b1000_0000;
        private void NumericLiteralSyntaxImprovements()
        {
            int a = 123_456;
            int b = 0xAB_CD_EF;
            int c = 123456;
            int d = 0xABCDEF;

            Console.WriteLine(a == c);
            Console.WriteLine(b == d);
        }

        private static void Reflocalsandreturns()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            ref int x = ref GetByIndex(arr, 2); //调用刚才的方法
            x = 99;

            Console.WriteLine($"the value of the arr[2] is : {arr[2]}"); //99

            ref int GetByIndex(int[] array, int ix) => ref array[ix];  //获取指定数组的指定下标
        }


        private void GeneralizedAsyncReturnTypes()
        {
            async Task<int> CalculateSum(int a, int b)
            {
                // if both a and b are 0 the function will still create a Task
                //which in this case is an unnecessary operation
                if (a == 0 && b == 0) { return 0; }

                return await Task.Run(() => a + b);
            }

            async ValueTask<int> CalculateSumSimple(int a, int b)
            {
                if (a == 0 && b == 0) { return 0; }

                return await Task.Run(() => a + b);
            }
        }

        private void MoreExpressionBodiedMembers()
        {
            /*Expression bodied methods 
             * C# 7.0 adds accessors, constructors and finalizers to the list of things that can have expression bodies:
             */

            //C#7.0 支持用于构造函数,析构函数,和属性访问器的简写表达式
            new MoreExpressionBodyMember_A("More expression-bodied members");
        }


        private static string ThrowExpressions()
        {
            string a = null;
            try
            {
                return a ?? throw new Exception("throw Expressions!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string loadedConfig = LoadConfigResourceOrDefault() ?? throw new InvalidOperationException("Could not load config");

            string LoadConfigResourceOrDefault() { return "throw Expressions!"; }

            return a;
        }


        private static (string, double, int, int, int, int) Deconstruct_QueryCityDataForYears(string name, int year1, int year2)
        {
            int population1 = 0, population2 = 0;
            double area = 0;

            if (name == "New York City")
            {
                area = 468.48;
                if (year1 == 1960)
                {
                    population1 = 7781984;
                }
                if (year2 == 2010)
                {
                    population2 = 8175133;
                }
                return (name, area, year1, population1, year2, population2);
            }

            return ("", 0, 0, 0, 0, 0);
        }

    }

    internal class Rectangle
    {
        internal object Length;
        internal object Height;
    }

    internal class Circle
    {
        public object Radius { get; internal set; }
    }

    class MoreExpressionBodyMember_A
    {
        private string label;

        // 构造函数的表达式写法
        public MoreExpressionBodyMember_A(string label) => this.Label = label;

        // 析构函数的表达式写法
        ~MoreExpressionBodyMember_A() => Console.Error.WriteLine("Finalized!");


        // Get/Set属性访问器的表达式写法
        public string Label
        {
            get => label;
            set => this.label = value ?? "Default label";
        }
    }
    public class Discard_A
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Deconstruct(out string name, out int age)
        {
            name = Name;
            age = Age;
        }
    }

}
