using SqlWebApp.Models;

namespace SqlWebApp.Services
{
    public interface IProductService
    {
        Task <List<Product>> GetAllProducts();
    }
}