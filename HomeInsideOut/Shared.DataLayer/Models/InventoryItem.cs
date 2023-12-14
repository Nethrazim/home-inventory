using System;
using System.Collections.Generic;

namespace Shared.DataLayer.Models
{
    public partial class InventoryItem : BaseEntity
    {
        public int InventoryId { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }

        public virtual Inventory IdNavigation { get; set; } = null!;
    }
}
