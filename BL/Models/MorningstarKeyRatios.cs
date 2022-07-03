using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public class MorningstarKeyRatios
    {
        public List<MorningstarKeyRatio> dataList { get; set; }
    }
    public class MorningstarKeyRatio
    {
        public string fiscalPeriodYear { get; set; }
        public decimal? grossMargin { get; set; }
        public decimal? operatingMargin { get; set; }
        public decimal? netMargin { get; set; }                
        public decimal? roa { get; set; }
        public decimal? roe { get; set; }
        public decimal? roic { get; set; }        
    }

}
