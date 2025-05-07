using DAL.Models;

namespace Apllication.ResponseDtos.WarehouseDtos
{
    public class GetWarehouseListDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string WarehouseName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Location { get; set; }
        public List<string> GateNames { get; set; }
        public List<WarehousePalletResponseDto> Pallets { get; set; }
    }

    public class WarehousePalletResponseDto
    {
        public string? Serial { get; set; }
        public string UID { get; set; }
        public PalletStatus Status { get; set; }
    }
}
