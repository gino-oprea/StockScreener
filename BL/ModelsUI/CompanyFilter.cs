﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BL.ModelsUI
{
    public enum PriceFilter
    {
        IntrinsicValue = 0,
        MOS10 = 1,
        MOS30 = 2,
        MOS50 = 3,
        IntrinsicValuePremium10 = 4,
        IntrinsicValuePremium20 = 5,
        Unlimited = 6
    }

    public class CompanyFilter
    {
        public PriceFilter PriceFilter { get; set; }

        public int MinAvgEqGrowth { get; set; }
        public int MinAvgRevenueGrowth { get; set; }
        public int MinAvgEPSGrowth { get; set; }
        public int MinAvgFreeCashFlowGrowth { get; set; }
        public int MinAvgROIC { get; set; }
        public int DiscountRate { get; set; }
    }
}
