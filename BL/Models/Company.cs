using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BL.Models
{
    public class Company
    {
        public string Name { get; set; }
        public string Ticker { get; set; }
        public float? CurrentPrice { get; set; }
        public float? MarketCap { get; set; }
        public float? SharesOutstanding { get; set; }
        public float? PE_Ratio { get; set; }

        public decimal? AverageEquityGrowth { get; set; }
        public decimal? AverageRevenueGrowth { get; set; }
        public decimal? AverageEPSGrowth { get; set; }
        public decimal? AverageNetIncomeGrowth { get; set; }
        public decimal? AverageFreeCashFlowGrowth { get; set; }

        //public decimal? AverageROE { get; set; }
        public decimal? AverageROIC { get; set; }

        public decimal? Growth { get; set; }

        public int Average_P_FCF_Multiple { get; set; } = 10;

        public decimal? IntrinsicValue { get; set; }
        public decimal? IntrinsicValue_Discounted30 { get; set; }
        public decimal? IntrinsicValue_Discounted50 { get; set; }



        public List<Financials> Financials { get; set; }


        public List<decimal> CalculateIntrinsicAndDiscountedValues(decimal? lastCashFlow = null, int discountedInterestRate = 10,
            decimal? growth = null, float? sharesOutstanding = null, int terminalMultiple = 10)
        {
            if (this.Financials[0].FreeCashFlow.Count < 4)
                return new List<decimal>() { 0, 0, 0 };

            if (lastCashFlow == null)
            {
                var avgCf = this.Financials[0].FreeCashFlow.Average(c => c.Value);

                if (avgCf > 0)
                    lastCashFlow = (decimal)avgCf;
                else
                {
                    var lastCf = this.Financials[0].FreeCashFlow.FindLast(c => c.Value > 0);
                    if (lastCf != null)
                        lastCashFlow = (decimal)lastCf.Value;
                    else
                        return new List<decimal>() { 0, 0, 0 };
                }

                //var lastCf = this.Financials[0].FreeCashFlow.FindLast(c => c.Value > 0);
                //if (lastCf != null)
                //    lastCashFlow = (decimal)lastCf.Value;
                //else
                //    return new List<decimal>() { 0, 0, 0 };
            }            

            if (growth == null)
            {
                growth = this.Growth;
            }
            if (sharesOutstanding == null)
            {
                sharesOutstanding = this.SharesOutstanding;
            }



            List<decimal> values = new List<decimal>();

            List<decimal> futureCashFlows = new List<decimal>();
            for (int i = 0; i < 10; i++)
            {
                if (futureCashFlows.Count > 0)
                    futureCashFlows.Add(futureCashFlows[i - 1] + (Math.Abs(futureCashFlows[i - 1]) * ((decimal)growth / 100)));
                else
                    futureCashFlows.Add((decimal)lastCashFlow + (Math.Abs((decimal)lastCashFlow) * ((decimal)growth / 100)));
            }

            List<decimal> discountedfutureCashFlows = new List<decimal>();
            for (int i = 0; i < 10; i++)
            {
                discountedfutureCashFlows.Add((decimal)((double)futureCashFlows[i] / Math.Pow(1 + (discountedInterestRate / 100.0), (i + 1))));
            }

            decimal intrinsicValue = (terminalMultiple * discountedfutureCashFlows[9] + discountedfutureCashFlows.Sum(cf => cf)) / (decimal)sharesOutstanding;

            decimal intrinsicValueDiscounted30 = intrinsicValue * (decimal)0.7;
            decimal intrinsicValueDiscounted50 = intrinsicValue * (decimal)0.5;

            values.Add(intrinsicValue);
            values.Add(intrinsicValueDiscounted30);
            values.Add(intrinsicValueDiscounted50);

            return values;
        }
    }
}
