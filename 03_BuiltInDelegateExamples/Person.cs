using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BuiltInDelegateExamples
{
    class Person
    {
        static Random r;
        static string[] names;

        public string Name  { get; }
        public int Age      { get; }

        static Person()
        {
            r = new Random();
            string[] tmpnames = { "John", "Kate", "Alfred", "William", "Brian", "Stuart", "Jessica", "Laurel", "Oliver" };
            names = tmpnames;
        }

        public Person()
        {
            this.Name = names[r.Next(0, names.Length)];
            this.Age = r.Next(18, 90);
        }
    }
}
