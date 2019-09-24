using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Linq
{
    class Log
    {
        public Log()
        {
            Logger logger = new Logger();

            Logging(logger);
            LoggingNumber(logger);

        }

        public void Logging(Logger logger)
        {
            logger.AddLogMethod(Console.WriteLine);
            logger.AddLogMethod(message => File.AppendAllText("log.txt", message + Environment.NewLine));

            // It can be so than line 23

            /*logger.AddLogMethod(message =>
            {
                using (StreamWriter sw = new StreamWriter("log.txt", true))  /// using block, destroy after running, it reason why not having to close. Frees up resources!
                {
                    sw.WriteLine(message);
                }
            });
            */

            logger.Log("Hello Delegate World!");
        }

        public void LoggingNumber(Logger logger)
        {
            List<int> numbers = new List<int>();
            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                numbers.Add(r.Next(1, 100));
                Console.Write(numbers[i] + ", ");
            }
            Console.WriteLine();

            logger.Log(numbers.FindLast(number => number % 2 == 0).ToString());
            numbers.RemoveAll(number => number < 20 || number > 50);
            logger.Log(numbers.Aggregate("", (number, text) => text + " " + number));
        }
    }
}
