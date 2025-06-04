using BL.ModelsUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public class MacroTrendsData
    {
        public List<YearVal> SharesOutstanding { get; set; }
        public int? AveragePriceToFreeCashFlowMultiple { get; set; }
    }
}
