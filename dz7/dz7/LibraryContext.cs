using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace dz7
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
            : base()
        {
            //Database.SetInitializer<LibraryContext>(new
            //    CreateDatabaseIfNotExists<LibraryContext>());

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
       

    }
}
