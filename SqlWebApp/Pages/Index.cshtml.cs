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
        private readonly IProductService _productService;
        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }   
        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}
            
        public void OnGet()
        {
            //Products = new List<Product>();
            
            Products = _productService.GetAllProducts();
        }
    }
}