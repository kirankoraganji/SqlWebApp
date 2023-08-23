using SqlWebApp.Models;
using System.Data.SqlClient;

namespace SqlWebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;

        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection SqlConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("SQLConnection"));
        }
        //public static string GetConnectionString()
        //{
        //    return $"Data Source={db_source};Initial Catalog={db_database};User ID={db_user};Password={db_password}";
        //}
        //private SqlConnection GetConnection()
        //{
        //    var builder = new SqlConnectionStringBuilder();
        //    builder.DataSource = db_source;
        //    builder.UserID = db_user;
        //    builder.Password = db_password;
        //    builder.InitialCatalog = db_database;
        //    return new SqlConnection(builder.ConnectionString);
        //}
        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            using (var connection = SqlConnection())
            {
                connection.Open();
                var sql = "SELECT * FROM Products";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Product();
                            product.ProductID = reader.GetInt32(0);
                            product.ProductName = reader.GetString(1);
                            product.Quantity = reader.GetInt32(2);
                            products.Add(product);
                        }
                    }
                    connection.Close();
                }
            }
            return products;
        }
    }
    // find all images

}
