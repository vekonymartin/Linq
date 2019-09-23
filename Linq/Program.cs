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
            list.Add(new Student() { Name = "Harry Potter" });
            list.Add(new Student() { Name = "Darth Vader"});
            list.Add(new Student() { Name = "John Rambo"});
            list.Add(new Student() { Name = "Obi-one Kenobi"});
            list.Add(new Student() { Name = "Voldemort"});
            list.Add(new Student() { Name = "darth Sidious"});

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

            #region Task 2
            /*
             * Queried students, whose age between 20 and 50
             * and they're not in the relationship,
             * supplement the student class.
             * 
             * Supplementing student data (age + relationship)
             */

            Title("Task 2");

            Random r = new Random();

            for (int i = 0; i < students.Count; i++)
            {
                Predicate<int> relationshipChoice = x => { return x == 0; };

                students[i].Relationship = (bool)relationshipChoice?.Invoke(r.Next(2));
                students[i].Age = r.Next(30, 131);
            }

            Process(students);

            // Queried students

            var studentQuery = students.Where(x =>
            {
                return x.Relationship == true && (x.Age > 20 && x.Age < 51);
            });

            Title("Task 2 - Query");
            Process(studentQuery);

            #endregion

            #region Task 3
            /*
             * Make query, who is in relationship
             * after that, order by name 
             * and change uppercase all character
             */

            var relationshipQuery = students.Where(x => x.Relationship == true)
                .OrderBy(x => x.Name)
                .Select(x => x.Name.ToUpper());

            Title("Task 3");
            Process(relationshipQuery);
            #endregion

            #region Task 4
            /*
             * 
             */

            var group1 = students.GroupBy(x => x.Relationship);

            //var group2 = from x in students
            //             group x by x.Relationship into xres
            //             select new { group = xres.Key, count = xres.Count() };

            foreach (var item in group1)
                Console.WriteLine("Group: (0) <> count: {1}",item.Key,item.Count());

            //foreach (var item in group2)
            //    Console.WriteLine"Group: (0) <> count: {1}",item.group,item.count);

            #endregion

            #region Task 5
            /*
             * 
             */

            #endregion 
        }
    }
}
