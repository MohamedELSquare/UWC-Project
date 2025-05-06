using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Difinitions;

namespace DAL.Models
{
    [Table(name: "TagDirections", Schema = "RealTime")]
    public class TagDirection:BaseEntity
    {
        public string Epc { get; set; }
        public string Tid { get; set; }
        public string? Direction { get; set; }
        public string Rssi { get; set; }
        public DateTime TimeStamp { get; set; }
        public int? WarehouseId { get; set; } // Not For Use


        public int? DSensorId { get; set; } 
        public DSensor DSensor { get; set; }


        public TagDirection()
        {
            WarehouseId = null;
        }
    }
}
