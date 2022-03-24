using System;
using System.Collections.Generic;

namespace _01_EntityFramework_DatabaseFirst.Data.Entities
{
    public partial class VendorEntity
    {
        public VendorEntity()
        {
            ProductEntities = new HashSet<ProductEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductEntity> ProductEntities { get; set; }
    }
}
