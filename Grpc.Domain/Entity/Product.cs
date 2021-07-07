using System;
using System.ComponentModel.DataAnnotations;

namespace DomainInfo.Entity
{
    public class Product
    {
        public Product() { }

        public Product(string description, double price)
        {
            Id = Guid.NewGuid();
            Description = description;
            Price = price;
        }

        
        public Guid Id { get; set; }
        public string Description { get; set;}
        public double Price { get; set;}
    }
}