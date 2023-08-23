using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SqlWebApp.Models;
using SqlWebApp.Services;

namespace SqlWebApp.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        public List<Product> Products;
        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}
            
        public void OnGet()
        {
            //Products = new List<Product>();
            ProductService productService = new ProductService();
            Products = productService.GetAllProducts();
        }
    }
}