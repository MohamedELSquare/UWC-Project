namespace Apllication.ResponseDtos.JobOrderDtos
{
    public class JobOrderDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string? DestinationCustomer { get; set; }
        public decimal? Quantity { get; set; }
        public string? ProductName { get; set; }
        public string? Manufacturer { get; set; }

        public int? SubCustomerId { get; set; }
        public string? SubCustomerName { get; set; }
    }
}
