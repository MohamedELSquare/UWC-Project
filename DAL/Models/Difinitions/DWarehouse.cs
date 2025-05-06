using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Models.Difinitions
{
    [Table(name: "Warehouses", Schema = "Definitions")]
    public class DWarehouse : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int CustomerId { get; set; }

        [JsonIgnore]
        public DCustomer Customer { get; set; }

        public ICollection<DGate> Gates { get; set; }

        public ICollection<Pallet> Pallets { get; set; }

        // new
        public string? Location { get; set; }
    }
}
