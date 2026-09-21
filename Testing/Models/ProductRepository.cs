using System.Collections.Generic;
using System.Data;
using Dapper;
using Testing.Models;

namespace Testing.Controllers;

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

    public Product GetProduct(int id)
    {
        return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE ProductID = @id;", new { id });
    }

    public void UpdateProduct(Product product)
    {
     _conn.Execute("UPDATE PRODUCTS SET name = @name, Price = @price where ProductID = @id;", new { product.Name, price = product.Price, id = product.ProductID});
    }
}