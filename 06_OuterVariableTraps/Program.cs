using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_OuterVariableTraps
{
    class Program
    {
        static void Main(string[] args)
        {
            // we have several SDXC cards ...1GB, 2GB, 4GB
            // task: calculate how much  cards have to buy to store the entire data?

            Action<int> calculatros = null;

            for (int i = 1; i < 4096; i *= 2)
            {
                int k = i;
                calculatros += (dataSize) =>
                {
                    Console.WriteLine($"{k} GB Card: {(dataSize / k) + 1} PIECE");
                };
            }

            calculatros(1564); // GB
        }
    }
}
