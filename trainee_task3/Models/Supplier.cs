﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace trainee_task3.Models
{
    public class Supplier
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string City { get; set; }
        
        public string Country { get; set; }
        public List<Product> Products { get; set; }
    }
}
