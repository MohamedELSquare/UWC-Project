namespace Apllication.RequestDtos.WarehouseDtos
{
    public class UpdateWarehouseDto
    {
        public int WrehouseId { get; set; }
        public int CustomerId { get; set; }
        public string WarehouseName { get; set; }
        public string Code { get; set; }
        public string? Location { get; set; }
    }
}
