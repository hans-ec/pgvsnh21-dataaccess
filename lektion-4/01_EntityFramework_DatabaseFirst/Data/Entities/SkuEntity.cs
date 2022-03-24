using System;
using System.Collections.Generic;

namespace _01_EntityFramework_DatabaseFirst.Data.Entities
{
    public partial class SkuEntity
    {
        public int ProductId { get; set; }
        public DateTime Modified { get; set; }
        public int Quantity { get; set; }

        public virtual ProductEntity Product { get; set; } = null!;
    }
}
