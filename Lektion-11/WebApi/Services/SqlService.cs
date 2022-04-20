using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IDataAccess
    {
        public Task<Product> CreateProductAsync(ProductRequest request);
        public Task<Product> GetProductAsync(int id);
        public Task<IEnumerable<Product>> GetAllProductsAsync();
        public Task<Product> UpdateProductAsync(int id, ProductRequest request);
        public Task<bool> DeleteProductAsync(int id);

        public Task<Customer> CreateCustomerAsync(CustomerRequest request);
        public Task<Customer> GetCustomerAsync(int id);
        public Task<IEnumerable<Customer>> GetAllCustomersAsync();
        public Task<Customer> UpdateCustomerAsync(int id, CustomerRequest request);
        public Task<bool> DeleteCustomerAsync(int id);
    }


    public class SqlService : IDataAccess
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SqlService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Customer> CreateCustomerAsync(CustomerRequest request)
        {
            if (!await _context.Customers.AnyAsync(x => x.Email == request.Email))
            {
                var customerEntity = _mapper.Map<CustomerEntity>(request);
                //customerEntity.CreateSecurePassword();

                _context.Customers.Add(customerEntity);
                await _context.SaveChangesAsync();

                return _mapper.Map<Customer>(customerEntity);
            }

            return null!;
        }

        public async Task<Product> CreateProductAsync(ProductRequest request)
        {
            if (!await _context.Products.AnyAsync(x => x.Name == request.Name))
            {
                var categoryEntity = await _context.Categories.FirstOrDefaultAsync(x => x.Name == request.CategoryName);
                if (categoryEntity == null)
                {
                    categoryEntity = new CategoryEntity { Name = request.CategoryName };
                    _context.Categories.Add(categoryEntity);
                    await _context.SaveChangesAsync();
                }

                var productEntity = _mapper.Map<ProductEntity>(request);
                productEntity.CategoryId = categoryEntity.Id;

                _context.Products.Add(productEntity);
                await _context.SaveChangesAsync();

                return _mapper.Map<Product>(productEntity);
            }

            return null!;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity != null)
            {
                _context.Customers.Remove(customerEntity);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var productEntity = await _context.Products.FindAsync(id);
            if (productEntity != null)
            {
                _context.Products.Remove(productEntity);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return _mapper.Map<IEnumerable<Customer>>(await _context.Customers.ToListAsync());
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return _mapper.Map<IEnumerable<Product>>(await _context.Products.Include(x => x.Category).ToListAsync());
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return _mapper.Map<Customer>(await _context.Customers.FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return _mapper.Map<Product>(await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<Customer> UpdateCustomerAsync(int id, CustomerRequest request)
        {
            var customerEntity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customerEntity != null)
            {
                if (customerEntity.FirstName != request.FirstName && !string.IsNullOrEmpty(request.FirstName))
                    customerEntity.FirstName = request.FirstName;

                if (customerEntity.LastName != request.LastName && !string.IsNullOrEmpty(request.LastName))
                    customerEntity.LastName = request.LastName;

                if (customerEntity.Email != request.Email && !string.IsNullOrEmpty(request.Email))
                    customerEntity.Email = request.Email;

                _context.Entry(customerEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return _mapper.Map<Customer>(customerEntity);
            }

            return null!;
        }

        public async Task<Product> UpdateProductAsync(int id, ProductRequest request)
        {
            var productEntity = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            if (productEntity != null)
            {
                if(productEntity.Name != request.Name && !string.IsNullOrEmpty(request.Name))
                    productEntity.Name = request.Name;

                if (productEntity.Price != request.Price)
                    productEntity.Price = request.Price;

                if (productEntity.Category.Name != request.CategoryName && !string.IsNullOrEmpty(request.CategoryName))
                {
                    var categoryEntity = await _context.Categories.FirstOrDefaultAsync(x => x.Name == request.CategoryName);
                    if (categoryEntity == null)
                    {
                        categoryEntity = new CategoryEntity { Name = request.CategoryName };
                        _context.Categories.Add(categoryEntity);
                        await _context.SaveChangesAsync();
                    }

                    productEntity.CategoryId = categoryEntity.Id;
                }

                _context.Entry(productEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return _mapper.Map<Product>(productEntity);
            }

            return null!;

        }
    }
}
