using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BuiltInDelegateExamples
{
    class Program
    {
        private static int SpecialComparer(Person p1, Person p2)
        {
            return p1.Age.CompareTo(p2.Age);
        }

        private static bool OlderThan50(Person p)
        {
            return p.Age > 50;
        }
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 30; i++)
                persons.Add(new Person());

            // 01. Selection

            Person p = persons.Find(OlderThan50);

            // 02. Filtering
            List<Person> filtered = persons.FindAll(OlderThan50);

            // 03. Contains
            bool exists = persons.Exists(OlderThan50);

            // 04. CustomSort
            Person[] array = persons.ToArray();
            Array.Sort(array, SpecialComparer);

            foreach (var item in array)
                Console.WriteLine(item.Name);
        }
    }
}
