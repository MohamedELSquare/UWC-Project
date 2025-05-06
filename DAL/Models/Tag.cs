using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table(name:"Tags", Schema = "RealTime")]
    public class Tag:BaseEntity
    {
        public string Epc { get; set; }
        public string Tid { get; set; }
        public string Ant { get; set; }
        public string Rssi { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
