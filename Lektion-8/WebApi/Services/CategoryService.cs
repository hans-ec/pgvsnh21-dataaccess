using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Models.Entities;
using WebApi.Models.Forms;

namespace WebApi.Services
{
    public interface ICategoryService
    {
        Task<Category> CreateAsync(CategoryForm form);
        Task<IEnumerable<Category>> GetAllAsync();
    }

    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(CategoryForm form)
        {
            if(!await _context.Categories.AnyAsync(x => x.Name == form.Name))
            {
                var categoryEntity = new CategoryEntity { Name = form.Name };
                _context.Categories.Add(categoryEntity);
                await _context.SaveChangesAsync();

                return new Category { Id = categoryEntity.Id, Name = categoryEntity.Name };
            }

            return null!;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var items = new List<Category>();
            foreach (var categoryEntity in await _context.Categories.ToListAsync())
                items.Add(new Category { Id = categoryEntity.Id, Name = categoryEntity.Name });

            return items;
        }
    }
}
