using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BL.ModelsUI
{
    public enum FinancialAverageType
    {
        AverageRevenueGrowth,
        AverageEPSGrowth,
        AverageFCFperShareGrowth,
        AverageEquityGrowth,
        AverageNetIncomeGrowth,
        AverageOperatingMarginGrowth,
        AverageFreeCashFlowGrowth
    }

    [Serializable]
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
        public decimal? AverageFCFperShareGrowth { get; set; }
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


        public List<decimal> CalculateIntrinsicAndDiscountedValues(decimal? lastCashFlow = null, int discountedInterestRate = 13,
            decimal? growth = null, decimal? sharesOutstanding = null, int terminalMultiple = 10)
        {
            if (Financials.FreeCashFlow.Count < 4)
                return new List<decimal>() { 0, 0, 0, 0 };

            if (lastCashFlow == null)
            {
                var avgCf = Financials.FreeCashFlow.Skip(Financials.FreeCashFlow.Count() - 3).Select(c => c.Value).Average(); //media ultimilor 3 ani
                //this.Financials.FreeCashFlow.Average(c => c.Value);

                if (avgCf > 0)
                    lastCashFlow = (decimal)avgCf;
                else
                {
                    var lastCf = Financials.FreeCashFlow.FindLast(c => c.Value > 0);
                    if (lastCf != null)
                        lastCashFlow = (decimal)lastCf.Value;
                    else
                        return new List<decimal>() { 0, 0, 0, 0 };
                }               
            }            

            if (growth == null)
            {
                growth = Growth;
            }
            if (sharesOutstanding == null)
            {
                sharesOutstanding = SharesOutstanding;
            }



            List<decimal> values = new List<decimal>();

            List<decimal> futureCashFlows = new List<decimal>();
            for (int i = 0; i < 10; i++)
            {
                if (futureCashFlows.Count > 0)
                    futureCashFlows.Add(futureCashFlows[i - 1] + Math.Abs(futureCashFlows[i - 1]) * ((decimal)growth / 100));
                else
                    futureCashFlows.Add((decimal)lastCashFlow + Math.Abs((decimal)lastCashFlow) * ((decimal)growth / 100));
            }

            List<decimal> discountedfutureCashFlows = new List<decimal>();
            for (int i = 0; i < 10; i++)
            {
                discountedfutureCashFlows.Add((decimal)((double)futureCashFlows[i] / Math.Pow(1 + discountedInterestRate / 100.0, i + 1)));
            }

            //tine cont de datorii si cash-ul curent
            decimal latestShortTermDebt = Financials.ShortTermDebt.Any(d => d.Value.HasValue) ? (decimal)Financials.ShortTermDebt.Last(d => d.Value.HasValue).Value : 0;
            decimal latestLongTermDebt = Financials.LongTermDebt.Any(d => d.Value.HasValue) ? (decimal)Financials.LongTermDebt.Last(d => d.Value.HasValue).Value : 0;
            decimal latestCash = Financials.Cash.Any(d => d.Value.HasValue) ? (decimal)Financials.Cash.Last(d => d.Value.HasValue).Value : 0;
            ///


            decimal totalIntrinsicValue = terminalMultiple * discountedfutureCashFlows[9] + discountedfutureCashFlows.Sum(cf => cf);
            decimal totalIntrinsicValueInclDebt = totalIntrinsicValue + latestCash - latestShortTermDebt - latestLongTermDebt;

            //daca valoarea calculata pe baza FCF e mai mic decat book value, valoarea intrinseca este book value            
            decimal? latestEquity = Financials.Equity[Financials.Equity.Count - 1].Value;
            decimal netDebt = latestLongTermDebt + latestShortTermDebt - latestCash;
            if (latestEquity != null && latestEquity > 0//book value pozitiv
                && latestEquity.Value > totalIntrinsicValueInclDebt)
            {
                totalIntrinsicValueInclDebt = (decimal)latestEquity;
            }
            

            //decimal intrinsicValueExclDebt = totalIntrinsicValue / (decimal)sharesOutstanding;
            decimal intrinsicValueInclDebt = totalIntrinsicValueInclDebt / (decimal)sharesOutstanding;

            decimal intrinsicValueDiscounted10 = intrinsicValueInclDebt * (decimal)0.9;
            decimal intrinsicValueDiscounted30 = intrinsicValueInclDebt * (decimal)0.7;
            decimal intrinsicValueDiscounted50 = intrinsicValueInclDebt * (decimal)0.5;

            IntrinsicValue = intrinsicValueInclDebt;
            IntrinsicValue_Discounted10 = intrinsicValueDiscounted10;
            IntrinsicValue_Discounted30 = intrinsicValueDiscounted30;
            IntrinsicValue_Discounted50 = intrinsicValueDiscounted50;

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
                    FinancialIndicator = Financials.Revenue;
                    break;
                case FinancialAverageType.AverageEPSGrowth:
                    FinancialIndicator = Financials.EPS;
                    break;
                case FinancialAverageType.AverageFCFperShareGrowth:
                    FinancialIndicator = Financials.FCFperShare;
                    break;
                case FinancialAverageType.AverageEquityGrowth:
                    FinancialIndicator = Financials.Equity;
                    break;
                case FinancialAverageType.AverageNetIncomeGrowth:
                    FinancialIndicator = Financials.NetIncome;
                    break;
                case FinancialAverageType.AverageOperatingMarginGrowth:
                    FinancialIndicator = Financials.OperatingMargin;
                    break;
                case FinancialAverageType.AverageFreeCashFlowGrowth:
                    FinancialIndicator = Financials.FreeCashFlow;
                    break;
                default:
                    break;
            }

            decimal? growth = null;


            FinancialIndicator.Reverse();
            List<YearVal> last5years =  FinancialIndicator.Take(Math.Min(FinancialIndicator.Count,5)).ToList();
            FinancialIndicator.Reverse();//put it back
            last5years.Reverse();

            if (last5years != null && last5years.Count > 0)
            {
                //se poate calcula cresterea compusa(pentru ca sunt pozitive)
                if (last5years[last5years.Count - 1].Value >= 0
                    && last5years[0].Value > 0
                    && last5years[last5years.Count - 1].Value >= last5years[0].Value)
                    growth = ((decimal)Math.Pow((double)last5years[last5years.Count - 1].Value / (double)last5years[0].Value, 1 / (double)last5years.Count) - 1) * 100;
                else
                {
                    //nu se poate calcula cresterea compusa dar exista crestere si se face media
                    if (last5years[last5years.Count - 1].Value >= last5years[0].Value)
                        growth = last5years.Average(r => r.Growth);
                    else
                        //nu exista crestere
                        growth = 0;
                }
            }

            switch (finType)
            {
                case FinancialAverageType.AverageRevenueGrowth:
                    AverageRevenueGrowth = growth;
                    break;
                case FinancialAverageType.AverageEPSGrowth:
                    AverageEPSGrowth = growth;
                    break;
                case FinancialAverageType.AverageFCFperShareGrowth:
                    AverageFCFperShareGrowth = growth;
                    break;
                case FinancialAverageType.AverageEquityGrowth:
                    AverageEquityGrowth = growth;
                    break;
                case FinancialAverageType.AverageNetIncomeGrowth:
                    AverageNetIncomeGrowth = growth;
                    break;
                case FinancialAverageType.AverageOperatingMarginGrowth:
                    AverageOperatingMarginGrowth = growth;
                    break;
                case FinancialAverageType.AverageFreeCashFlowGrowth:
                    AverageFreeCashFlowGrowth = growth;
                    break;
                default:
                    break;
            }


            Financials.ROIC.Reverse();
            List<YearVal> last5yearsROIC = Financials.ROIC.Take(Math.Min(FinancialIndicator.Count, 5)).ToList();
            Financials.ROIC.Reverse();//put it back
            last5yearsROIC.Reverse();

            AverageROIC = last5yearsROIC.Select(r => r.Value).Average();
        }

        public void CalculateGrowthAverages()
        {
            decimal latestShortTermDebt = Financials.ShortTermDebt[Financials.ShortTermDebt.Count - 1].Value ?? 0;
            decimal latestLongTermDebt = Financials.LongTermDebt[Financials.LongTermDebt.Count - 1].Value ?? 0;
            decimal latestCash = Financials.Cash.Count > 0 ? Financials.Cash[Financials.Cash.Count - 1].Value ?? 0 : 0;

            if (MarketCap != null)
            {
                EnterpriseValue = MarketCap + latestLongTermDebt + latestShortTermDebt - latestCash;
                if (SharesOutstanding != null)
                    CurrentPrice_EV = EnterpriseValue.Value / SharesOutstanding.Value;
            }


            CalculateCompoundAnualGrowthRate(FinancialAverageType.AverageRevenueGrowth);
            CalculateCompoundAnualGrowthRate(FinancialAverageType.AverageEPSGrowth);
            CalculateCompoundAnualGrowthRate(FinancialAverageType.AverageFCFperShareGrowth);
            CalculateCompoundAnualGrowthRate(FinancialAverageType.AverageEquityGrowth);
            CalculateCompoundAnualGrowthRate(FinancialAverageType.AverageNetIncomeGrowth);
            CalculateCompoundAnualGrowthRate(FinancialAverageType.AverageOperatingMarginGrowth);
            CalculateCompoundAnualGrowthRate(FinancialAverageType.AverageFreeCashFlowGrowth);



            List<decimal?> allGrowthValues = new List<decimal?>() { AverageRevenueGrowth,
                AverageEPSGrowth ,
                AverageFCFperShareGrowth,
                AverageEquityGrowth ,
                AverageNetIncomeGrowth,
            AverageFreeCashFlowGrowth,
            AverageROIC};

            decimal avgGrowth = (decimal)allGrowthValues.FindAll(g => g != null).Average();
            Growth = Math.Min(13, avgGrowth);



            Average_P_FCF_Multiple ??= (int)Math.Floor(Growth.Value);
        }

        //public Company DeepClone()
        //{
        //    using (MemoryStream memoryStream = new MemoryStream())
        //    {
        //        BinaryFormatter formatter = new BinaryFormatter();
        //        formatter.Serialize(memoryStream, this);
        //        memoryStream.Seek(0, SeekOrigin.Begin);
        //        return (Company)formatter.Deserialize(memoryStream);
        //    }
        //}
    }
}
