using _00_Repetition_EntityFrameworkCore_CodeFirst.Models;
using Forms = _00_Repetition_EntityFrameworkCore_CodeFirst.Models.Forms;
using _00_Repetition_EntityFrameworkCore_CodeFirst.Models.Data;
using _00_Repetition_EntityFrameworkCore_CodeFirst.Models.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace _00_Repetition_EntityFrameworkCore_CodeFirst.Services
{
    public class ProductManager : IProductManager
    {
        private readonly DataContext _context;

        public ProductManager(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CreateProductAsync(Forms.Product product)
        {
            try
            {
                if (!await _context.Products.AnyAsync(x => x.Name == product.Name))
                {
                    _context.Products.Add(new ProductEntity
                    {
                        Name = product.Name,
                        Price = product.Price,
                        Description = product.Description
                    });

                    await _context.SaveChangesAsync();
                    return new OkResult();
                }

                return new ConflictResult();
            }
            catch
            {
                return new BadRequestResult();
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var items = new List<Product>();
            foreach (var item in await _context.Products.ToListAsync())
                items.Add(new Product
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Description = item.Description
                });

            return items;
        }

        public async Task<Product> GetAsync(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);

            return new Product
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                Price = productEntity.Price,
                Description = productEntity.Description
            };
        }
    }
}
