using Demo.Feature_CSharp.Infrastructure;

//https://devblogs.microsoft.com/dotnet/c-9-0-on-the-record/

namespace Demo.Feature_CSharp
{
    public class CSharp9 : ICSharp
    {
        public CSharp9()
        {

        }

        public void ShowNewFeatures()
        {
            Console.WriteLine($"**************begin {typeof(CSharp9).Name} new features********************");

            //仅初始化属性（Init-only properties）
            InitOnlyProperties();

            //初始化访问器和只读字段（Init accessors and readonly fields）
            InitAccessorsAndReadonlyFields();

            //记录（Records）
            {
                Records();
                {
                    //with 表达式（With-expressions）
                    WithExpressionsRecords();

                    //基于值的相等（Value-based equality）
                    ValuebasedEqualityRecords();

                    //继承（Inheritance）
                    InheritanceRecords();

                    PositionalRecords();


                    void WithExpressionsRecords()
                    {
                        var person = new RPerson { FirstName = "Mads", LastName = "Nielsen" };
                        //records allow for a new kind of expression; the with-expression:
                        var otherPerson = person with { LastName = "Torgersen" };

                        Console.WriteLine($"LastName of copy RPerson is : {otherPerson.LastName}");
                    }
                    void ValuebasedEqualityRecords()
                    {
                        var person = new RPerson { FirstName = "Mads", LastName = "Nielsen" };
                        //records allow for a new kind of expression; the with-expression:
                        var otherPerson = person with { LastName = "Torgersen" };

                        var originalPerson = otherPerson with { LastName = "Nielsen" };

                        Console.WriteLine($"ReferenceEquals(person, originalPerson): {ReferenceEquals(person, originalPerson)}");
                        Console.WriteLine($"Equals(person, originalPerson): {Equals(person, originalPerson)}");
                    }
                    void InheritanceRecords()
                    {
                        //Say that I create a Student but store it in a Person variable:
                        RPerson student = new RStudent { FirstName = "Mads", LastName = "Nielsen", ID = 129 };

                        //A with-expression will still copy the whole object and keep the runtime type:
                        var otherStudent = student with { LastName = "Torgersen" };

                        Console.WriteLine(otherStudent is RPerson); // true
                    }
                    void PositionalRecords()
                    {
                        var person = new PositionalRecords("Mads", "Torgersen"); //（positional construction）
                        var (f, l) = person;                          //（positional deconstruction）
                    }

                }
                void Records()
                {
                    //If you find yourself wanting the whole object to be immutable and behave like a value,
                    //then you should consider declaring it as a record:
                    var person = new RPerson { FirstName = "Mads", LastName = "Nielsen" };
                }
            }
           
            //顶级程序（Top-level programs） :  refer to Program.cs
            ToplevelPrograms();

            //改进的模式匹配（Improved pattern matching）
            {
                SimpletypePatterns();

                RelationalPatterns();

                LogicalPatterns();

                NotPatterns();

                void SimpletypePatterns()
                {
                    var input = new RStudent();

                    // is pattern with Type
                    if (input is RPerson)
                    { }

                    // case pattern with Type
                    switch (input)
                    {
                        case RPerson:
                            break;
                    }



                }
                void RelationalPatterns()
                {
                    //C# 9 allows you to use relational pattern which enables the use of <, >, <= and >= in patterns
                    var product = new Product { Name = "Food", CategoryId = 4 };
                    var tax = GetTax(product); // Returns 5

                    // Relational pattern
                    static int GetTax(Product p) => p.CategoryId switch
                    {
                        1 => 0,
                        < 5 => 5,
                        > 20 => 15,
                        _ => 10
                    };
                }
                void LogicalPatterns()
                {
                    //C# 9 lets you use logical operators like ‘and’, ‘or’ and ‘not’ 
                    var product = new Product { Name = "Food", CategoryId = 4 };
                    GetTax(product); // Returns 5


                    // Relational pattern combined with logical patterns
                    static int GetTax(Product p) => p.CategoryId switch
                    {
                        0 or 1 => 0,
                        > 1 and < 5 => 5,
                        > 20 => 15,
                        _ => 10
                    };
                }
                void NotPatterns()
                {
                    //‘not‘ logical operator can also be used in a if statement (it works also with a ternary statement),
                    var product = new Product { Name = "Food", CategoryId = 4 };

                    GetDiscount(product); // Returns 25

                    GetDiscount2(product); // Returns 25

                    // Not pattern
                    static int GetDiscount(Product p)
                    {
                        if (p is not ElectronicProduct)
                        {
                            return 25;
                        }

                        return 0;
                    }

                    static int GetDiscount2(Product p) => p is not ElectronicProduct ? 25 : 0;
                }
            };

            //目标类型的 new 表达式（Target-typed new expressions）
            TargettypedNewExpressions();


            Console.WriteLine($"********************end {this.GetType().Name} new features********************");
        }

        private void TargettypedNewExpressions()
        {
            //old 
            Person p = new Person();
            Location[] l1 = { new Location(1, 2), new Location(5, 2), new Location(5, -3) };

            //new
            Person pnew = new();
            Location[] l2 = { new(1, 2), new(5, 2), new(5, -3), new(1, -3) };
        }

        private void InitOnlyProperties()
        {
            //Init-only properties introduce an init accessor that is a variant of the set accessor
            //which can only be called during object initialization,  refer to  Person class
            var person = new Person { FirstName = "Mads", }; // OK

            // person.FirstName = "Mads"; // ERROR!
        }

        private void InitAccessorsAndReadonlyFields()
        {
            //init 访问器只能在初始化期间调用，所以允许它们更改封闭类的只读(readonly)字段，就像在构造函数中一样。
            var person = new Person { Age = 36 }; // OK

            //  person.Age = 36; // ERROR!
        }


        private void ToplevelPrograms()
        {
            // refer to Program.cs

            /*在 C# 9.0 中，您可以在顶级编写主程序(main program)：
                using System;

                Console.WriteLine("Hello World!");
             */
        }
    }
    public record RecordsWithoutPositional
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public RecordsWithoutPositional(string firstName, string lastName)
          => (FirstName, LastName) = (firstName, lastName);
        public void Deconstruct(out string firstName, out string lastName)
          => (firstName, lastName) = (FirstName, LastName);
    }
    public record PositionalRecords(string FirstName, string LastName);

    internal class Location
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public Location(int top, int left)
        {
            Top = top;
            Left = left;
        }
    }

    public record RPerson
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
    }

    public record RStudent : RPerson
    {
        public int ID;
    }

    public class Person
    {
        private readonly int age;

        public string? FirstName
        {
            get; init;
        }
        public string? LastName
        {
            get; init;
        }
        public int? Age
        {
            get => age;
            init => age = (value ?? throw new ArgumentNullException(nameof(Age)));
        }
    }


    public class Product
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }

    public class Book : Product
    {
        public string ISBN { get; set; }
    }

    public class ElectronicProduct : Product
    {
        public bool HasBluetooth { get; set; }
    }
}



