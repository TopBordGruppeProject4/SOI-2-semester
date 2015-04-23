using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Iteration.Model
{
    public class Worker: Person
    {
        

        public bool Admin { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public override string Address { get; set; }
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Tlf { get; set; }

        public Worker(bool admin, string password, string username, string address, int id, string name, string tlf)
        {
            Admin = admin;
            Password = password;
            Username = username;
            Address = address;
            Id = id;
            Name = name;
            Tlf = tlf;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}", Name);
        }
    }
}
