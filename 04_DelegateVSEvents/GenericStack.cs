using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_DelegateVSEvents
{
    class PlacedEventArgs<T> : EventArgs
    {
        public T Value { get; set; }
        public int Location { get; set; }
    }
    class GenericStack<T> 
    {
        //public delegate void EventType(T value, int location); --> If we use own delegate
        public event EventHandler<PlacedEventArgs<T>> numberPlaced;

        T[] array;
        int pointer;

        public GenericStack(int size)
        {
            array = new T[size];
            pointer = 0;
        }

        public void Push(T item)
        {
            if (pointer > array.Length)
            {
                throw new ArgumentException("StackOverFlow!");
            }
            array[pointer++] = item;

            // Event is here
            numberPlaced?.Invoke(this, new PlacedEventArgs<T>
            {
                Value = item,
                Location = pointer - 1
            });
        }

        public T Pop()
        {
            if (pointer == 0)
            {
                throw new ArgumentException("Stack is Empty!");
            }
            return array[--pointer];
        }

        public string ToString(string item)
        {
            return item;
        }
    }
}
