using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BasicFeatures
{
    public class AM
    {
        public class A_Public { public static void M() { } }

        internal class A_Internal { public void M() { } }

        protected class A_Protected { protected void M() { } }

        protected internal class AA_ProtectedInternal { public void M() { } }

        private protected class AA_PrivateProtected { public void M() { } }
    }
}

namespace Demo.BasicFeatures.AAAAAA
{
    class T
    {
        public T()
        {
            var a = new AM.A_Public();

            var aa = new AM.A_Internal();

            var aaa = new AM.AA_ProtectedInternal();
        }
    }

    public class AM_Derived2 : AM
    {
        void M()
        {
            var a = new A_Public();

            var aa = new AA_ProtectedInternal();

            var aaa = new A_Protected();

            var aaaa = new AA_PrivateProtected();
        }

        class A_Protected_Derived : A_Protected
        {

            void M2()
            {
                base.M();
            }
        }

    }

}

//NEED MOVE TO ANOTHER ASSEMBLY
namespace Demo.AAAAAA
{
    public class Poly_Derived : Demo.BasicFeatures.AM
    {
        void M()
        {
            var a = new A_Public();

            var aa = new AA_ProtectedInternal();

            var aaa = new A_Protected();
        }
    }

    public class Poly_Call
    {
        void M()
        {
            Demo.BasicFeatures.AM.A_Public.M();
        }
    }
}

