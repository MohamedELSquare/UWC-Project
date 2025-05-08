using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Views
{
    public class PalletTrackingHistory
    {
        public string UID { get; set; }
        public string Serial { get; set; }
        public string Direction { get; set; }
        public string GateName { get; set; }
        public int WarehouseId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Status { get; set; }
    }
}
