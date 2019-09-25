using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AnonMeh_Lambda
{
    class Program
    {
        private static bool OlderThan30(Person p)
        {
            return p.Age > 30;
        }

        private static int SpecialComparer(Person p1, Person p2)
        {
            return p1.Name[0].CompareTo(p2.Name[0]);
        }
        static void Main(string[] args)
        {
            List<Person> friends = new List<Person>();

            for (int i = 0; i < 10; i++)
            {
                friends.Add(new Person());
            }

            // Filtering: older than 30
            // 01. Use named method matching Predicate<T>
            List<Person> sol2 = friends.FindAll(delegate (Person p)
            {
                return p.Age > 30;
            });

            // Use lambda expression mathcing Predicate<T>
            List<Person> sol3 = friends.FindAll(p => p.Age > 30);

            Person[] array = friends.ToArray();

            // Sorting by name length
            // Used named method matching Comparison<T>
            Array.Sort(array, SpecialComparer);

            // Used anonymus method matching Comparison<T>
            Array.Sort(array, delegate (Person p1, Person p2) 
            {
                return p1.Name[0].CompareTo(p2.Name[0]);
            });

            // Use lambda exp. matching Comparison<T>
            Array.Sort(array, (p1, p2) => p1.Name[0].CompareTo(p2.Name[0]));

        }
    }
}
