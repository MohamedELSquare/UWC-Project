using DAL.Models;

namespace Apllication.RequestDtos.PalletDtos
{
    public class UpdatePalletDto
    {
        public int PalletId { get; set; }
        public string Serial { get; set; }
        public string UID { get; set; }
        public PalletStatus Status { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? DWarehouseId { get; set; }
        public int? JobOrderId { get; set; }
    }
}
