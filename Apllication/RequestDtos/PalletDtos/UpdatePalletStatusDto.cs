using DAL.Models;

namespace Apllication.RequestDtos.PalletDtos
{
    public class UpdatePalletStatusDto
    {
        public int PalletId { get; set; }
        public PalletStatus Status { get; set; }
    }

}
