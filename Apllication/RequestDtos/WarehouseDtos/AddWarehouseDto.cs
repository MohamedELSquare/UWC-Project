namespace Apllication.RequestDtos.WarehouseDtos
{
    public class AddWarehouseDto
    {
        public int CustomerId { get; set; }
        public string WarehouseName { get; set; }
        public string Code { get; set; }
        public string? Location { get; set; }
    }
}
