using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Iteration.Model
{
    class Customer: Person
    {
        public override string Address { get; set; }
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Tlf { get; set; }

        public string Email { get; set; }

        public Customer(string address, int id, string name, string tlf, string email)
        {
            Address = address;
            Id = id;
            Name = name;
            Tlf = tlf;
            Email = email;
        }

        public override string ToString()
        {
            return string.Format("Address: {0}, Id: {1}, Name: {2}, Tlf: {3}, Email: {4}", Address, Id, Name, Tlf, Email);
        }
    }
}
