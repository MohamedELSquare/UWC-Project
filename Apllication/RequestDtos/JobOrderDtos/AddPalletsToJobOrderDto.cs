namespace Apllication.RequestDtos.JobOrderDtos
{
    public class AddPalletsToJobOrderDto
    {
        public int JobOrderId { get; set; }
        public List<int> PalletIds { get; set; }
    }
}
