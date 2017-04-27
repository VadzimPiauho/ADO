﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>()
            {
                new Department(){ Id = 1, Country = "Ukraine", City = "Donetsk" },
                new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
                new Department(){ Id = 3, Country = "France", City = "Paris" },
                new Department(){ Id = 4, Country = "Russia", City = "Moscow" }
            };
            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                    { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
                new Employee()
                    { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
                new Employee()
                    { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
                new Employee()
                    { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
                new Employee()
                    { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
                new Employee()
                    { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
                new Employee()
                    { Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27,DepId = 4 }
            };

            var result = departments.Select(x => x.Country).Where(x => x.StartsWith("U"));
            //Console.WriteLine("Countries beginning with U:");
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.Write("Press Enter to complete");
            //Console.ReadLine();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var result2 = departments.Select(x => x.Country).Distinct();
            Console.WriteLine("Список стран без повторений:");
            foreach (var item in result2)
            {
                Console.WriteLine(item);
            }
            Console.Write("Press Enter to complete");
            Console.ReadLine();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var result3 = employees.Where(x=>x.DepId==2).Select(x => new { x.FirstName, x.LastName });
            Console.WriteLine("имена и фамилии сотрудников, работающих в Украине, но не в Донецке");
            foreach (var item in result3)
            {
                Console.WriteLine(item);
            }
            Console.Write("Press Enter to complete");
            Console.ReadLine();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var result4 = employees.Where(x => x.DepId == 2).Where(x=>x.Age>23).Select(x => new { x.FirstName, x.LastName, x.Age });
            Console.WriteLine("имена, фамилии и возраст студентов из Киева, возраст которых превышает 23 года");
            foreach (var item in result4)
            {
                Console.WriteLine(item);
            }
            Console.Write("Press Enter to complete");
            Console.ReadLine();
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var result5 = employees.Where(x => x.Age > 25).Select(x => new { x.FirstName, x.LastName, x.Age });
            Console.WriteLine("3-x первых сотрудников, возраст которых превышает 25 лет");
            foreach (var item in result5)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in result5.Take(3))
            {
                Console.WriteLine(item);
            }
            Console.Write("Press Enter to complete");
            Console.ReadLine();
        }
    }
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int DepId { get; set; }
    }
    class Department
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
