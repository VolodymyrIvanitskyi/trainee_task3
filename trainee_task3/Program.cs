using System;
using System.Linq;
using trainee_task3.Models;
using Microsoft.EntityFrameworkCore;

namespace trainee_task3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ProductContext db = new ProductContext())
            {
  
                /*Category category1 = new Category { Name = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" };
                Category category2 = new Category { Name = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" };
                Category category3 = new Category { Name = "Confections", Description = "Desserts, candies, and sweet breads" };
                Category category4 = new Category { Name = "Dairy Products", Description = "Cheeses" };
                Category category5 = new Category { Name = "Grains/Cereals", Description = "crackers, pasta, and cereal" };

                Supplier supplier1 = new Supplier {Name= "Exotic Liquid", City= "London",Country= "UK" };
                Supplier supplier2 = new Supplier {Name= "New Orleans Cajun Delights", City= "New Orleans", Country= "USA" };
                Supplier supplier3 = new Supplier {Name= "Grandma Kelly’s Homestead", City= "Ann Arbor", Country= "USA" };
                Supplier supplier4 = new Supplier {Name= "Tokyo Traders", City= "Tokyo", Country= "Japan" };
                Supplier supplier5 = new Supplier {Name= "Cooperativa de Quesos ‘Las Cabras’", City= "Oviedo", Country= "Spain" };

                Product product1 = new Product {ProductName= "Chais",Supplier = supplier1, Category=category1, Price=18 };
                Product product2 = new Product {ProductName= "Chang", Supplier=supplier1, Category=category1, Price=19 };
                Product product3 = new Product {ProductName= "Aniseed Syrup", Supplier=supplier1, Category=category2, Price=10 };
                Product product4 = new Product {ProductName= "Chef Anton’s Cajun Seasoning", Supplier=supplier2, Category=category2, Price=22 };
                Product product5 = new Product {ProductName= "Chef Anton’s Gumbo Mix", Supplier=supplier2, Category=category2, Price=21.35M };*/


                /*db.Categories.AddRange(category1, category2, category3, category4, category5);
                db.Suppliers.AddRange(supplier1, supplier2, supplier3, supplier4, supplier5);
                db.Products.AddRange(product1, product2, product3, product4, product5);
                
                db.SaveChanges();*/

                /*Supplier supplier6 = new Supplier { Name = "Norske Meierier", City = "Lviv", Country = "Ukraine" };
                Product product6 = new Product { ProductName = "Green tea", Supplier = supplier6, Category = category1, Price = 10 };
                db.Suppliers.Add(supplier6);
                db.Products.Add(product6);
                db.SaveChanges();*/

                Console.WriteLine("Всі продукти");
                var products = db.Products.Include(p => p.Category).Include(p => p.Supplier).ToList();
                foreach (Product p in products)
                {
                    Console.WriteLine($"{p.ProductName}, {p.Supplier.City},{p.Supplier.Country}, {p.Category.Name}, {p.Price}");
                }

                Console.WriteLine("\nПродукти які починаються на літеру С");
                var products1 = db.Products.Where(p => p.ProductName.StartsWith("C")).Include(p => p.Category).Include(p => p.Supplier).ToList();
                foreach (Product p in products1)
                {
                  Console.WriteLine($"{p.ProductName}, {p.Supplier?.City}, {p.Category?.Name}, {p.Price}");
                }

                Console.WriteLine("\nПродукти в яких ціна мінімальна");
                var minPrice = db.Products.Min(p => p.Price);
                var products2 = db.Products.Where(p => p.Price == minPrice).Include(p=>p.Category).Include(p=>p.Supplier);
                foreach (Product p in products2)
                {
                    Console.WriteLine($"{p.ProductName}, {p.Supplier.City}, {p.Category.Name}, {p.Price}");
                }

                Console.WriteLine("\nСума всіх продуктів з США");
                var sum = db.Products.Where(p => p.Supplier.Country == "USA").Sum(p => p.Price);
                Console.WriteLine("Сума = "+sum);

                Console.WriteLine("\nПостачальники, які постачають приправи");
                var suppliers = db.Products.Where(p => p.Category.Name == "Condiments").Select(p => p.Supplier).ToList();
                foreach(var s in suppliers) 
                {
                    Console.WriteLine($"{s.Id}, {s.Name},{s.City}, {s.Country}");

                }
            }
        }
    }
}
