using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Demo.CSharp7
{
    public class CSharp7 : ICSharp
    {
        public CSharp7()
        {

        }
        public void ShowNewFeatures()
        {
            OutVariables();

            TuplesEnhancement();
            //解构
            Discards();
            //模式匹配
            PatternMatching();
            //局部函数
            LocalFunctions();

            ThrowExpressions();
            //局部变量和引用返回
            Reflocalsandreturns();

            MoreExpressionBodiedMembers();

            GeneralizedAsyncReturnTypes();

            NumericLiteralSyntaxImprovements();

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

        private void GeneralizedAsyncReturnTypes()
        {
            //ValueTask type 
            async ValueTask<int> Func()
            {
                await Task.Delay(100);
                return 5;
            }
        }

        private void MoreExpressionBodiedMembers()
        {
            //6.More expression-bodied members(更多的函数成员的表达式体)
            //C#7.0 支持用于构造函数,析构函数,和属性访问器的简写表达式
            new MoreExpressionBodyMember_A("More expression-bodied members");
        }

        private static void Reflocalsandreturns()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            ref int x = ref GetByIndex(arr, 2); //调用刚才的方法
            x = 99;

            Console.WriteLine($"the value of the arr[2] is : {arr[2]}");

            ref int GetByIndex(int[] array, int ix) => ref array[ix];  //获取指定数组的指定下标
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


        private static void PatternMatching()
        {
            object a = 1;
            if (a is int c) //这里,判断为int后就直接赋值给c
            {
                int d = c + 10;

                Console.WriteLine(d);
            }
        }


        private void Discards()
        {
            //解构可以应用于任何.NET类型， 前提是需要有Deconstruct方法成员(实例或者扩展)
            var (Name, Age) = new Discard_A { Name = "Joe", Age = 32 };
            Console.WriteLine($"name: {Name}, age: {Age}");

            var (_, _, _, pop1, _, pop2) = Deconstruct_QueryCityDataForYears("New York City", 1960, 2010);
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

        private void TuplesEnhancement()
        {
            //1.ValueTuple 支持语义上的字段命名
            //2.ValueTuple是值类型的(Struct)

            var tuple = (1, 2);
            var tuple2 = ValueTuple.Create(1, 2);
            var tuple3 = new ValueTuple<int, int>(1, 2);

            //编译后的元组字段名称还是Item1,Item2.......，所以只是语义上的命名
            (int One, int Two) named_tuple = (1, 2);
            Console.WriteLine($"Named Tuple{nameof(named_tuple)} names: { named_tuple.One}, {named_tuple.Two}");
        }

        private void OutVariables()
        {
            var input = "123";

            //old way
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
