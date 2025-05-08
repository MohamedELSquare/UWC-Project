using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    public class PalletStatusDto
    {
        public int Total { get; set; }
        public int Assigned { get; set; }
        public int UnAssigned { get; set; }
        public int Normal {  get; set; }
        public int Damage { get; set; }
        public int Repaired { get; set; }
        public int Lost { get; set; }
        public int InCount { get; set; }
        public int OutCount { get; set; }
    }
}
