using Microsoft.AspNetCore.Mvc;
using mvc1.Models;

namespace mvc1.Controllers
{
    public class ProductController : Controller
    {
       static List<Product> products = new List<Product>()
{
     new Product { Id = 1, Title = "Laptop", Description = "High performance laptop", Price = 1500, Count = 10 }, 
     new Product { Id = 2, Title = "Mouse", Description = "Wireless gaming mouse", Price = 50, Count = 100 },   
     new Product { Id = 3, Title = "Keyboard", Description = "Mechanical RGB Keyboard", Price = 120, Count = 45 }, 
     new Product { Id = 4, Title = "Monitor", Description = "27-inch 4K UHD Monitor", Price = 400, Count = 15 },
     new Product { Id = 5, Title = "Headphones", Description = "Noise-cancelling over-ear headphones", Price = 250, Count = 30 }, 
     new Product { Id = 6, Title = "Webcam", Description = "1080p HD Streaming Camera", Price = 85, Count = 20 },
     new Product { Id = 7, Title = "External SSD", Description = "1TB Portable NVMe SSD", Price = 110, Count = 60 } 
};
        //https://localhost:7076/Product/GetAllProduct
        public IActionResult GetAllProduct()
        {
            return View(products);
        }


        //https://localhost:7076/Product/GetById/1
        public IActionResult GetById(int id)
        {
            var product = products.FirstOrDefault(e=>e.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }


        //creat
        //get
        public IActionResult Create()
        {
            return View();
        }
        //post
        public IActionResult ActualCreate(Product p)
        {
            products.Add(p);
            return RedirectToAction(nameof(GetAllProduct));
        }

        //edit

        public IActionResult Edit(int id )
        {
           var p = products.FirstOrDefault(e => e.Id == id);
            if (p == null) { 
            return NotFound();
            }
            return View(p);
        }
        //post
        public IActionResult ActualEdit(Product p)
        {
            var productInDB = products.FirstOrDefault(e => e.Id == p.Id);
            if (productInDB == null)
            {
                return NotFound();
            }

            productInDB.Title = p.Title;
            productInDB.Description = p.Description;
            productInDB.Price = p.Price;
            productInDB.Count = p.Count;
            return RedirectToAction(nameof(GetAllProduct));
        }

        //Delete
        public IActionResult Delete(int id)
        {
            var productInDB = products.FirstOrDefault(e => e.Id == id);
            if (productInDB == null)
            {
                return NotFound();
            }
           products.Remove(productInDB);
           return RedirectToAction(nameof(GetAllProduct));
        }
    }
}
