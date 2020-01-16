using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DoYouPolymorphismToday
{
    class Poly
    {
        static void MainEntrys()
        {
            // 图书馆早上准时开门；
            Library library = new Library();

            // 当然，Poly他们没有理由只开图书馆的大门，他们还要开放图书馆的各层楼。
            // 一楼的门就是大门了，要开两次大门吗？
            Floor floor2 = library.Floor2;
            Floor floor3 = library.Floor3;
            Floor floor4 = library.Floor4;

            // 同学们一大早就归还很多图书。
            List<Book> books = new List<Book>();
            // 省略填充books列表的代码
            // 

            // 我们认为Poly会先把书分类好属于哪一层楼，然后再一次过搬到对应的楼层，
            // 而不是傻乎乎的每拿到一本书就跑到对应的楼层并把它放入对应的书架！
            List<Book> floor2Car = new List<Book>();
            List<Book> floor3Car = new List<Book>();
            List<Book> floor4Car = new List<Book>();

            // Poly需要根据每本书上的信息进行处理
            foreach (Book book in books)
            {
                // 首先看看该书属于图书馆那一层楼的。
                switch (book.FloorNumberString)
                {
                    // 一楼是图书馆办公室和借书柜台，不用于存放图书。
                    case "2nd":
                        // 把书放进往二楼的推车里。
                        floor2Car.Add(book);
                        break;
                    case "3rd":
                        // 把书放进往三楼的推车里。
                        floor3Car.Add(book);
                        break;
                    case "4th":
                        // 把书放进往四楼的推车里。
                        floor4Car.Add(book);
                        break;

                        // default:
                        //  // 把书放进哪里？地下室？还是天台？
                        //  break；
                }
            }

            // 接着Poly把往二楼的车推到二楼。
            // 我们认为Poly会先把书按照所属类别分类好，放在装书篮里，
            // 而不是傻乎乎的每拿到一本书就往对应的书架跑。
            List<Book> mathBasket = new List<Book>();
            List<Book> physicsBasket = new List<Book>();
            List<Book> chemistryBasket = new List<Book>();

            foreach (Book book in floor2Car)
            {
                switch (book.Catalog)
                {
                    case "Math":
                        mathBasket.Add(book);
                        break;
                    case "Physics":
                        physicsBasket.Add(book);
                        break;
                    case "Chemistry":
                        chemistryBasket.Add(book);
                        break;
                }
            }

            // 然后Poly提着篮子跑到对应的书架
            foreach (Book book in mathBasket)
                floor2.MathShelves.Add(book);


            foreach (Book book in physicsBasket)
                floor2.PhysicsShelves.Add(book);

            foreach (Book book in chemistryBasket)
                floor2.ChemistryShelves.Add(book);

            // 接着Poly把往三楼的车推到三楼。
            // 我们同样认为Poly会先把书按照所属类别分类好，放在装书篮里，
            // 而不是傻乎乎的每拿到一本书就往对应的书架跑。
            List<Book> economicsBasket = new List<Book>();
            List<Book> marketingBasket = new List<Book>();
            List<Book> managementBasket = new List<Book>();

            foreach (Book book in floor3Car)
            {
                switch (book.Catalog)
                {
                    case "Economics":
                        economicsBasket.Add(book);
                        break;
                    case "Marketing":
                        marketingBasket.Add(book);
                        break;
                    case "Management":
                        managementBasket.Add(book);
                        break;
                }
            }

            // 然后Poly提着篮子跑到对应的书架
            foreach (Book book in economicsBasket)
                floor3.EconomicsShelves.Add(book);


            foreach (Book book in marketingBasket)
                floor3.MarketingShelves.Add(book);

            foreach (Book book in managementBasket)
                floor3.ManagementShelves.Add(book);

            // 接着Poly把往四楼的车推到四楼。
            // 如果Poly傻乎乎的每拿到一本书就往对应的书架跑，那我们只好让他跑了。
            List<Book> programmingBasket = new List<Book>();
            List<Book> seBasket = new List<Book>();
            List<Book> databaseBasket = new List<Book>();
            List<Book> networkBasket = new List<Book>();

            foreach (Book book in floor4Car)
            {
                switch (book.Catalog)
                {
                    case "Programming":
                        programmingBasket.Add(book);
                        break;
                    case "Software Engineering":
                        seBasket.Add(book);
                        break;
                    case "Database":
                        databaseBasket.Add(book);
                        break;
                    case "Network":
                        networkBasket.Add(book);
                        break;
                }
            }

            // 然后Poly提着篮子跑到对应的书架
            foreach (Book book in programmingBasket)
                floor4.ProgrammingShelves.Add(book);


            foreach (Book book in seBasket)
                floor4.SEShelves.Add(book);


            foreach (Book book in physicsBasket)
                floor4.DatabaseShelves.Add(book);

            foreach (Book book in chemistryBasket)
                floor4.NetworkShelves.Add(book);

            // 最后，Poly整个人躺在地上

        }

        private class Library
        {
            public Floor Floor2 { get; internal set; }
            public Floor Floor3 { get; internal set; }
            public Floor Floor4 { get; internal set; }
        }

        private class Book
        {
            public string FloorNumberString { get; internal set; }
            public string Catalog { get; internal set; }
        }

        private class Floor
        {
            public IList<Book> MathShelves { get; internal set; }
            public IList<Book> PhysicsShelves { get; internal set; }
            public IList<Book> ChemistryShelves { get; internal set; }


            public IList<Book> ManagementShelves { get; internal set; }
            public IList<Book> EconomicsShelves { get; internal set; }
            public IList<Book> MarketingShelves { get; internal set; }


            public IList<Book> ProgrammingShelves { get; internal set; }
            public IList<Book> SEShelves { get; internal set; }
            public IList<Book> DatabaseShelves { get; internal set; }
            public IList<Book> NetworkShelves { get; internal set; }
        }
    }
}
