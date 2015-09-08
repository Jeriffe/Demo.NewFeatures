using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//6. Use Static --Import
using static System.IO.File;

namespace Demo.NewFeatures
{
    /*Async Feature (Asynchronous Methods)
    Caller Information (Caller info attributes)
    */
    public class CSharp5
    {

        //1. Auto-property initializers 自动属性默认初始化
        public string FirstName { get; set; } = "Jeriffe";

        public string LastName { get; set; } = "Jiang";
        //2. Getter-only auto-properties 自动只读属性默认初始化
        public int Age { get; } = 32;

        public CSharp5()
        {
            FirstName = "Summer";
            Age = 31;
        }

        //3. Expression bodied members
        //3.1 表达式为主体的函数
        public string Welcome() => string.Format("Welcome {0}", FirstName);

        //3.2 表达式为主体的属性(赋值)
        public string Name2 => "hello world";

        //4. String interpolation 字符串格式化
        public string StringInterpolation()
        {
            return $"{FirstName} {LastName}";
        }

        //5. Null-conditional operators Null条件运算符
        string NullConditionalOpertaor()
        {
            var obj = new CSharp5();

            /* 
            var obj = new CSharp5();
            if (obj != null)
            {
                string name = obj.Name;
            }
            */
            return $"{obj?.FirstName} {obj?.LastName}";
        }

        //6. Use Static 静态类导入
        void UseStatic()
        {
            if (Exists(@"C:\usestatic.txt"))
            {

            }
        }

        //7. Index initializers 索引初始化
        void IndexInitializer()
        {
            // original initializer
            var dict = new Dictionary<int, string>
                        {
                            {1, "string1" },
                            {2, "string2" },
                            {3, "string3" }
                        };

            // new initializer
            dict = new Dictionary<int, string>
            {
                [1] = "string1",
                [2] = "string2",
                [3] = "string3"
            };

            foreach (var kv in dict)
            {
                Console.WriteLine($"{kv.Key} -- {kv.Value}");
            }
        }

        //8. nameof表达式
    }
}
