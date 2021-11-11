using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DoYouPolymorphismToday
{
    class Polymorphism
    {
        static void MainEntry()
        {
            // 图书馆早上准时开门；
            Library library = new Library();

            // 怎么每天只需开大门其他楼层的门就自动打开了吗？
            // Floor floor1

            // 同学们一大早就归还很多图书。
            List<Book> books = new List<Book>();
            // 省略填充books列表的代码
            // 

            // 果然每本书自己飞回各自所属的原位哟。
            foreach (Book book in books)
            {
                book.Return(library);
            }
        }
    }
    class Library
    {
        public Floor Floor2 { get; private set; }
        public Floor Floor3 { get; private set; }
        public Floor Floor4 { get; private set; }
    }
    class Floor
    {
        public IList<Book> MathShelves { get; internal set; }
        public IList<Book> PhysicsShelves { get; internal set; }


        public IList<Book> ManagementShelves { get; internal set; }
        public IList<Book> EconomicsShelves { get; internal set; }


        public IList<Book> ProgrammingShelves { get; internal set; }
        public IList<Book> DatabaseShelves { get; internal set; }
    }

    abstract class Book
    {
        public abstract void Return(Library library);


    }

    abstract class Floor2Book : Book { }

    abstract class Floor3Book : Book { }

    abstract class Floor4Book : Book { }

    class MathBook : Floor2Book
    {
        public override void Return(Library library)
        {
            library.Floor2.MathShelves.Add(this);
        }
    }

    class PhysicsBook : Floor2Book
    {
        public override void Return(Library library)
        {
            library.Floor2.PhysicsShelves.Add(this);
        }
    }


    class ManagementBook : Floor3Book
    {
        public override void Return(Library library)
        {
            library.Floor3.ManagementShelves.Add(this);
        }
    }

    class EconomicsBook : Floor3Book
    {
        public override void Return(Library library)
        {
            library.Floor3.EconomicsShelves.Add(this);
        }
    }

    class ProgrammingBook : Floor4Book
    {
        public override void Return(Library library)
        {
            library.Floor4.ProgrammingShelves.Add(this);
        }
    }

    class DatabaseBook : Floor4Book
    {
        // Code here
        public override void Return(Library library)
        {
            throw new NotImplementedException();
        }
    }

}