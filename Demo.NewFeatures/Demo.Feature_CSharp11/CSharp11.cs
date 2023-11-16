global using Demo.Feature_CSharp.Infrastructure;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Demo.Feature_CSharp;

public class CSharp11 : ICSharp
{
    public void ShowNewFeatures()
    {
        Console.WriteLine($"**************begin {this.GetType().Name} new features********************");

        //Static abstract members in interfaces
        StaticAbstractMembersInInterfaces();

        //Raw string literals
        RawStringLiterals();

        // Generic math support

        // Generic attributes
        GenericAttributes();
        //UTF - 8 string literals
        UTF_8StringLiterals();

        // Newlines in string interpolation expressions
        NewlinesInStringInterpolationExpressions();

        // List patterns
        ListPatterns();

        /* File-local types
         * 
         * you can use the file access modifier to create a type whose visibility is scoped to the source file 
         * in which it is declared.This feature helps source generator authors avoid naming collisions.
        */

        // Required members
        RequiredMembers();
        //  Auto-default structs
        AutoDefaultStructs();
        //  Pattern match Span<char> on a constant string
        
        //  Extended nameof scope
        ExtendedNameofScope();

        //  Numeric IntPtr

        /*  ref fields and scoped ref
         *  
         *You can declare ref fields inside a ref struct. 
         *This supports types such as System.Span<T> without special attributes or hidden internal types.
         */


        Console.WriteLine($"********************end {this.GetType().Name} new features********************");
    }

    // Interface specifies static properties and operators
    public interface IAddable<T> where T : IAddable<T>
    {
        static abstract T Zero { get; }
        static abstract T operator +(T t1, T t2);
    }

    // Generic algorithms can use static members on T
    public static T AddAll<T>(T[] ts) where T : IAddable<T>
    {
        T result = T.Zero;                   // Call static operator
        foreach (T t in ts) { result += t; } // Use `+`
        return result;
    }

    private void StaticAbstractMembersInInterfaces()
    {
        /*There is currently no way to abstract over static members 
         * and write generalized code that applies across types that define those static members. 
         * This is particularly problematic for member kinds that only exist in a static form, notably operators.
         */
    }

    public class MyAttr : Attribute
    {
        private readonly string _paramName;

        public MyAttr(string paramName)
        {
            _paramName = paramName;
        }
    }
    public class MyClass_ExtendedNameofScope
    {
        [MyAttr(nameof(param))]
        public void Method_ExtendedNameofScope(int param, [MyAttr(nameof(param))] int anotherParam)
        { }
    }
    private void ExtendedNameofScope()
    {
        new MyClass_ExtendedNameofScope().Method_ExtendedNameofScope(0, 1);
    }

    //GenericAttributes
    class MyType { }
    class GenericAttribute<T> : Attribute where T : MyType { private T _type; }
    [GenericAttribute<MyType>]
    class MyClass { }

    private void GenericAttributes()
    {
        //C#10
        /*
         class MyType { }

         class MyAttribute : Attribute
         {
             private Type type;
             public MyAttribute(Type type) { _type = type; }
         }

         [MyAttribute(typeof(MyType))]
         class Myclass { }
        */
    }

    // before C#11 doesn't complied -- Auto-implemented property 'Person.Age  must be fully assigned before control is returned to the caller. 
    struct Person_AutoDefaultStructs
    {
        public Person_AutoDefaultStructs(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
    private void AutoDefaultStructs()
    {
        var p = new Person_AutoDefaultStructs("Gray");
        p.Age = 28;
    }

    private void NewlinesInStringInterpolationExpressions()
    {
        //Allows any valid C# code between { }, including newlines, to improve code readability
        // switch expression in string interpolation 
        int month = 5;
        string season = $"The season is {month switch
        {
            1 or 2 or 12 => "winter",
            > 2 and < 6 => "spring",
            > 5 and < 9 => "summer",
            > 8 and < 12 => "autumn",
            _ => "Unknown. Wrong month number",
        }}.";

        Console.WriteLine(season);
        // The season is spring.

        // LINQ query in string interpolation 
        int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };
        string message = $"The reversed even values of {nameof(numbers)} are {string.Join(", ", numbers.Where(n => n % 2 == 0)
              .Reverse())}.";

        // The reversed even values of numbers are 6, 4, 2.
        Console.WriteLine(message);
    }

    private void ListPatterns()
    {
        /*Expand pattern matching to match sequences of elements in a list or an array.
         * You can use list patterns with any pattern(including property, type, constant, &relational patterns).
         */
        var numbers = new[] { 1, 2, 3, 4 };
        // List and constant patterns 
        Console.WriteLine(numbers is [1, 2, 3, 4]); // True 
        Console.WriteLine(numbers is [1, 2, 4]); // False

        // List and discard patterns 
        Console.WriteLine(numbers is [_, 2, _, 4]); // True 
        Console.WriteLine(numbers is [.., 3, _]); // True

        // List and logical patterns 
        Console.WriteLine(numbers is [_, >= 2, _, _]); // True
    }

    private void UTF_8StringLiterals()
    {
        /*Allows converting only UTF-8 characters to their byte representation at compile time
         * The language will provide the u8 suffix on string literals to force the type to be UTF8.
         * The suffix is case -insensitive, U8 suffix will be supported and will have the same meaning as u8 suffix
         * When the u8 suffix is used, the value of the literal is a ReadOnlySpan < byte > containing a UTF-8 byte representation of the string.
         */

        // C# 10
        byte[] array10 = Encoding.UTF8.GetBytes("Hello World");

        //C# 11

        var s2 = "hello"u8;                // Okay and type is ReadOnlySpan<byte>
        ReadOnlySpan<byte> s3 = "hello"u8; // Okay.
        byte[] s5 = "hello"u8.ToArray();   // Okay.
        /*
        string s1 = "hello"u8;             // Error
        byte[] s4 = "hello"u8;             // Error - Cannot implicitly convert type 'System.ReadOnlySpan<byte>' to 'byte[]'.

        Span<byte> s6 = "hello"u8;         // Error - Cannot implicitly convert type 'System.ReadOnlySpan<byte>' to 'System.Span<byte>'.
        */
    }

    private void RawStringLiterals()
    {
        /*It allows containing of arbitrary text without escaping.
         * The format is minimum 3 double quotes """.."""
         * Combining with string interpolation, the count of $ denotes how many braces in a row start & end the interpolation.
         */
        string name = "Shehryar";
        string surname = "Khan";

        //C# 10
        string jsonString10 =
          $@"
          {{
            'Name': {name},
            'Surname': {surname}
          }}
          ";

        //C# 11
        string jsonString11 =
          $$"""
          {
            "Name": {{name}},
            "Surname": {{surname}}
          }
          """;
    }

    private void RequiredMembers()
    {
        // Initializations with required properties 
        var p1 = new Person { Name = "Shehryar", Surname = "Khan" };
        Person p2 = new("Shehryar", "Khan");

        // Initializations with missing required properties 
        // var p3 = new Person { Name = "Shehryar" };
        //  Person p4 = new();
    }

    public class Person
    {
        public Person() { }

        [SetsRequiredMembers]
        public Person(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required string Surname { get; set; }
    }
}