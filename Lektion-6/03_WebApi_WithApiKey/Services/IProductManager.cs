using _03_WebApi_WithApiKey.Models;
using Forms = _03_WebApi_WithApiKey.Models.Forms;
using Microsoft.AspNetCore.Mvc;

namespace _03_WebApi_WithApiKey.Services
{
    public interface IProductManager
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetAsync(int id);
        Task<IActionResult> CreateProductAsync(Forms.Product product);
    }
}
