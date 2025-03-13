using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8ProductModelS00237686
{
    public class GrnLine
    {
        [Key]
        public int LineID { get; set; }
        [ForeignKey("parentGRN")]
        public IndexOutOfRangeException GrnId { get; set; }
        [ForeignKey("associatedProduct")]
        public int StockID { get; set; }
        public int QtyDelivered { get; set; }

        public virtual GRN paretnGRN { get; set; }
        public virtual Product associatedProduct { get; set; }
    }
}
