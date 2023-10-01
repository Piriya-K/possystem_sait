using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models
{
    public class Item
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private double Price { get; set; }
        private string Description { get; set; }
        private string Category { get; set; }
        public Item()
        {
        }

        public Item(int id, string name, double price, string description, string category)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Category = category;
        }

    }
}
