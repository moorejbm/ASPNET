using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing.Models
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProducts(int id);
        public void UpdateProduct(Product products);
        public void InsertProduct(Product productsToInsert);
        //public IEnumerable<Category> GetCategories();
        //public Product AssignCategory();
        public void DeleteProduct(Product products);
        public IEnumerable<Product> SearchProducts(string search);


    }

}
