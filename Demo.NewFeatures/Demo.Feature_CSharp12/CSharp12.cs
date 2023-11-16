global using Demo.Feature_CSharp.Infrastructure;
using System.Diagnostics.CodeAnalysis;

//With this feature you can define the namespace on the file level like this:
namespace Demo.Feature_CSharp;


public class CSharp12 : ICSharp
{
    public void ShowNewFeatures()
    {
        Console.WriteLine($"**************begin {this.GetType().Name} new features********************");

        //Primary constructors
        PrimaryConstructors();

        //Collection expressions
        CollectionExpressions();

        //Optional parameters in lambda expressions
        OptionalParametersInLambdaExpressions();

        //Alias any type
        AliasAnyType();

        //Inline arrays
        InlineArrays();

        //ref readonly parameters
        RefReadonlyParameters();

        //Experimental attribute
        ExperimentalAttribute();

        //Interceptors
        Interceptors();

        Console.WriteLine($"********************end {this.GetType().Name} new features********************");
    }

    private void Interceptors()
    {
        //Interceptors are an experimental feature that allow you to substitute a call to a method with a call to another method at compile time
    }

    [Experimental("C#12 New Feature")]
    class Foo
    {
        [Experimental("C#12 New Feature")]
        public void Bar() { }
    }

    private void ExperimentalAttribute()
    {
        /*We can now mark types, methods, or assemblies with the ExperimentalAttribute
        //to indicate that they are experimental features
        //that may change or be removed in the future.
        */

        //var foo = new Foo(); // warning: 'Foo' is experimental
        //foo.Bar(); // warning: 'Foo.Bar()' is experimental
    }

    private void RefReadonlyParameters()
    {
        /*use the ref readonly modifier on parameters to indicate 
         * that they are passed by reference, but cannot be modified. 
         * This can improve the performance of your code by avoiding unnecessary copying, 
         * and also enforce the immutability of the arguments.
         */
        var one = 1;
        var two = 2;

        var max = Max(ref one, ref two);

        static ref readonly int Max(ref readonly int x, ref readonly int y)
            => ref x > y ? ref x : ref y;
    }

    [System.Runtime.CompilerServices.InlineArray(5)]
    public struct Buffer
    {
        private int _element0;
    }
    private void InlineArrays()
    {
        /*Inline arrays are a way to create an array of fixed size in a struct type, 
         * without using unsafe code or fixed size buffers.
         */
        var buffer = new Buffer();
        for (int i = 0; i < 5; i++)
        {
            buffer[i] = i;
        }
    }

    private void AliasAnyType()
    {
        //We can now use the using directive to create aliases for any type, not just named types.

    }

    private void OptionalParametersInLambdaExpressions()
    {
        //Define default values for parameters in lambda expressions, just like you can for methods or local functions
        var incrementBy = (int source, int increment = 1) => source + increment;

        Console.WriteLine(incrementBy(2)); // prints 3
        Console.WriteLine(incrementBy(2, 3)); // prints 5
    }

    private void CollectionExpressions()
    {
        //Collection expressions are a new syntax to create collections of elements.
        //Such as arrays, System.Span<T> and System.ReadOnlySpan<T>

        int[] someOtherNumbers = [4, 5, 6];
        List<int> numbers = [1, 2, 3, .. someOtherNumbers, 7, 8, 9];

        string[] moreFruits = ["orange", "pear"];
        IEnumerable<string> fruits = ["apple", "banana", "cherry", .. moreFruits];

        List<(string, int)> otherScores = [("Dave", 90), ("Bob", 80)];
        (string name, int score)[] scores = [("Alice", 90), .. otherScores, ("Charlie", 70)];

        Student[] students = [new Student("Alice", 90), new Student("Bob", 80)];

        Span<char> span = ['h', 'e', 'l', 'l', 'o'];

        // Create a jagged 2D array from variables:
        int[] row0 = [1, 2, 3];
        int[] row1 = [4, 5, 6];
        int[] row2 = [7, 8, 9];
        int[][] twoDFromVariables = [row0, row1, row2];
    }

    /// <summary>
    /// Primary Constructors
    /// </summary>
    class Student(string name, int score)
    {
        public string Name => name;
        public int Score => score;
        public void Greet() => Console.WriteLine($"Hello, {name}!");
    }
    private void PrimaryConstructors()
    {
        /*Primary constructors allow you to declare parameters for a class or struct
        in the same line as the type name.These parameters are in scope for the entire body of the type, 
        and can be used to initialize fields, properties, or methods.

        Primary constructors are immutable types that support value equality and deconstruction
        */

        var item = new Student("Claire", 99);
        Console.WriteLine("----------PrimayConstructors------------");
        Console.WriteLine($"{item.Name} got {item.Score} score.");
    }

    private void GlobalUsingDirective()
    {
        /*C# 10 introduces is global. Using global, you will be able to define global usings for the whole project. 
         * In general, it is recommended to create a separate file which will contain these imports, something like usings.cs.
         * 
         * global using Demo.Feature_CSharp.Infrastructure;
         * global using System.Linq;
         */
    }

    private void FileNamespaces()
    {
        /*
              namespace Demo.Feature_CSharp10
              {
                public class CSharp10
                {
                  ...
                }
              }

             //new in c# 10
              namespace Demo.Feature_CSharp10;

              public class CSharp10
              {
                ...
              }
       */
    }

    private void ExtendedPropertyPatterns()
    {
        /*从 C# 10 开始，可引用属性模式中嵌套的属性或字段。 例如，窗体的模式
         * { Prop1: { Prop2: pattern } }
         */

        /*对 Lambda 表达式的改进
         * Lambda 表达式可以具有自然类型，这使编译器可从 Lambda 表达式或方法组推断委托类型。
         * 如果编译器无法推断返回类型，Lambda 表达式可以声明该类型。
         * 属性可应用于 Lambda 表达式。
        */

        var p = new Person { Address = new Address { Street = "A street" } };

        //older
        if (p is Person { Address: { Street: "A street" } }) { }

        //new in C# 10
        if (p is Person { Address.Street: "A street" }) { }

    }

    private void ConstantInterpolatedStrings()
    {
        //older
        string ThankYouMessage1()
        {
            var message = "Thank you for buying the book!";
            var thankYouMessage = $"{message} Enjoy";

            return thankYouMessage;
        }

        //new in c# 10
        string ThankYouMessage2()
        {
            const string message = "Thank you for buying the book!";
            const string thankYouMessage = $"{message} Enjoy";

            return thankYouMessage;
        }
    }
}

public record RPerson(string FirstName, string LastName);
public readonly record struct RPoint(double X, double Y, double Z);

class Person
{
    public string FirstName { get; set; }

    public Address Address { get; set; }
}

public class Address
{
    public string Street { get; set; }

    public string ZipCode { get; set; }
}
