using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace trainee_task3.Models
{
    public class Product
    {
        
        public int Id { get; set; }
        
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
       
        public decimal Price { get; set; }
    }
}
