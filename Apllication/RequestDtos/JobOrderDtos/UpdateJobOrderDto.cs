namespace Apllication.RequestDtos.JobOrderDtos
{
    public class UpdateJobOrderDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string? DestinationCustomer { get; set; }
        public decimal? Quantity { get; set; }
        public string? ProductName { get; set; }
        public string? Manufacturer { get; set; }
        public int? SubCustomerId { get; set; }
    }
}
