using System;

namespace ClienteInfo.Dto
{
    public class ProductDto
    
    {
        public ProductDto(Guid id, string description, double price)
        {
            Id = id;
            Description = description;
            Price = price;
        }

        public Guid Id { get; set; }
        public string Description { get; set;}
        public double Price { get; set;} 
    }
}