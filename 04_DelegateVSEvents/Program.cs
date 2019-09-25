using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_DelegateVSEvents
{
    class Program
    {
        private static void Display(int value, int location)
        {
            Console.WriteLine($"{value} placed at {location}");
        }

        private static void NumberStack_NumberPlaced(object sender, PlacedEventArgs<int> e)
        {
            Console.WriteLine($"{e.Value} placed at {e.Location}");
        }
        static void Main(string[] args)
        {
            // LIFO data structure
            GenericStack<int> numberStack = new GenericStack<int>(10);

            numberStack.numberPlaced += NumberStack_NumberPlaced;

            numberStack.Push(14);
            numberStack.Push(1);
            numberStack.Push(6);
            numberStack.Push(15);
            numberStack.Push(22);
            numberStack.Push(33);

            Console.WriteLine(numberStack.Pop());

        }
    }
}
