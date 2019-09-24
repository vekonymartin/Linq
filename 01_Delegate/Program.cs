using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Delegate
{
    class Program
    {
        public delegate void HelloFunction(string data);

        public delegate double MathFunction(IEnumerable<int> data);

        static void Main(string[] args)
        {
            int[] numbers = { 3, 8, 12, 78, 91, 23, 45, 98, 17, 2, 1 };

            HelloFunction hf = HelloGerman;
            hf += HelloEnglish;
            hf += HelloHungarian;

            //hf -= HelloGerman;
            //hf -= HelloEnglish;
            //hf -= HelloHungarian;

            hf?.Invoke("John");
            
            // ===============================================================================

            Console.WriteLine();

            MathFunction mf = SUM;
            mf += Average;

            // double? result = mf?.Invoke(number);

            double?[] result = new double?[2];
            int pointer = 0;

            foreach (MathFunction item in mf.GetInvocationList())
            {
                Console.WriteLine(result[pointer++] = item?.Invoke(numbers));
;           }

        }

        private static void HelloGerman(string name)
        {
            Console.WriteLine($"Guten Morgen, {name}!");
        }

        private static void HelloEnglish(string name)
        {
            Console.WriteLine($"Good morning, {name}!");
        }

        private static void HelloHungarian(string name)
        {
            Console.WriteLine($"Jó reggelt, {name}!");
        }

        private static double SUM(IEnumerable<int> collection)
        {
            double sum = 0;
            foreach (var item in collection)
                sum += item;

            return sum;
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
    }
}
