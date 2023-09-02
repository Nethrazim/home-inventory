namespace Module.Identity.Entities.Model
{
    public class InventoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public int LowLimit { get; set; }
    }
}
