using Demo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Demo.Feature_CSharp8
{
    public class CSharp8 : ICSharp
    {
        public CSharp8()
        {

        }
        public void ShowNewFeatures()
        {
            Console.WriteLine($"********************begin {this.GetType().Name} new features********************");

            //Nullable reference types 可空引用类型
            NullableReferenceTypes();

            //Async streams 异步流
            AsynchronousStreams();

            //Readonly members / 只读成员
            ReadonlyMembers();

            //Default implementations of interface members 接口成员的默认实现
            DefaultInterfaceMethods();

            //Pattern matching enhancements 模式匹配增强功
            PatternMatchingEnhancements();

            //Using declarations / Using 声明
            UsingDeclarations();

            //Static local functions / 静态本地函数
            StaticLocalFunctions();

            //Disposable ref structs / 可处置的 ref 结构
            DisposableRefStructs();

            //Ranges and indices 范围和索引
            RangesAndIndices();

            //Null-coalescing assignment / Null合并赋值
            NullCoalescingAssignment();

            //Unmanaged constructed types / 非托管构造类型
            UnmanagedConstructedTypes();

            //stackalloc in nested expressions / 嵌套表达式中的 stackalloc
            StackallocInNestedExpressions();
            Console.WriteLine($"********************end {this.GetType().Name} new features********************");
        }

        private void NullableReferenceTypes()
        {
            //此特性的目的是帮助处理无处不在的空引用异常
            string s = null;// Warning: Assignment of null to non-nullable reference type
            string? s2 = null;
        }
        private void AsynchronousStreams()
        {
        }


        private void ReadonlyMembers()
        {
            var rm = new Struct_ReadonlyMembers();

            Console.WriteLine(rm.Distance);
        }

        private void DefaultInterfaceMethods()
        {
            /*"Interfaces are immutable once they've been released! 
            This is a breaking change!" C# 8.0 adds default interface implementations for upgrading interfaces. 
            The library authors can add new members to the interface and provide a default implementation for those members.
            */

        }

        private void PatternMatchingEnhancements()
        {

            //1/Switch enhancement
            {
                var color = FromRainbowClassic(Rainbow.Blue);
                //Older switch
                static Color FromRainbowClassic(Rainbow colorBand)
                {
                    switch (colorBand)
                    {
                        case Rainbow.Red:
                            return Color.FromArgb(0xFF, 0x00, 0x00);
                        case Rainbow.Orange:
                            return Color.FromArgb(0xFF, 0x7F, 0x00);
                        case Rainbow.Yellow:
                            return Color.FromArgb(0xFF, 0xFF, 0x00);
                        case Rainbow.Green:
                            return Color.FromArgb(0x00, 0xFF, 0x00);
                        case Rainbow.Blue:
                            return Color.FromArgb(0x00, 0x00, 0xFF);
                        default:
                            throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand));
                    };
                }

                /*New in C#8 switch 
                    变量位于 switch 关键字之前。 不同的顺序使得在视觉上可以很轻松地区分 switch 表达式和 switch 语句
                    将 case 和: 元素替换为 =>。 它更简洁，更直观
                    将 default 事例替换为 _ 弃元
                    正文是表达式，不是语句
               */

                color = FromRainbow(Rainbow.Blue);

                static Color FromRainbow(Rainbow colorBand) =>
                   colorBand switch
                   {
                       Rainbow.Red => Color.FromArgb(0xFF, 0x00, 0x00),
                       Rainbow.Orange => Color.FromArgb(0xFF, 0x7F, 0x00),
                       Rainbow.Yellow => Color.FromArgb(0xFF, 0xFF, 0x00),
                       Rainbow.Green => Color.FromArgb(0x00, 0xFF, 0x00),
                       Rainbow.Blue => Color.FromArgb(0x00, 0x00, 0xFF),
                       _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand)),
                   };
            }

            //2.Property patterns 属性模式
            static decimal ComputeSalesTax(Address location, decimal salePrice) =>
                location switch
                {
                    { State: "WA" } => salePrice * 0.06M,
                    { State: "MN" } => salePrice * 0.075M,
                    { State: "MI" } => salePrice * 0.05M,
                    _ => 0M
                };
        }

        private void UsingDeclarations()
        {
            /* A using declaration is a variable declaration preceded by the using keyword.
             * It tells the compiler that the variable being declared should be disposed at the end of the enclosing scope.
             */

        }

        private void StaticLocalFunctions()
        {
            int y = 5;
            int x = 7;
            var sum = Add(x, y);

            static int Add(int left, int right) => left + right;
        }

        private void DisposableRefStructs()
        {
            /*A struct declared with the ref modifier may not implement any interfaces and so cannot implement IDisposable. 
             * Therefore, to enable a ref struct to be disposed, 
             * it must have an accessible void Dispose() method. This also applies to readonly ref struct declarations.*/
        }



        private void RangesAndIndices()
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
            var quickBrownFox = words[1..4];   //words[1] words[2] words[3]
            var lazyDog = words[^2..^0];// words[^2] words[^1]
            var allWords = words[..]; // contains all.
            var firstPhrase = words[..4]; // contains "The" "quick" "through" "fox"
            var lastPhrase = words[6..]; // contains "the", "lazy" "dog"
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
        private void NullCoalescingAssignment()
        {
            /*C# 8.0 introduces the operator ??=. 
             * You can use it to assign the value of its right-hand operand to its left-hand operand only if the left-hand operand evaluates to null.
             */
            List<int> numbers = null;
            int? i = null;

            numbers ??= new List<int>();
            numbers.Add(i ??= 17);
            numbers.Add(i ??= 20);

            Console.WriteLine(string.Join(" ", numbers));  // output: 17 17
            Console.WriteLine(i);  // output: 17
        }

        private void UnmanagedConstructedTypes()
        {
            Span<Coords<int>> coordinates = stackalloc[]
            {
                new Coords<int> { X = 0, Y = 0 },
                new Coords<int> { X = 0, Y = 3 },
                new Coords<int> { X = 4, Y = 0 }
            };

        }

        private void StackallocInNestedExpressions()
        {
            Span<int> numbers = stackalloc[] { 1, 2, 3, 4, 5, 6 };
            var ind = numbers.IndexOfAny(stackalloc[] { 2, 4, 6, 8 });
            Console.WriteLine(ind);  // output: 1
        }


        //the Coords<int> type is an unmanaged type in C# 8.0 and later
        public struct Coords<T>
        {
            public T X;
            public T Y;
        }


    }

    internal class Address
    {
        public string State { get; internal set; }
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
    enum Rainbow
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
    }
}
