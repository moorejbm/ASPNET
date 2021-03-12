using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;

namespace ASPNET.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;
        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var products = repo.GetAllProducts();

            return View(products);
        }

        public IActionResult ViewProduct(int id)
        {
            var products = repo.GetProducts(id);

            return View(products);
        }

        public IActionResult UpdateProduct(int id)
        {
            Product prod = repo.GetProducts(id);

            if (prod == null)
            {
                return View("ProductNotFound");
            }

            return View(prod);
        }

        public IActionResult UpdateProductToDatabase(Product products)
        {
            repo.UpdateProduct(products);

            return RedirectToAction("ViewProduct", new { id = products.driverID });
        }

        /*public IActionResult InsertProduct()
        {
            var prod = repo.AssignCategory();

            return View(prod);
        }*/

        public IActionResult InsertProduct(Product productToInsert)
        {
            repo.InsertProduct(productToInsert);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(Product products)
        {
            repo.DeleteProduct(products);

            return RedirectToAction("Index");
        }

        public IActionResult Search(string searchString)
        {
            var search = repo.SearchProducts(searchString);

            return View(search);

        }







    }
}

