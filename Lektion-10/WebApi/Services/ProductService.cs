using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Models.Product;

namespace WebApi.Services
{
    public interface IProductService
    {
        Task<Product> CreateAsync(Product product);
        Task<IEnumerable<Product>> GetAll();
        Task<bool> DeleteAsync(string articleNumber);
    }

    public class ProductService : IProductService
    {
        private readonly DatabaseContext _db;
        private readonly IMapper _map;

        public ProductService(DatabaseContext db, IMapper map)
        {
            _db = db;
            _map = map;
        }


        public async Task<Product> CreateAsync(Product product)
        {
            if (!await _db.Products.AnyAsync(x => x.ArticleNr == product.ArticleNumber))
            {
                var productEntity = _map.Map<ProductEntity>(product);

                var productCategoryEntity = await _db.ProductCategories.FirstOrDefaultAsync(x => x.Name == product.CategoryName);
                if (productCategoryEntity == null)
                    productEntity.Category = new ProductCategoryEntity { Name = product.CategoryName };
                else
                    productEntity.CategoryId = productCategoryEntity.Id;

                await _db.Products.AddAsync(productEntity);
                await _db.SaveChangesAsync();

                return _map.Map<Product>(productEntity);
            }

            return null!;
        }

        public async Task<bool> DeleteAsync(string articleNumber)
        {
            var productEntity = await _db.Products.FindAsync(articleNumber);
            if (productEntity != null)
            {
                _db.Products.Remove(productEntity);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return _map.Map<IEnumerable<Product>>(await _db.Products.Include(x => x.Category).ToListAsync());
        }
    }
}
