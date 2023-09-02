namespace Module.Identity.BusinessLayer.DTOs
{
    public class InventoryDTO : BaseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public int LowLimit { get; set; }
    }
}
