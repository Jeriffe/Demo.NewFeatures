using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.NewFeatures
{
    public class CSharp4 : ICSharp
    {
        public CSharp4()
        {

        }

        public void ShowNewFeatures()
        {

            NamedParameters();

            OptionalParameters();

            MoreCOMSupport();

            DymamicBinding();
        }

        private void DymamicBinding()
        {
            //dynamic type
            //Initializes a new ExpandoObject that does not have members.
            dynamic Customer = new ExpandoObject();
            Customer.Name = "Lucy";
            Customer.Age = 20;
            Customer.Female = true;
            Console.WriteLine(Customer.Name + Customer.Age + Customer.Female);

            //dynamic method
            Console.WriteLine(exampleMethod(10));
            Console.WriteLine(exampleMethod("value"));
        }
        public dynamic exampleMethod(dynamic d)
        {
            dynamic local = "Local variable";
            int two = 2;

            if (d is int)
            {
                return local;
            }
            else
            {
                return two;
            }
        }

        private void MoreCOMSupport()
        {
            /*
            object foo = "MyFile.txt";
            object bar = Missing.Value;
            object optional = Missing.Value;

            Document doc = (Document)Application.GetDocument(ref foo, ref bar, ref optional);
            doc.CheckSpelling(ref optional, ref optional, ref optional, ref optional);


            var doc = Application.GetDocument("MyFile.txt");
            doc.CheckSpelling();

            */
        }

        private void OptionalParameters()
        {
            // old
            var nop = new Named_OptionalParameters();
            nop.Process("foo", false, null);
            nop.Process("foo", false);
            nop.Process("foo");

            ArrayList myArrayList = new ArrayList();
            nop.Process_New("foo", false, myArrayList);
            nop.Process_New("foo", true);
            nop.Process_New("foo");
        }

        private void NamedParameters()
        {
            var nop = new Named_OptionalParameters();
            ArrayList myArrayList = new ArrayList();


            // nop.Process("foo", myArrayList); // Invalid!

            nop.Process_New("foo", true); // valid, moreData omitted
            nop.Process_New("foo", true, myArrayList); // valid
            nop.Process_New("foo", moreData: myArrayList); // valid, ignoreWS omitted
            nop.Process_New("foo", moreData: myArrayList, ignoreWS: false); // valid, but silly
        }
    }

    class Named_OptionalParameters
    {
        public void Process(string data)
        {
            Process(data, false);
        }

        public void Process(string data, bool ignoreWS)
        {
            Process(data, ignoreWS, null);
        }

        public void Process(string data, bool ignoreWS, ArrayList moreData)
        {
            // Actual work done here
        }

        public void Process_New(string data, bool ignoreWS = false, ArrayList moreData = null)
        {
        }
    }
}
