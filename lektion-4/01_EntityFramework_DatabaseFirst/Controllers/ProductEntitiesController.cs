#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _01_EntityFramework_DatabaseFirst.Data;
using _01_EntityFramework_DatabaseFirst.Data.Entities;
using _01_EntityFramework_DatabaseFirst.Models.Forms;
using _01_EntityFramework_DatabaseFirst.Models;

namespace _01_EntityFramework_DatabaseFirst.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductEntitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductEntitiesController(DataContext context)
        {
            _context = context;
        }



        private async Task<VendorEntity> GetVendorAsync(string vendorName)
        {
            var vendorEntity = await _context.VendorEntities.FirstOrDefaultAsync(x => x.Name == vendorName);
            if (vendorEntity == null)
            {
                vendorEntity = new VendorEntity { Name = vendorName };

                _context.VendorEntities.Add(vendorEntity);
                await _context.SaveChangesAsync();
            }

            return vendorEntity;
        }

        private async Task<CategoryEntity> GetCategoryAsync(string categoryName)
        {
            var categoryEntity = await _context.CategoryEntities.FirstOrDefaultAsync(x => x.Name == categoryName);
            if (categoryEntity == null)
            {
                categoryEntity = new CategoryEntity { Name = categoryName };

                _context.CategoryEntities.Add(categoryEntity);
                await _context.SaveChangesAsync();
            }

            return categoryEntity;
        }

        private async Task<SubCategoryEntity> GetSubCategoryAsync(string subCategoryName, string categoryName)
        {
            var subCategoryEntity = await _context.SubCategoryEntities.FirstOrDefaultAsync(x => x.Name == subCategoryName);
            if (subCategoryEntity == null)
            {
                subCategoryEntity = new SubCategoryEntity
                {
                    Name = subCategoryName,
                    CategoryId = (await GetCategoryAsync(categoryName)).Id
                };

                _context.SubCategoryEntities.Add(subCategoryEntity);
                await _context.SaveChangesAsync();
            }

            return subCategoryEntity;
        }


        [HttpPost]
        public async Task<ActionResult> PostProductEntity(ProductForm form)
        {
            var productEntity = new ProductEntity
            {
                Modified = DateTime.Now,
                Name = form.Name,
                Barcode = form.Barcode,
                Description = form.Description,
                SubCategoryId = (await GetSubCategoryAsync(form.SubCategoryName, form.CategoryName)).Id,               
                VendorId = (await GetVendorAsync(form.Vendor)).Id
            };

            _context.ProductEntities.Add(productEntity);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductEntity(int id)
        {
            var productEntity = await _context.ProductEntities
                .Include(x => x.Vendor)
                .Include(x => x.SubCategory)
                .ThenInclude(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (productEntity == null)
                return NotFound();

            var product = new Product
            {
                Id = productEntity.Id,
                Barcode = productEntity.Barcode,
                Modified = productEntity.Modified,
                Name = productEntity.Name,
                Description = productEntity.Description,
                CategoryName = productEntity.SubCategory.Category.Name,
                SubCategoryName = productEntity.SubCategory.Name,
                VendorName = productEntity.Vendor.Name
            };

            return product;
        }








        // GET: api/ProductEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> GetProductEntities()
        {
            return await _context.ProductEntities.ToListAsync();
        }










        // PUT: api/ProductEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductEntity(int id, ProductEntity productEntity)
        {
            if (id != productEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(productEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductEntityExists(id))
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



        // DELETE: api/ProductEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductEntity(int id)
        {
            var productEntity = await _context.ProductEntities.FindAsync(id);
            if (productEntity == null)
            {
                return NotFound();
            }

            _context.ProductEntities.Remove(productEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductEntityExists(int id)
        {
            return _context.ProductEntities.Any(e => e.Id == id);
        }
    }
}
