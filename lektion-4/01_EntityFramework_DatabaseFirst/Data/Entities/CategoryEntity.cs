using System;
using System.Collections.Generic;

namespace _01_EntityFramework_DatabaseFirst.Data.Entities
{
    public partial class CategoryEntity
    {
        public CategoryEntity()
        {
            SubCategoryEntities = new HashSet<SubCategoryEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<SubCategoryEntity> SubCategoryEntities { get; set; }
    }
}
