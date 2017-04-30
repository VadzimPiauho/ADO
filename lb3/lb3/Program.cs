using MoreLinq;
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
            var result1 = db.Products.Select(x => new { x.Id, x.Title, x.Category, x.Weight, x.Price }).Where(x => x.Weight > 1);
            Console.WriteLine("Количество товаров, тяжелее одного килограмма");
            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }
            Console.Write("Press Enter to complete");
            Console.ReadLine();
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////");
            var result2 = db.Products.OrderBy(x => x.Category).Select(x => x.Category).Distinct();
            Console.WriteLine("Cписок категорий без повторений, упорядоченных по алфавиту");
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
            Console.Write("Press Enter to complete");
            Console.ReadLine();
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////");
            var result3 = db.Products.Where(x => x.Title.Length==5&& x.Title.StartsWith("S")).Select(x => x.Title);
            Console.WriteLine("Cтроки, которые начинаются с символа ‘S’ и имеют длину 5 символов");
            foreach (var item in result3)
            {
                Console.WriteLine(item);
            }
            Console.Write("Press Enter to complete");
            Console.ReadLine();
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////");
            var result4 = db.Products.OrderBy(x => x.Title).Where(x => x.Price < 400).Select(x => x.Title);
            Console.WriteLine("Cписок товаров, упорядоченных по алфавиту, которые дешевле 400 грн.");
            foreach (var item in result4)
            {
                Console.WriteLine(item);
            }
            Console.Write("Press Enter to complete");
            Console.ReadLine();
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////");
            var result5 = db.Products.MaxBy(x => x.Price);
            Console.WriteLine("Название категории, которая содержит самый дорогой в таблице товар");
            Console.WriteLine(result5.Category);
           
            Console.Write("Press Enter to complete");
            Console.ReadLine();
            Console.WriteLine("///////////////////////////////////////////////////////////////////////////////////////////////////");

        }
    }
}
