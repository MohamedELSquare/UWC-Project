using DAL.Models.Difinitions;

namespace DAL.Models
{
    public class JobOrder : BaseEntity
    {
        public string Code { get; set; }
        public string? DestinationCustomer { get; set; }
        public decimal? Quantity { get; set; }
        public string? ProductName { get; set; }
        public string? Manufacturer { get; set; }
        // Navigation
        public ICollection<Pallet> Pallets { get; set; }

        // FK to SubCustomer
        public int? SubCustomerId { get; set; }
        public SubCustomer? SubCustomer { get; set; }
    }
}
