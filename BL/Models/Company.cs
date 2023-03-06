using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BL.Models
{
    public enum FinancialAverageType
    {
        AverageRevenueGrowth,
        AverageEPSGrowth,
        AverageEquityGrowth,
        AverageNetIncomeGrowth,
        AverageOperatingMarginGrowth,
        AverageFreeCashFlowGrowth
    }
    public class Company
    {
        public string Name { get; set; }
        public string Ticker { get; set; }
        public decimal? CurrentPrice { get; set; }
        public decimal? CurrentPrice_EV { get; set; }
        public decimal? MarketCap { get; set; }
        public decimal? EnterpriseValue { get; set; }
        public decimal? SharesOutstanding { get; set; }
        public decimal? PE_Ratio { get; set; }

        public decimal? AverageEquityGrowth { get; set; }
        public decimal? AverageRevenueGrowth { get; set; }
        public decimal? AverageEPSGrowth { get; set; }
        public decimal? AverageNetIncomeGrowth { get; set; }
        public decimal? AverageOperatingMarginGrowth { get; set; }
        public decimal? AverageFreeCashFlowGrowth { get; set; }

        //public decimal? AverageROE { get; set; }
        public decimal? AverageROIC { get; set; }

        public decimal? Growth { get; set; }

        public int? Average_P_FCF_Multiple { get; set; } = 10;

        public decimal? IntrinsicValue { get; set; }
        public decimal? IntrinsicValue_Discounted10 { get; set; }        
        public decimal? IntrinsicValue_Discounted30 { get; set; }        
        public decimal? IntrinsicValue_Discounted50 { get; set; }



        public Financials Financials { get; set; }


        public List<decimal> CalculateIntrinsicAndDiscountedValues(decimal? lastCashFlow = null, int discountedInterestRate = 12,
            decimal? growth = null, decimal? sharesOutstanding = null, int terminalMultiple = 10)
        {
            if (this.Financials.FreeCashFlow.Count < 4)
                return new List<decimal>() { 0, 0, 0 };

            if (lastCashFlow == null)
            {
                var avgCf = this.Financials.FreeCashFlow.Skip(this.Financials.FreeCashFlow.Count() - 3).Select(c => c.Value).Average(); //media ultimilor 3 ani
                //this.Financials.FreeCashFlow.Average(c => c.Value);

                if (avgCf > 0)
                    lastCashFlow = (decimal)avgCf;
                else
                {
                    var lastCf = this.Financials.FreeCashFlow.FindLast(c => c.Value > 0);
                    if (lastCf != null)
                        lastCashFlow = (decimal)lastCf.Value;
                    else
                        return new List<decimal>() { 0, 0, 0 };
                }               
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

            //tine cont de datorii si cash-ul curent
            decimal latestShortTermDebt = this.Financials.ShortTermDebt.Any(d => d.Value.HasValue) ? (decimal)this.Financials.ShortTermDebt.Last(d => d.Value.HasValue).Value : 0;
            decimal latestLongTermDebt = this.Financials.LongTermDebt.Any(d => d.Value.HasValue) ? (decimal)this.Financials.LongTermDebt.Last(d => d.Value.HasValue).Value : 0;
            decimal latestCash = this.Financials.Cash.Any(d => d.Value.HasValue) ? (decimal)this.Financials.Cash.Last(d => d.Value.HasValue).Value : 0;
            ///


            decimal totalIntrinsicValue = terminalMultiple * discountedfutureCashFlows[9] + discountedfutureCashFlows.Sum(cf => cf);
            decimal totalIntrinsicValueInclDebt = totalIntrinsicValue + latestCash - latestShortTermDebt - latestLongTermDebt;

            //daca valoarea calculata pe baza FCF e mai mic decat book value, valoarea intrinseca este book value            
            decimal? latestEquity = this.Financials.Equity[this.Financials.Equity.Count - 1].Value;
            decimal netDebt = latestLongTermDebt + latestShortTermDebt - latestCash;
            if ((latestEquity != null && latestEquity > 0)//book value pozitiv
                && (decimal)latestEquity.Value > totalIntrinsicValueInclDebt)
            {
                totalIntrinsicValueInclDebt = (decimal)latestEquity;
            }
            

            //decimal intrinsicValueExclDebt = totalIntrinsicValue / (decimal)sharesOutstanding;
            decimal intrinsicValueInclDebt = totalIntrinsicValueInclDebt / (decimal)sharesOutstanding;

            decimal intrinsicValueDiscounted10 = intrinsicValueInclDebt * (decimal)0.9;
            decimal intrinsicValueDiscounted30 = intrinsicValueInclDebt * (decimal)0.7;
            decimal intrinsicValueDiscounted50 = intrinsicValueInclDebt * (decimal)0.5;

            this.IntrinsicValue = intrinsicValueInclDebt;
            this.IntrinsicValue_Discounted10 = intrinsicValueDiscounted10;
            this.IntrinsicValue_Discounted30 = intrinsicValueDiscounted30;
            this.IntrinsicValue_Discounted50 = intrinsicValueDiscounted50;

            values.Add(intrinsicValueInclDebt);
            values.Add(intrinsicValueDiscounted10);
            values.Add(intrinsicValueDiscounted30);
            values.Add(intrinsicValueDiscounted50);

            return values;
        }

        private void CalculateCompoundAnualGrowthRate(FinancialAverageType finType)
        {

            List<YearVal> FinancialIndicator = null;

            switch (finType)
            {
                case FinancialAverageType.AverageRevenueGrowth:
                    FinancialIndicator = this.Financials.Revenue;
                    break;
                case FinancialAverageType.AverageEPSGrowth:
                    FinancialIndicator = this.Financials.EPS;
                    break;
                case FinancialAverageType.AverageEquityGrowth:
                    FinancialIndicator = this.Financials.Equity;
                    break;
                case FinancialAverageType.AverageNetIncomeGrowth:
                    FinancialIndicator = this.Financials.NetIncome;
                    break;
                case FinancialAverageType.AverageOperatingMarginGrowth:
                    FinancialIndicator = this.Financials.OperatingMargin;
                    break;
                case FinancialAverageType.AverageFreeCashFlowGrowth:
                    FinancialIndicator = this.Financials.FreeCashFlow;
                    break;
                default:
                    break;
            }

            decimal? growth = null;

            if (FinancialIndicator != null && FinancialIndicator.Count > 0)
            {
                //se poate calcula cresterea compusa(pentru ca sunt pozitive)
                if (FinancialIndicator[FinancialIndicator.Count - 1].Value >= 0
                    && FinancialIndicator[0].Value > 0
                    && FinancialIndicator[FinancialIndicator.Count - 1].Value >= FinancialIndicator[0].Value)
                    growth = ((decimal)Math.Pow(((double)FinancialIndicator[FinancialIndicator.Count - 1].Value / (double)FinancialIndicator[0].Value), (1 / (double)FinancialIndicator.Count)) - 1) * 100;
                else
                {
                    //nu se poate calcula cresterea compusa dar exista crestere si se face media
                    if (FinancialIndicator[FinancialIndicator.Count - 1].Value >= FinancialIndicator[0].Value)
                        growth = FinancialIndicator.Average(r => r.Growth);
                    else
                        //nu exista crestere
                        growth = 0;
                }
            }

            switch (finType)
            {
                case FinancialAverageType.AverageRevenueGrowth:
                    this.AverageRevenueGrowth = growth;
                    break;
                case FinancialAverageType.AverageEPSGrowth:
                    this.AverageEPSGrowth = growth;
                    break;
                case FinancialAverageType.AverageEquityGrowth:
                    this.AverageEquityGrowth = growth;
                    break;
                case FinancialAverageType.AverageNetIncomeGrowth:
                    this.AverageNetIncomeGrowth = growth;
                    break;
                case FinancialAverageType.AverageOperatingMarginGrowth:
                    this.AverageOperatingMarginGrowth = growth;
                    break;
                case FinancialAverageType.AverageFreeCashFlowGrowth:
                    this.AverageFreeCashFlowGrowth = growth;
                    break;
                default:
                    break;
            }
        }

        public void CalculateGrowthAverages()
        {
            decimal latestShortTermDebt = this.Financials.ShortTermDebt[this.Financials.ShortTermDebt.Count - 1].Value ?? 0;
            decimal latestLongTermDebt = this.Financials.LongTermDebt[this.Financials.LongTermDebt.Count - 1].Value ?? 0;
            decimal latestCash = this.Financials.Cash.Count > 0 ? (this.Financials.Cash[this.Financials.Cash.Count - 1].Value ?? 0) : 0;

            this.EnterpriseValue = this.MarketCap + latestLongTermDebt + latestShortTermDebt - latestCash;

            this.CurrentPrice_EV = this.EnterpriseValue.Value / this.SharesOutstanding.Value;


            this.CalculateCompoundAnualGrowthRate(FinancialAverageType.AverageRevenueGrowth);
            this.CalculateCompoundAnualGrowthRate(FinancialAverageType.AverageEPSGrowth);
            this.CalculateCompoundAnualGrowthRate(FinancialAverageType.AverageEquityGrowth);
            this.CalculateCompoundAnualGrowthRate(FinancialAverageType.AverageNetIncomeGrowth);
            this.CalculateCompoundAnualGrowthRate(FinancialAverageType.AverageOperatingMarginGrowth);
            this.CalculateCompoundAnualGrowthRate(FinancialAverageType.AverageFreeCashFlowGrowth);



            List<decimal?> allGrowthValues = new List<decimal?>() { this.AverageRevenueGrowth,
                this.AverageEPSGrowth ,
                this.AverageEquityGrowth ,
                this.AverageNetIncomeGrowth,
            this.AverageFreeCashFlowGrowth,
            this.AverageROIC};

            decimal avgGrowth = (decimal)allGrowthValues.FindAll(g => g != null).Average();
            this.Growth = Math.Min(13, avgGrowth);

            //if (this.AverageEquityGrowth != null)
            //{
            //    decimal avgGrowth = 0;
            //    if (this.AverageRevenueGrowth != null)
            //        avgGrowth = (decimal)(this.AverageRevenueGrowth +
            //           this.AverageEPSGrowth +
            //           this.AverageEquityGrowth +
            //           this.AverageNetIncomeGrowth +
            //           this.AverageFreeCashFlowGrowth) / 5;
            //    else
            //        avgGrowth = (decimal)(this.AverageEPSGrowth +
            //            this.AverageEquityGrowth +
            //            this.AverageNetIncomeGrowth +
            //            this.AverageFreeCashFlowGrowth) / 4;

            //    if (this.AverageROIC != null)
            //        if (this.AverageRevenueGrowth != null)
            //            avgGrowth = (decimal)(this.AverageRevenueGrowth +
            //           this.AverageEPSGrowth +
            //           this.AverageEquityGrowth +
            //           this.AverageNetIncomeGrowth +
            //           this.AverageFreeCashFlowGrowth +
            //           this.AverageROIC) / 6;
            //        else
            //            avgGrowth = (decimal)(this.AverageEPSGrowth +
            //           this.AverageEquityGrowth +
            //           this.AverageNetIncomeGrowth +
            //           this.AverageFreeCashFlowGrowth +
            //           this.AverageROIC) / 5;

            //    this.Growth = Math.Min(13, avgGrowth);

            //}
            //else
            //    this.Growth = 0;

            this.Average_P_FCF_Multiple ??= (int)Math.Floor(this.Growth.Value);
        }
    }
}
