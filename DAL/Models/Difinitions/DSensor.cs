using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Difinitions
{
    [Table(name: "Sensors", Schema = "Definitions")]
    public class DSensor : BaseEntity 
    {
        public string  Name { get; set; }   

        public int GateId { get; set; }

        public DGate Gate { get; set; }


        public ICollection<TagDirection> TagDirections { get; set; }
    }
}
