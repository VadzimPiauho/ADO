using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Authors author = new Authors
            //{
            //    FirstName = "Isaac",
            //    LastName = "Azimov"
            //};
            //AddAuthor(author);
            //GetAllAuthors();
            //Books book = new Books
            //{
            //    Title = "Way Station",
            //    AuthorId = 2003,
            //    PAGES = 350,
            //    PRICE = 85
            //};
            //AddBook(book);
            //book = new Books
            //{
            //    Title = "Ring Around theSun",
            //    AuthorId = 2003,
            //    PAGES = 420,
            //    PRICE = 99
            //};
            //AddBook(book);
            //book = new Books
            //{
            //    Title = "The Martian Chronicles",
            //    AuthorId = 2002,
            //    PAGES = 410,
            //    PRICE = 105
            //};
            //AddBook(book);
            //book = new Books
            //{
            //    Title = "I, Robot",
            //    AuthorId = 1006,
            //    PAGES = 378,
            //    PRICE = 100
            //};
            //AddBook(book);
            GetAllPersonal();
            GetAllBook();
        }

        private static void GetAllBook()
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                //var au = db.Books.OrderBy((x) => x.Title).ToList();
                //foreach (var a in au)
                //{
                //    Console.WriteLine("Book: " + a.Title + "\tprice: " + a.PRICE + " \tauthor: "+a.Authors.FirstName + " " + a.Authors.LastName);

                //}
                var au = db.Books.Find(1004);
                Console.WriteLine("Book: " + au.Title + "\tprice: " + au.PRICE + " \tauthor: " + au.Authors.FirstName + " " + au.Authors.LastName);
            }
        }

        private static void GetAllAuthors()
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                var au = db.Authors.ToList();
                foreach (var a in au)
                {
                    Console.WriteLine(a.FirstName + " " + a.LastName);
                }
                //var au = db.Authors.Where((x) => x.LastName.StartsWith("A")).ToList();
                //foreach (var a in au)
                //{
                //    Console.WriteLine(a.FirstName + " " + a.LastName);
                //}
            }
        }
        private static void GetAllPersonal()
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                var au = db.Personal.ToList();
                foreach (var a in au)
                {
                    Console.WriteLine(a.Login + " " + a.Adres + " Должник " + a.Admin);
                }
                //var au = db.Authors.Where((x) => x.LastName.StartsWith("A")).ToList();
                //foreach (var a in au)
                //{
                //    Console.WriteLine(a.FirstName + " " + a.LastName);
                //}
            }
        }
        private static void AddAuthor(Authors author)
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                db.Authors.Add(author);
                db.SaveChanges();
                Console.WriteLine("New author added:" + author.LastName);
            }
        }
        static Authors GetAuthorByName1(string fname)
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                var author = db.Authors.FirstOrDefault(x => x.FirstName == fname);
                return author;
            }
        }
        static Authors GetAuthorById1(int id)
        {
            using (LibraryEntities db = new
                LibraryEntities())
            {
                var author = db.Authors.SingleOrDefault(x => x.Id == id);
                return author;
            }
        }
        static void GetAllAuthors1()
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                var au = db.Authors.OrderBy((x) => x.LastName).ToList();
                foreach (var a in au)
                {
                    Console.WriteLine(a.FirstName + " " + a.LastName);
                }
            }
        }
        static Authors GetAuthorById(int id)
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                var au = db.Authors.Find(id);
                Console.WriteLine(au.FirstName + " " +
                                  au.LastName);
                return au;
            }
        }
        static void AddBook(Books book)
        {
            using (LibraryEntities db = new LibraryEntities())
            {
                Books a = db.Books.FirstOrDefault(x => x.Title == book.Title);
                if (a == null)
                {
                    db.Books.Add(book);
                }
                db.SaveChanges();
                Console.WriteLine("New book added:" + book.Title);
            }
        }
    }
}
