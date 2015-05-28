using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHI.Model
{
    public class Product
    {

        public int Amount { get; set; }

        public string Description { get; set; }
        public int Id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }

        public Product(int amount, string description, int id, string name, double price)
        {
            Amount = amount;
            Description = description;
            Id = id;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return string.Format("Amount: {0}, Description: {1}, Id: {2}, Name: {3}, Price: {4}", Amount, Description, Id, Name, Price);
        }
    }
}
