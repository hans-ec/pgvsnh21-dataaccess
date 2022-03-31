using _00_Repetition_EntityFrameworkCore_CodeFirst.Models;
using Forms = _00_Repetition_EntityFrameworkCore_CodeFirst.Models.Forms;
using Microsoft.AspNetCore.Mvc;

namespace _00_Repetition_EntityFrameworkCore_CodeFirst.Services
{
    public interface IProductManager
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetAsync(int id);
        Task<IActionResult> CreateProductAsync(Forms.Product product);
    }
}
