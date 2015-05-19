using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHI.Model
{
    class RawMaterial
    {
        public int Amount { get; set; }

        public string Description { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public RawMaterial(int amount, string description, int id, string name)
        {
            Amount = amount;
            Description = description;
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("Amount: {0}, Description: {1}, Id: {2}, Name: {3}", Amount, Description, Id, Name);
        }
    }
}
