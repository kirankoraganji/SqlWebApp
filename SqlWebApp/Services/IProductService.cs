using SqlWebApp.Models;

namespace SqlWebApp.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
    }
}