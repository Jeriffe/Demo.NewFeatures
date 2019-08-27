using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.NewFeatures
{
    public class CSharp2 : ICSharp
    {
        public CSharp2()
        {
        }

        public void ShowNewFeatures()
        {
            GenericFeature();

            AnonymousMethod();

            NullableTypes();
        }

        private void NullableTypes()
        {
            NullableTypes nt = new NullableTypes();

            nt.GetRecord(0);
        }

        private void AnonymousMethod()
        {
            Action<string> action = delegate (string str) { Console.WriteLine(str); };

            action("Anonymous Method Test");

        }
  

        private void GenericFeature()
        {
            Node<String> objNode = new Node<string>("John Charles");
            Node<String> objNext = new Node<string>("olamendy");
            objNode.Append(objNext);

            Node<int> objNode1 = new Node<int>(3);
            Node<int> objNext1 = new Node<int>(4);
            objNode1.Append(objNext1);
        }
    }

    public class NullableTypes
    {
        public class Record
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int? ParentID { get; set; }
        }

        protected DataTable people;

        public NullableTypes()
        {
            people = new DataTable();

            people.Columns.Add(new DataColumn("ID", typeof(int)) { AllowDBNull = false });
            people.Columns.Add(new DataColumn("Name", typeof(string)) { AllowDBNull = false });
            people.Columns.Add(new DataColumn("ParentID", typeof(int)) { AllowDBNull = true });

            DataRow row = people.NewRow();
            row["ID"] = 1;
            row["Name"] = "Marc";
            row["ParentID"] = DBNull.Value; // Marc does not have a parent!
            people.Rows.Add(row);
        }

        public Record GetRecord(int idx)
        {
            return new Record()
            {
                ID = people.Rows[idx].Field<int>("ID"),
                Name = people.Rows[idx].Field<string>("Name"),
                ParentID = people.Rows[idx].Field<int?>("ParentID"),
            };
        }
    }


    public class Node<T>
    {
        private T m_objGenericObject;
        private Node<T> m_objNext;

        public Node(T objGenericObject)
        {
            this.m_objGenericObject = objGenericObject;
        }

        public T Data { get { return this.m_objGenericObject; } }

        public Node<T> Next { get { return this.m_objNext; } }
        public void Append(Node<T> objNewNode)
        {
            if (m_objNext == null)
            {
                m_objNext = objNewNode;
                return;
            }

            m_objNext.Append(objNewNode);
        }
    }
}
