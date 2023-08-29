using SqlWebApp.Models;
using System.Data.SqlClient;
using Newtonsoft.Json;

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
        public async Task <List<Product>> GetAllProducts()
        {
            string Functionurl = "https://funcappdemokiran.azurewebsites.net/api/GetProduct?code=YXqXw8P4kMrGlZDhUyCOzvhenuSLs_54kSm4pM4c0Kr6AzFuPdlvgg==";

            using (HttpClient _client = new HttpClient())
            {
                HttpResponseMessage _response = await _client.GetAsync(Functionurl);
                string _content = await _response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Product>>(_content);
            }


        }
    }
    // find all images

}
