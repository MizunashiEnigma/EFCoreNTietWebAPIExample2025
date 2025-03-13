using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8ProductModelS00237686.CSVMapping
{
    public class GrnLineMap : ClassMap<GrnLine>
    {
        public GrnLineMap()
        {
            Map(m => m.LineID).Name("LineId");
            Map(m => m.QtyDelivered).Name("QtyDelivered");
            Map(m => m.StockID).Name("StockID");
            Map(m => m.GrnId).Name("GrnId");
        }
    }
}
