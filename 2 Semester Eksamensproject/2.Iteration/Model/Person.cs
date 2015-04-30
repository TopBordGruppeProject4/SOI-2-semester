using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Iteration.Model
{
    abstract class Person
    {
        public abstract string Address { get; set; }
        public abstract int Id { get; set; }
        public abstract string Name { get; set; }

        public abstract string Tlf { get; set; }

    }
}
