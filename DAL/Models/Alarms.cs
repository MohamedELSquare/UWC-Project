using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table(name: "Alarms", Schema = "RealTime")]
    public class Alarms : BaseEntity
    {
        public string Gate { get; set; }
        public int Status { get; set; } 
    }
}
