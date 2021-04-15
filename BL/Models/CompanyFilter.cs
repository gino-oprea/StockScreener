using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public enum PriceFilter
    {
        IntrinsicValue = 0,
        MOS30 = 1,
        MOS50 = 2,
        IntrinsicValuePremium10 = 3,
        IntrinsicValuePremium20 = 4,
        Unlimited = 5
    }

    public class CompanyFilter
    {
        public PriceFilter PriceFilter { get; set; }

        public int MinAvgEqGrowth { get; set; }
        public int MinAvgRevenueGrowth { get; set; }
        public int MinAvgEPSGrowth { get; set; }
        public int MinAvgFreeCashFlowGrowth { get; set; }
        public int MinAvgROE { get; set; }
        public int DiscountRate { get; set; }
        public bool IsAllGrowthPositive { get; set; }

        public bool AllowOneNegativeYear { get; set; }

    }
}
