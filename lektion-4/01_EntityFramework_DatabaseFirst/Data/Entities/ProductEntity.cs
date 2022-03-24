using System;
using System.Collections.Generic;

namespace _01_EntityFramework_DatabaseFirst.Data.Entities
{
    public partial class ProductEntity
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public int VendorId { get; set; }
        public string? Barcode { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Modified { get; set; }

        public virtual SubCategoryEntity SubCategory { get; set; } = null!;
        public virtual VendorEntity Vendor { get; set; } = null!;
        public virtual PriceListEntity PriceListEntity { get; set; } = null!;
        public virtual SkuEntity SkuEntity { get; set; } = null!;
    }
}
