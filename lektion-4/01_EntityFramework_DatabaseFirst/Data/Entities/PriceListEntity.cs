using System;
using System.Collections.Generic;

namespace _01_EntityFramework_DatabaseFirst.Data.Entities
{
    public partial class PriceListEntity
    {
        public int ProductId { get; set; }
        public string CurrencyCode { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime Modified { get; set; }

        public virtual CurrencyEntity CurrencyCodeNavigation { get; set; } = null!;
        public virtual ProductEntity Product { get; set; } = null!;
    }
}
