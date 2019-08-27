using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.BasicFeatures
{
    struct A
    {
        public int A1;
        public int B1;

        /* C# forbide to declare the No-parameter constructor in Struct.
         * Struct 默认的构造器把数值初始化为0，引用类型初始化为null
         * when we define a Struct, the fields can NOT initialzie when it been declared. these wil been initialzied in the constructor 
         * default construtor will initialize the value type B1 to 0; if B1 is ref type, B1 will be initialized to null.
         * */
        public A(int a1) : this()
        {
            A1 = a1;
        }

        /* 	Structs cannot contain explicit parameterless constructors	 
                public A() 
                {

                }
       */
    }

    class StructTest
    {
        public void Test_Initialize()
        {

            //call default constructor to initialize the fields.
            A a = new A();
            Console.WriteLine($"A.A1 value is {a.A1}, A.B1 value is {a.B1}");

             
            A a1;
            a1.A1 = 1;
            a1.B1 = 0;
            Console.WriteLine($"A.A1 value is {a1.A1}, A.B1 value is {a1.B1}");
        }


        public void Test_ParameterPassing()
        {
            A a;
            //call default constructor to initialize the others fields.
            a.B1 = 10;

        }
    }
}
