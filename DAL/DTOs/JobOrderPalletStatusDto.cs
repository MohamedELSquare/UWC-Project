using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    public class JobOrderPalletStatusDto
    {
        public int JobOrderId { get; set; }
        public int NumberOfPallets { get; set; }
        //public string Status { get; set; }
    }
}
