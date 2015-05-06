﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Iteration.Model
{
    class Order
    {
        public DateTime CreationDate { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public double Price { get; set; }
        public int WorkerId { get; set; }
        public int CustomerId { get; set; }

        public Order(DateTime creationDate, DateTime deadline, string description, int id, double price, int workerId, int customerId)
        {
            CreationDate = creationDate;
            Deadline = deadline;
            Description = description;
            Id = id;
            Price = price;
            WorkerId = workerId;
            CustomerId = customerId;
        }

    }
}
