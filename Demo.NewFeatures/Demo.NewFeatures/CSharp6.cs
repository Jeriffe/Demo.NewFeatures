using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

//5. Use Static --Import
using static System.IO.File;

namespace Demo.NewFeatures
{
    public class CSharp6 : ICSharp
    {
        private static Logger logger;

        //1. Auto-property initializers 自动属性默认初始化
        public string FirstName { get; set; } = "Jeriffe";

        public string LastName { get; set; } = "Jiang";
        //2. Getter-only auto-properties 自动只读属性默认初始化
        public int Age { get; } = 32;

        public CSharp6()
        {
            FirstName = "Summer";
            Age = 31;
        }


        public void ShowNewFeatures()
        {
            //Auto property initializers
            //Read only auto properties

            ExpressionBodiedMembers();

            StringInterpolation();

            UseStatic();

            NullConditionalOpertaor();

            NameofExpression();

            IndexInitializer();

            AwaitInCatchFinallyBlock();
        }


        //3. Expression bodied members
        //3.1 表达式为主体的函数
        public string ExpressionBodiedMembers() => string.Format("Welcome {0}", FirstName);

        //3.2 表达式为主体的属性(赋值)
        public string Name2 => "hello world";

        //4. String interpolation 字符串格式化
        private string StringInterpolation()
        {
            return $"{FirstName} {LastName}";
        }

        //5. Use Static 静态类导入
        void UseStatic()
        {
            if (Exists(@"C:\usestatic.txt"))
            {

            }
        }

        //6. Null-conditional operators Null条件运算符
        private string NullConditionalOpertaor()
        {
            var obj = new CSharp6();

            //old way
            if (obj != null)
            {
                string name = obj.FirstName;
            }

            //new way
            return $"{obj?.FirstName} {obj?.LastName}";
        }

        //7. nameof表达式
        /// <summary>
        /// The nameof expression evaluates to the name of a symbol. 
        /// It's a great way to get tools working 
        /// whenever you need the name of a variable, a property, or a member field
        /// </summary>
        private void NameofExpression()
        {
            string name = "Jeriffe";
            //console will print: name
            Console.WriteLine(nameof(name));
        }

        //8. Index initializers 索引初始化
        private void IndexInitializer()
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

        //9.await in catch finally block
        public async Task<string> AwaitInCatchFinallyBlock()
        {
            await logger.Log("Enter the " + nameof(AwaitInCatchFinallyBlock));

            var client = new System.Net.Http.HttpClient();
            var streamTask = client.GetStringAsync("https://localHost:10000");
            try
            {
                var responseText = await streamTask;
                return responseText;
            }
            catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
            {
                await logger.Log("Recovered from redirect", e);
                return "Site Moved";
            }
            finally
            {
                await logger.Exit();
                client.Dispose();
            }
        }
    }

    internal class Logger
    {
        public Task Exit()
        {
            throw new NotImplementedException();
        }

        public Task Log(string v, HttpRequestException e = null)
        {
            throw new NotImplementedException();
        }
    }
}
