using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtensionMethods;
using System.Text.RegularExpressions;

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
            Console.WriteLine(item1.Equals(item3));

            Console.WriteLine(item1.GetHashCode());
            Console.WriteLine(item2.GetHashCode());
            Console.WriteLine(item3.GetHashCode());

            string email = "toha222@mail.ru";
            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            bool result = email.CheckEmail(pattern);
            
            if (result)
            {
                Console.WriteLine("Проверка прошла!");
            }
            else
            {
                Console.WriteLine("Проверка не прошла");
            }

        }

        
    }
}

namespace ExtensionMethods
{
    public static class StringExtension
    {
        public static bool CheckEmail(this string str, string pattern)
        {
            if (Regex.IsMatch(str, pattern, RegexOptions.IgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}