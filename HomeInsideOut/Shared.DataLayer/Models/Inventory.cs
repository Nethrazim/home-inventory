using System;
using System.Collections.Generic;

namespace Shared.DataLayer.Models
{
    public partial class Inventory : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int UserId { get; set; }

        public virtual InventoryItem? InventoryItem { get; set; }
    }
}
