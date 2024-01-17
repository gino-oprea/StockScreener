using BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.CompaniesData.JsonModels.RoicAi
{
    public class MacroTrendsData
    {
        public List<YearVal> SharesOutstanding { get; set; }
        public int? AveragePriceToFreeCashFlowMultiple { get; set; }
    }
}
