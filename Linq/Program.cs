using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;   // need to LIST
using System.Linq;                  // need to LINQ 

namespace Linq
{
    class Program
    {
        public static void Process<T>(IEnumerable<T> list)
        {
            // can't use .length or count, because list is generic type

            Console.WriteLine(new string('=',40));

            foreach (var item in list)
                Console.Write(item + ", ");

            Console.WriteLine("\n" + new string('=', 40));
        }

        public static void Introduction()
        {
            List<int> list = new List<int>();
            Random r = new Random();

            for (int i = 0; i < 10; i++)
                list.Add(r.Next(99));

            IEnumerable<int> xlist = list.FindAll(x => x % 2 == 0);
            int maxItem = xlist.Max(x => x);

            var something = new Student() { Name = "X people" }; // only if you don't know the variable's type
            var anotherSomething = new { Name = "John", Age = 20, Nationality = "Hungarian" }; // != class !!!!, you can do anything ("structure")

            string s = anotherSomething.Name; // after initialization, you can call every property this variable as it was a class

            // LINQ
            // find even number with LINQ (query syntax!)
            var evenNumber1 = from x in list
                              where x % 2 == 0
                              select x;

            Console.WriteLine("Query syntax");
            Process(list);
            // find even number with LINQ (method syntax + lamda)
            var evenNumer2 = list.Where(x => x % 2 == 0);

            Console.WriteLine("Method syntax + lamda");
            Process(list);
        }

        public static List<Student> DataGeneration(List<Student> list)
        {
            list = new List<Student>();
            list.Add(new Student() { Name = "Harry Potter" });
            list.Add(new Student() { Name = "Dart Vader" });
            list.Add(new Student() { Name = "John Rambo" });
            list.Add(new Student() { Name = "Obi-one Kenobi" });
            list.Add(new Student() { Name = "Voldemort" });

            return list;
        }


        static void Main(string[] args)
        {
            #region Introduction
            Introduction();
            #endregion


            List<Student> students = new List<Student>();
            DataGeneration(students);


            #region Introductory examples

            var orderedStudents = students.OrderBy(x => x.Name);

            Console.WriteLine(new string('=', 40));
            Process(orderedStudents);

            var nameDay = students.Where(x => x.Name.Contains("John"));

            Console.WriteLine(new string('=', 40));
            Process(nameDay);
            #endregion


        }
    }
}
