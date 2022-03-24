using System;
using System.Collections.Generic;

namespace _01_EntityFramework_DatabaseFirst.Data.Entities
{
    public partial class CurrencyEntity
    {
        public CurrencyEntity()
        {
            PriceListEntities = new HashSet<PriceListEntity>();
        }

        public string CurrencyCode { get; set; } = null!;
        public string Currency { get; set; } = null!;
        public string? Country { get; set; }

        public virtual ICollection<PriceListEntity> PriceListEntities { get; set; }
    }
}
