using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Calculated
{
    [Table(name: "HourlyPallets", Schema = "Calculated")]
    public class HourlyPallet
    {
        public int Id { get; set; }

        public DateTime? TimeStamp { get; set; }

        public int? InPallet {  get; set; }
        public int? OutPallet {  get; set; }


    }
}
