using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.CSharp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //1. out-variables(Out变量)
            /*
             * string ddd = ""; //先申明变量
             * StringOut(out ddd);
             */
            StringOut(out string ddd); //传递的同时申明
            Console.WriteLine(ddd);

            //2.Tuples(元组)
            //precondition:Install-Package System.ValueTuple
            var data = GetFullName();
            Console.WriteLine($"{data.Name} - {data.Age} - {data.BirthDay}");

            //3. Pattern Matching(匹配模式)
            PatternMatching();

            //4.ref locals and returns (局部变量和引用返回)
            Reflocalsandreturns();

            //5.Local Functions (局部函数)
            DoSomeing();

            //6.More expression-bodied members(更多的函数成员的表达式体)
            //C#7.0 支持用于构造函数,析构函数,和属性访问器的简写表达式
            new CacheContext("More expression-bodied members");

            //7.Throw Expressions(异常表达式)
            ThrowExpressions();

            //8.Generalized async return types(扩展异步返回类型） 
            //Install - Package System.Threading.Tasks.Extensions   
            var task = Func();
            Thread.Sleep(30);
            Console.WriteLine($"Generalized async return types: {task}");

            //9.Numeric literal syntax improvements(数值文字语法改进)
            Numericliteralsyntaximprovements();
            Console.Read();
        }
        public static async ValueTask<int> Func()
        {
            await Task.Delay(30);
            return 100;
        }

        private static void Numericliteralsyntaximprovements()
        {
            int a = 123_456;
            int b = 0xAB_CD_EF;
            int c = 123456;
            int d = 0xABCDEF;
            Console.WriteLine(a == c);
            Console.WriteLine(b == d);
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

        class CacheContext
        {
            private string label;

            // 构造函数的表达式写法
            public CacheContext(string label) => this.Label = label;

            // 析构函数的表达式写法
            ~CacheContext() => Console.Error.WriteLine("Finalized!");


            // Get/Set属性访问器的表达式写法
            public string Label
            {
                get => label;
                set => this.label = value ?? "Default label";
            }
        }

        private static void Reflocalsandreturns()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            ref int x = ref GetByIndex(arr, 2); //调用刚才的方法
            x = 99;

            Console.WriteLine($"the value of the arr[2] is : {arr[2]}");
        }

        public static void DoSomeing()
        {
            //调用Dosmeing2
            int data = Dosmeing2(100, 200);
            Console.WriteLine(data);

            //定义局部函数,Dosmeing2,局部函数定义在上下文函数内的任何位置
            int Dosmeing2(int a, int b)
            {
                return a + b;
            }
        }

        static ref int GetByIndex(int[] arr, int ix) => ref arr[ix];  //获取指定数组的指定下标

        private static void PatternMatching()
        {
            object a = 1;
            if (a is int c) //这里,判断为int后就直接赋值给c
            {
                int d = c + 10;

                Console.WriteLine(d);
            }
        }

        static void StringOut(out string ddd)
        {
            ddd = "out-variables";
        }

        static (string Name, int Age, DateTime BirthDay) GetFullName()
        {
            return ("Jeriffe", 34, DateTime.Parse("1983-12-19"));
        }

    }
}