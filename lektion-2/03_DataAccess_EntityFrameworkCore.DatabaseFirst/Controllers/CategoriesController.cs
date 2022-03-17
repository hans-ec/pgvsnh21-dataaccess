#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _03_DataAccess_EntityFrameworkCore.DatabaseFirst.Models;

namespace _03_DataAccess_EntityFrameworkCore.DatabaseFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly SqlContext _context;

        public CategoriesController(SqlContext context)
        {
            _context = context;
        }


        #region CREATE/POST/(INSERT)

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryModel>> PostCategory(CreateCategoryModel model)
        {
            var category = new Category
            {
                Name = model.CategoryName
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, new CategoryModel { Id = category.Id, Name = category.Name });
        }


        #endregion

        #region READ/GET/(SELECT)


        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetCategories()
        {
            var items = new List<CategoryModel>();
            
            foreach (var item in await _context.Categories.ToListAsync())
                items.Add(new CategoryModel
                {
                    Id = item.Id,
                    Name = item.Name
                });

            return items;
        }


        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return new CategoryModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }



        #endregion

        #region UPDATE/PUT/(UPDATE)


        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }

        #endregion

        #region DELETE/DELETE/(DELETE)

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion

    }
}
