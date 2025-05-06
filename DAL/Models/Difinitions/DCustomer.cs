using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Difinitions
{
    [Table(name: "Customers", Schema = "Definitions")]
    public class DCustomer : BaseEntity
    {
        public string? Name { get; set; }

        public ICollection<DWarehouse> Warehouses { get; set; }

        public string? Location { get; set; }

        public string? Contract { get; set; }



        public ICollection<SubCustomer>? SubCustomers { get; set; }  // New

    }
}
