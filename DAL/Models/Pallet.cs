using DAL.Models.Difinitions;

namespace DAL.Models
{
    public class Pallet : BaseEntity
    {
        public string? Serial { get; set; }
        public string UID { get; set; }
        public PalletStatus Status { get; set; } = PalletStatus.New;
        public DateTime? BirthDate { get; set; }

        public int? DWarehouseId { get; set; }
        public DWarehouse? DWarehouse { get; set; }

        public int? JobOrderId { get; set; }
        public JobOrder? JobOrder { get; set; }
    }

    public enum PalletStatus
    {
        New = 0,
        Damaged = 1,
        Lost = 2,
        Repaired = 3
    }
}
