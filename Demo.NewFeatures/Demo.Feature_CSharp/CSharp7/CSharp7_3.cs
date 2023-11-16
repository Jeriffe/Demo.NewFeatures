using Demo.Feature_CSharp.Infrastructure;

namespace Demo.Feature_CSharp
{
    public class CSharp7_3 : ICSharp
    {
        public CSharp7_3()
        {

        }
        public void ShowNewFeatures()
        {
            /*7.3
            * Indexing fixed fields does not require pinning(无需固定即可访问固定的字段)
            * ref local variables may be reassigned(可以重新分配 ref 本地变量)
            * stackalloc arrays support initializers(可以使用 stackalloc 数组上的初始值设定项)
             
            * Enhanced generic constraints(可以使用其他泛型约束)
            * Tuples support == and != (可以使用元组类型测试 == 和 !=)
            * Attach attributes to the backing fields for auto-implemented properties(可以将属性附加到自动实现的属性的支持字段)
            * in method overload resolution tiebreaker(由 in 区分的参数的方法解析得到了改进)
            * Extend expression variables in initializers(重载解析的多义情况现在变得更少)
            */
        }


    }

}
