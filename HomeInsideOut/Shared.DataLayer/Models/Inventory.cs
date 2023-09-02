namespace Shared.DataLayer.Models
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public int LowLimit { get; set; }
    }
}
