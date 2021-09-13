using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductList3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductList3.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> List()
        {
            using (var context = new ProductDBContext())
            {
                var list = await context.products.AsNoTracking().ToListAsync();
                return View(list);
            }            
        }
        [HttpGet]
        public IActionResult Details(int Id)
        {
            
            var context = new ProductDBContext();
            {
                Product product = context.products.Find(Id);                
                return View(product);
            }
            
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create([Bind("ProductId", "ProductName", "Description", "ExpiryDate", "ExpiryTime", "Quantity", "RegistrationTime")] Product product)
        {
            using(var context = new ProductDBContext())
            {
                context.Add(product);
                await context.SaveChangesAsync();
                return RedirectToAction("List");
            }           
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            var db = new ProductDBContext();
            Product del = db.products.Find(Id);
            return View(del);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            var db = new ProductDBContext();

            {
               Product product = db.products.Find(Id);
                db.products.Remove(product);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var db = new ProductDBContext();
            {

                Product app = db.products.Find(Id);
                if (app == null)
                {
                    
                }
                return View(app);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("ProductId", "ProductName", "Description", "ExpiryDate", "ExpiryTime", "Quantity")] Product s1)
        {
            
            var db = new ProductDBContext();
            {
                if (ModelState.IsValid)
                {
                    db.Entry(s1).State = EntityState.Modified;
                    db.SaveChanges();
                    
                    return RedirectToAction("List");
                }
            }
            return View(s1);
        }



    }
}
