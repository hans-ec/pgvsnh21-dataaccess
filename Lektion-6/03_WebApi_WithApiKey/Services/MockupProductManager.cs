using _03_WebApi_WithApiKey.Models;
using Forms = _03_WebApi_WithApiKey.Models.Forms;
using Microsoft.AspNetCore.Mvc;

namespace _03_WebApi_WithApiKey.Services
{
    public class MockupProductManager : IProductManager
    {
        private List<Product> _productList;

        public MockupProductManager()
        {
            _productList = new List<Product>()
            {
                new Product { Id = 1, Name = "Product 1", Price = 100, Description = "Description for product 1" },
                new Product { Id = 2, Name = "Product 2", Price = 100, Description = "Description for product 2" },
                new Product { Id = 3, Name = "Product 3", Price = 100, Description = "Description for product 3" },
            };
        }

        public async Task<IActionResult> CreateProductAsync(Forms.Product product)
        {
            try
            {
                if (!_productList.Any(x => x.Name == product.Name))
                {
                    _productList.Add(new Product
                    {
                        Id = _productList.LastOrDefault().Id + 1,
                        Name = product.Name,
                        Price = product.Price,
                        Description = product.Description
                    });
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
            return _productList;
        }

        public async Task<Product> GetAsync(int id)
        {
            return _productList.FirstOrDefault(x => x.Id == id);
        }
    }
}

