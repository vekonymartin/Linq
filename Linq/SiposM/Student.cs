using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Student
    {
        public string Name          { get; set; }
        public int Age              { get; set; }
        public bool Relationship    { get; set; }

        public override string ToString()
        {
            return Name + " " + Age + " " + Relationship;
        } 
    }
}
