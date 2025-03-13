using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Week8ProductModelS00237686
{
    public class GRN
    {
        [Key]
        public int GrnID { get; set; }
        public DateTime OrderDate { get; set; }

        [CsvHelper.Configuration.Attributes.Optional]
        public DateTime? DeliveryDate { get; set; }
        public Boolean StockUpdated { get; set; }

        public virtual ICollection<GrnLine> GRNLines {  get; set; } 


    }
}
