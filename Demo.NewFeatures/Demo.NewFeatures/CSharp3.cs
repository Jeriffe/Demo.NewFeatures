using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Demo.Infrastructure;

namespace Demo.NewFeatures
{
    public class CSharp3 : ICSharp
    {
        //Auto properties
        public int Age { get; private set; }

        public CSharp3() { }

        public void ShowNewFeatures()
        {
            Console.WriteLine($"********************begin {this.GetType().Name} new features********************");
            AutoProperties();

            AnonymousTypes();

            LambdaExpressions();

            ExtensionMethods();

            ExpressionTrees();

            ImplicitTypeingVariables();

            ObjectAndCollectionInitializers();

            PartialMethod();
            Console.WriteLine($"********************end {this.GetType().Name} new features********************");
        }

        private void PartialMethod()
        {
            /*
             * A partial method has its signature defined in one part of a partial type, 
             * and its implementation defined in another part of the type. 
             * Partial methods enable class designers to provide method hooks, similar to event handlers, 
             * that developers may decide to implement or not. If the developer does not supply an implementation, 
             * the compiler removes the signature at compile time. The following conditions apply to partial methods:
             */

            new Partial_A().Call_Partial();
        }

        private void ObjectAndCollectionInitializers()
        {
            var r = new R { ID = 1, Name = "Mac" };

            var records = new List<R>()
            {
               new R { ID = 1, Name = "Rudolf" },
               new R { ID = 2, Name = "Rickey" },
            };
        }

        private void AutoProperties()
        {
            Age = 14;
            Console.WriteLine(Age);
        }

        private void ExpressionTrees()
        {
            /*表达式树以树形数据结构表示代码，其中每一个节点都是一种表达式，
             * 比如方法调用和 x < y 这样的二元运算等。
             * 你可以对表达式树中的代码进行编辑和运算。
             * 以便于动态修改可执行代码、在不同数据库中执行 LINQ 查询以及创建动态查询。 
             * https://www.cnblogs.com/liqingwen/p/5868688.html
             */

            Expression<Action<int>> actionExpression = n => Console.WriteLine(n);
            Expression<Func<int, bool>> funcExpression1 = (n) => n < 0;
            Expression<Func<int, int, bool>> funcExpression2 = (n, m) => n - m == 0;

            //通过 Expression 类创建表达式树
            //  lambda：num => num == 0
            ParameterExpression pExpression = Expression.Parameter(typeof(int));    //参数：num
            ConstantExpression cExpression = Expression.Constant(0);    //常量：0
            BinaryExpression bExpression = Expression.MakeBinary(ExpressionType.Equal, pExpression, cExpression);   //表达式：num == 0
            Expression<Func<int, bool>> lambda = Expression.Lambda<Func<int, bool>>(bExpression, pExpression);  //lambda 表达式：num => num == 0

        }

        private void LambdaExpressions()
        {
            var records = new List<R>();
            var idAndName = from r in records
                            where r.Name == "Marc"
                            select new { r.ID, r.Name };

            var idAndName2 = records.All(r => r.Name == "Marc");
        }

        private void ExtensionMethods()
        {
            string graphVizObjectName = "abc".Quote();

            DateTime.Now.ExtensionMethond();
        }

        private void AnonymousTypes()
        {
            var myAnonymousType = new
            {
                FirstProperty = "First",
                SecondProperty = 2,
                ThirdProperty = true
            };
        }

        private void ImplicitTypeingVariables()
        {
            // old:
            Dictionary<string, int> explicitDict = new Dictionary<string, int>();
            foreach (string item in "a,b,c,d,e".Split(','))
            {

            }

            // new:
            var implicitDict = new Dictionary<string, int>();
            foreach (var item in "a,b,c,d,e".Split(','))
            {

            }
        }
        class R
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }

        //signature defined in one part 
        partial class Partial_A
        {
            partial void Partial_M(string s);
        }

        // implementation defined in another part of the type
        partial class Partial_A
        {
            partial void Partial_M(String s)
            {
                Console.WriteLine("Something happened: {0}", s);
            }

            public void Call_Partial()
            {
                Partial_M("Partial Method Test");
            }
        }
    }

    public static class StringHelpersExtensions
    {
        public static string Quote(this String src)
        {
            return "\"" + src + "\"";
        }

        public static void ExtensionMethond(this DateTime dateTime)
        {

        }
    }

}
