using System;
using System.Collections.Generic;

namespace _01_EntityFramework_DatabaseFirst.Data.Entities
{
    public partial class SubCategoryEntity
    {
        public SubCategoryEntity()
        {
            ProductEntities = new HashSet<ProductEntity>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;

        public virtual CategoryEntity Category { get; set; } = null!;
        public virtual ICollection<ProductEntity> ProductEntities { get; set; }
    }
}
