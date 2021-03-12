using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;
        public ProductRepository(IDbConnection conn)
        {  
                _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        public Product GetProducts(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE driverID = @id",
                new { id = id });

        }

        public void UpdateProduct(Product products)
        {
            _conn.Execute("UPDATE products SET Name = @name, StrokesGained = @strokesGained, TotalDistanceRank = @totalDistanceRank, ForgivenessRank = @forgivenessRank, Price = @price WHERE driverID = @id",
                new { name = products.Name, strokesGained = products.StrokesGained, totalDistanceRank = products.TotalDistanceRank, forgivenessRank = products.ForgivenessRank, price = products.Price, id = products.driverID });
        }

        public void InsertProduct(Product productToInsert)
        {
            _conn.Execute("INSERT INTO products (NAME, STROKESGAINED, TOTALDISTANCERANK, FORGIVNESSRANK, PRICE) VALUES (@name, @strokesgained, @totaldistancerank, @forgivenessrank @price, @driverID);",
                new { name = productToInsert.Name, strokesgained = productToInsert.StrokesGained, totaldistancerank = productToInsert.TotalDistanceRank, forgivenessrank = productToInsert.ForgivenessRank, price = productToInsert.Price, driverID = productToInsert.driverID });
        }

        /*public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }*/

        /*public Product AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;

            return product;
        }*/
        public void DeleteProduct(Product products)
        {
            //_conn.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;",
                                       //new { id = products.driverID });
           //_conn.Execute("DELETE FROM Sales WHERE ProductID = @id;",
                                       //new { id = products.driverID });
            _conn.Execute("DELETE FROM Products WHERE DriverID = @id;",
                                       new { id = products.driverID });
        }

        public IEnumerable<Product> SearchProducts(string search)
        {
            return _conn.Query<Product>("SELECT * FROM products where name LIKE @name",
            new { name = "%" + search + "%" });
        }
    }
}

