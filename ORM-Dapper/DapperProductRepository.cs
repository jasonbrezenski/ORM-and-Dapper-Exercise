using System.Data;
using Dapper;

namespace ORM_Dapper;

public class DapperProductRepository : IProductRepository
{
    private readonly IDbConnection _connection;

    public DapperProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM products;");
    }

    public void CreateProduct(string name, double price, int categoryID)
    {
        _connection.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);",
            new { name, price, categoryID });
    }

    public void UpdateProduct(int productID, string nameUpdate)
    {
        _connection.Execute("UPDATE products SET Name = @nameUpdate WHERE ProductID = @productID;", new { productID, nameUpdate });
    }

    public void DeleteProduct(int productID)
    {
        _connection.Execute("DELETE FROM sales WHERE ProductID = @productID", new { productID });
        _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID", new { productID });
        _connection.Execute("DELETE FROM products WHERE ProductID = @productID", new { productID });
    }
}