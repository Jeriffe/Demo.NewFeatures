global using Demo.Feature_CSharp.Infrastructure;

//File Namespaces
//With this feature you can define the namespace on the file level like this:
namespace Demo.Feature_CSharp;


public class CSharp12 : ICSharp
{
    public void ShowNewFeatures()
    {
        Console.WriteLine($"**************begin {this.GetType().Name} new features********************");

        //Primary constructors
        PrimayConstructors();

        //Collection expressions

        //Inline arrays

        //Optional parameters in lambda expressions

        //ref readonly parameters

        //Alias any type

        //Experimental attribute

        //Interceptors


        Console.WriteLine($"********************end {this.GetType().Name} new features********************");
    }

    /// <summary>
    /// Primay Constructors
    /// </summary>
    class Student(string name, int score)
    {
        public string Name => name;
        public int Score => score;
        public void Greet() => Console.WriteLine($"Hello, {name}!");
    }
    private void PrimayConstructors()
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
