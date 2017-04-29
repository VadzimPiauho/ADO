using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////");
            var result1 = db.Products.Select(x => new { x.Id, x.Title, x.Category,x.Weight,x.Price}).Where(x => x.Weight>1);
            Console.WriteLine("Количество товаров, тяжелее одного килограмма");
            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }
            Console.Write("Press Enter to complete");
            Console.ReadLine();
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////");
            var result2 = db.Products.Where(x => x.Price>50).Select(x=>new {x.Id,x.Title,x.Category,x.Weight,x.Price});
            Console.WriteLine("Cписок категорий без повторений, упорядоченных по алфавиту");
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
            Console.Write("Press Enter to complete");
            Console.ReadLine();
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////");


        }
    }
}
