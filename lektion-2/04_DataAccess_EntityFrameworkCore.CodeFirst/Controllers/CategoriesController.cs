#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _04_DataAccess_EntityFrameworkCore.CodeFirst.Models.Entities;
using _04_DataAccess_EntityFrameworkCore.CodeFirst.Models;

namespace _04_DataAccess_EntityFrameworkCore.CodeFirst.Controllers
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
        public async Task<ActionResult<CategoryEntity>> PostCategoryEntity(CreateCategoryModel model)
        {
            var categoryEntity = new CategoryEntity
            {
                Name = model.CategoryName
            };

            _context.Categories.Add(categoryEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryEntity", new { id = categoryEntity.Id }, new CategoryModel { Id = categoryEntity.Id, Name = categoryEntity.Name });
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
        public async Task<ActionResult<CategoryModel>> GetCategoryEntity(int id)
        {
            var categoryEntity = await _context.Categories.FindAsync(id);

            if (categoryEntity == null)
            {
                return NotFound();
            }

            return new CategoryModel
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name
            };
        }


        #endregion

        #region UPDATE/PUT/(UPDATE)


        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryEntity(int id, CategoryEntity categoryEntity)
        {
            if (id != categoryEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoryEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryEntityExists(id))
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

        private bool CategoryEntityExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }

        #endregion

        #region DELETE/DELETE/(DELETE)


        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryEntity(int id)
        {
            var categoryEntity = await _context.Categories.FindAsync(id);
            if (categoryEntity == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(categoryEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        #endregion



















    }
}
