namespace Apllication.ResponseDtos.PalletDtos
{
    public class PalletDto
    {
        public int Id { get; set; }
        public string? Serial { get; set; }
        public string UID { get; set; }
        public string Status { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? WarehouseName { get; set; }

        public int? JobOrderId { get; set; }
        public string? JobOrderCode { get; set; }
        public decimal? Quantity { get; set; }
        public string? ProductName { get; set; }
        public string? Manufacturer { get; set; }
    }
}
