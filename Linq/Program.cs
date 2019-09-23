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
        public static void Title(string title)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(title + " : ");
            Console.ForegroundColor = ConsoleColor.Gray;
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

            Title("Query syntax");
            Process(list);
            // find even number with LINQ (method syntax + lamda)
            var evenNumer2 = list.Where(x => x % 2 == 0);

            Title("Method syntax + lamda");
            Process(list);
        }

        public static List<Student> DataGeneration(ref List<Student> list)
        {
            list = new List<Student>();
            list.Add(new Student() { Name = "Harry Potter", Age= 17});
            list.Add(new Student() { Name = "Darth Vader", Age = 40});
            list.Add(new Student() { Name = "John Rambo", Age = 50 });
            list.Add(new Student() { Name = "Obi-one Kenobi", Age = 60 });
            list.Add(new Student() { Name = "Voldemort", Age = 80 });
            list.Add(new Student() { Name = "darth Sidious", Age = 130 });

            return list;
        }


        static void Main(string[] args)
        {
            #region Introduction
            Introduction();
            #endregion


            List<Student> students = new List<Student>();
            DataGeneration(ref students);


            #region Introductory examples

            var orderedStudents = students.OrderBy(x => x.Name);

            Console.WriteLine(new string('=', 40));
            Process(orderedStudents);

            var nameDay = students.Where(x => x.Name.Contains("John"));

            Console.WriteLine(new string('=', 40));
            Process(nameDay);
            #endregion

            #region Task 1
            /*
             * We've database in list, let's do a query that count the name of Darth
             * Create array with this number
             * and we copy Darth objects to this array
             * 
             * Pay attention to lowercase and appercase in the database
             */

            Title("Task 1");

            int dbNumber = students.Count(x => x.Name.ToUpper().Contains("darth".ToUpper()));
            var darth = students.Where(x => x.Name.ToUpper().Contains("darth".ToUpper()));

            Student[] chosedOne = new Student[dbNumber];
            int index = 0;

            foreach (var item in darth)
                chosedOne[index++] = item;

            Process(chosedOne);
            #endregion


        }
    }
}
