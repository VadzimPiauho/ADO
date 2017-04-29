using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb3
{
    class Program
    {
        static void Main(string[] args)
        {
            DataClasses1DataContext db =
                new DataClasses1DataContext();
            var queryResults = from c in db.Products
                where c.Price > 200
                select new
                {
                    ID = c.Id,
                    Name = c.Title,
                    Price = c.Price
                };
            foreach (var item in queryResults)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Press any key to complete...");
            Console.ReadLine();
        }
    }
}
