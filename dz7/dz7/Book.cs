using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace dz7
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int Pages { get; set; }
        public int Price { get; set; }
        public int PublisherId { get; set; }
    }
}