using DAL.Models;

namespace Apllication.RequestDtos.PalletDtos
{
    public class AddPalletDto
    {
        public string Serial { get; set; }
        public string UID { get; set; }
        public PalletStatus Status { get; set; } = PalletStatus.New;
        public DateTime? BirthDate { get; set; }
        public int? DWarehouseId { get; set; }
        public int? JobOrderId { get; set; }
    }
}
