using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Difinitions
{
    [Table(name: "SubCustomers", Schema = "Definitions")]
    public class SubCustomer : BaseEntity
    {
        public string Name { get; set; }
        public string? Location { get; set; }

        public int? DCustomerId { get; set; }
        public DCustomer? DCustomer { get; set; }

        public ICollection<JobOrder>? JobOrders { get; set; }
    }

}
