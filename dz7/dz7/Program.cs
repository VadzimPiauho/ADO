using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace dz7
{
    class Program
    {
        static void Main(string[] args)
        {
            Author author = new Author
            {
                FirstName = "Isaac",
                LastName = "Azimov" };
            using (LibraryContext db = new LibraryContext())
            {
                db.Authors.Add(author);
                db.SaveChanges();
                var ac = db.Authors.ToList();
                foreach (var a in ac)
                {
                    Console.WriteLine(a.FirstName +""+a.LastName);
                }
            }
        }
    }
}
