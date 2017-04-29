using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb2
{
    class Program
    {
        static void Main(string[] args)
        {
            var item1 = new { name = "vasy", age = 23 };
            var item2 = new { name = "vasy", age = 23 };
            var item3 = new { name = "vasy", last = "ivanov" };
            Console.WriteLine(item1.Equals(item2));
        }
    }
}
