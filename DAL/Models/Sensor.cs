using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Difinitions;

namespace DAL.Models
{
    [Table(name: "Sensors", Schema = "RealTime")]
    public class Sensor: BaseEntity
    {
        public string SensorId { get; set; }
        public int Direction { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
