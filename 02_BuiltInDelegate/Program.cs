using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BuiltInDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 3, 8, 12, 78, 91, 23, 45, 98, 17, 2, 1 };

            Action<string> hf = HelloEnglish;
            hf += HelloGerman;
            hf += HelloHungarian;

            Func<IEnumerable<int>, double> mf = SUM;
            mf += Average;

            double?[] result = new double?[2];
            int pointer = 0;

            // IEnumerable get around our collection and get back result, so we can read this collection's content
            foreach (Func<IEnumerable<int>,double> item in mf.GetInvocationList())
            {
                Console.WriteLine(result[pointer++] = item?.Invoke(numbers));
            }
        }

        private static double Average(IEnumerable<int> collection)
        {
            double sum = 0;
            int count = 0;

            foreach (var item in collection)
            {
                sum += item;
                count++;
            }

            return sum / count;
        }

        private static double SUM(IEnumerable<int> collection)
        {
            double sum = 0;

            foreach (var item in collection)
            {
                sum += item;
            }
            return sum;
        }

        private static void HelloEnglish(string name)
        {
            Console.WriteLine($"Good Morning, {name}");
        }

        private static void HelloGerman(string name)
        {
            Console.WriteLine($"Good Morning, {name}");
        }

        private static void HelloHungarian(string name)
        {
            Console.WriteLine($"Good Morning, {name}");
        }
    }
}
