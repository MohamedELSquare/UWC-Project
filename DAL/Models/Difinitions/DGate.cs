using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Difinitions
{
    [Table(name: "Gates", Schema = "Definitions")]
    public class DGate : BaseEntity
    {
        public string Name { get; set; }

        public int GateNumber { get; set; }

        public int WarehouseId { get; set; }
        public DWarehouse Warehouse { get; set; }


        public ICollection<DSensor> Sensors { get; set; }

    }
}
