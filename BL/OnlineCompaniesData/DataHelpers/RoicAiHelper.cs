using BL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BL.OnlineCompaniesData.DataHelpers
{
    public class RoicAiHelper
    {
        const int lastNoOfYears = 5;
        public static void GetCompanyGeneralInfo(string html, Company company)
        {
            RootRoicAiModel roicAiprops = GetRoicModel(html);

            if (roicAiprops.props.pageProps.ya_price != null)
            {
                company.Name = roicAiprops.props.pageProps.ya_price?.price.longName;
                company.CurrentPrice = roicAiprops.props.pageProps.ya_price?.price.regularMarketPrice.raw;
                company.MarketCap = roicAiprops.props.pageProps.ya_price?.price.marketCap.raw / 1000000000;//to billions
                company.PE_Ratio = roicAiprops.props.pageProps.data.data.outlook[0].ratios[0].peRatioTTM;
            }
            else
            {
                DataAggregator_MarketWatch da_marketWatch = new DataAggregator_MarketWatch();
                var mw_company = da_marketWatch.GetCompanyCurrentPrice(company.Ticker);

                company.Name = mw_company.Name;
                company.CurrentPrice = mw_company.CurrentPrice;
                company.MarketCap = mw_company.MarketCap;
                company.PE_Ratio = mw_company.PE_Ratio;
            }


            //get ROIC ratios            
            string splitHtml = html.Replace("<", "\n<");
            List<string> rawLines = HtmlHelper.GetRawLinesFromHtml(splitHtml);
            List<string> selectedLines = HtmlHelper.GetImportantLines(rawLines, "ROIC", "Return on capital");
            ////extragerea datelor
            List<YearVal> roic = new List<YearVal>();
            for (int i = 0; i < selectedLines.Count; i++)
            {
                if (selectedLines[i].Contains("justify-end") && selectedLines[i].Contains("%"))
                {
                    decimal roicValue;
                    bool converted = decimal.TryParse(HtmlHelper.ExtractString(selectedLines[i], ">", "%", false).Replace("(", "-").Replace(")", ""),out roicValue);
                    if (converted)
                        roic.Add(new YearVal { Value = roicValue });
                }
            }



            var last5Roic = roic.Skip(Math.Max(0, roic.Count - lastNoOfYears)).ToList();
            if (last5Roic.Count > 0 && last5Roic.FindAll(k => k.Value != null).Count > 0)
                company.AverageROIC = (decimal)last5Roic.FindAll(k => k.Value != null).Select(k => k.Value).Average();
        }


        public static void GetCompanyFinancials(string html, Company company)
        {
            RootRoicAiModel roicAiprops = GetRoicModel(html);

            Financials financials = GetFinancialData(roicAiprops);            

            company.SharesOutstanding = financials.Shares.Last().Value != 0 ? financials.Shares.Last().Value : 1;
            company.Financials = financials;
        }

        private static RootRoicAiModel GetRoicModel(string html)
        {
            string html_financials = html.Replace("application/json\">", "application/json\">\n").Replace("</script>", "\n</script>");

            List<string> rawLines_financials = HtmlHelper.GetRawLinesFromHtml(html_financials);

            string jsonString = rawLines_financials.Find(r => r.Contains("props"));

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Error = (serializer, err) =>
                {
                    err.ErrorContext.Handled = true;
                }
            };
            
            RootRoicAiModel roicAiprops = JsonConvert.DeserializeObject<RootRoicAiModel>(jsonString, settings);

            return roicAiprops;
        }

        private static Financials GetFinancialData(RootRoicAiModel roicAiModel)
        {
            Financials financials = new Financials();

            List<Isy> incomeStatement = roicAiModel.props.pageProps.data.data.isy;
            List<Bsy> balanceSheet = roicAiModel.props.pageProps.data.data.bsy;
            List<Cfy> cashflowStatment = roicAiModel.props.pageProps.data.data.cfy;

            //level out the statements
            var statementsListCount = new List<int>() { incomeStatement.Count, balanceSheet.Count, cashflowStatment.Count };
            var maxNoYears = statementsListCount.Max();

            var finyearsStatement = incomeStatement.Select(s => s.calendarYear).ToList();
            if(balanceSheet.Count == maxNoYears)
                finyearsStatement = balanceSheet.Select(s => s.calendarYear).ToList();
            //if (cashflowStatment.Count == maxNoYears)
            //    finyearsStatement = cashflowStatment.Select(s => s.calendarYear).ToList();


            var dummyNo = maxNoYears - incomeStatement.Count;
            for (int i = 0; i < dummyNo; i++)
            {
                incomeStatement.Add(new Isy
                {
                    revenue = null,
                    netIncome = null,
                    epsdiluted = null,
                    operatingIncomeRatio=null,
                    weightedAverageShsOutDil=null
                });
            }

            dummyNo = maxNoYears - balanceSheet.Count;
            for (int i = 0; i < dummyNo; i++)
            {
                balanceSheet.Add(new Bsy
                {
                    totalStockholdersEquity = null,
                    shortTermDebt = null,
                    longTermDebt = null,
                    retainedEarnings=null,
                    cashAndShortTermInvestments=null
                });
            }

            dummyNo = maxNoYears - cashflowStatment.Count;
            for (int i = 0; i < dummyNo; i++)
            {
                cashflowStatment.Add(new Cfy { 
                    freeCashFlow=null,
                    capitalExpenditure=null
                });
            }


            List<YearVal> revenue = new List<YearVal>();
            List<YearVal> netIncome = new List<YearVal>();
            List<YearVal> EPS = new List<YearVal>();
            List<YearVal> FCFperShare = new List<YearVal>();
            List<YearVal> operatingMargin = new List<YearVal>();

            List<YearVal> equity = new List<YearVal>();
            List<YearVal> shortTermDebt = new List<YearVal>();
            List<YearVal> longTermDebt = new List<YearVal>();
            List<YearVal> retainedEarnings = new List<YearVal>();
            List<YearVal> cash = new List<YearVal>();
            List<YearVal> shares = new List<YearVal>();

            List<YearVal> freeCashFlow = new List<YearVal>();
            List<YearVal> capitalExpenditures = new List<YearVal>();


            int index = -1;

            for (int i = maxNoYears-1; i >= 0; i--)
            {
                index++;

                AddFinancialValue(incomeStatement[i].revenue, finyearsStatement[i], revenue, index);
                AddFinancialValue(incomeStatement[i].netIncome, finyearsStatement[i], netIncome, index);
                AddFinancialValue(incomeStatement[i].epsdiluted, finyearsStatement[i], EPS, index, false);
                AddFinancialValue(incomeStatement[i].operatingIncomeRatio != null ? incomeStatement[i].operatingIncomeRatio * 100 : null, finyearsStatement[i], operatingMargin, index, false);
                AddFinancialValue(incomeStatement[i].weightedAverageShsOutDil, finyearsStatement[i], shares, index);

                AddFinancialValue(balanceSheet[i].totalStockholdersEquity, finyearsStatement[i], equity, index);
                AddFinancialValue(balanceSheet[i].shortTermDebt, finyearsStatement[i], shortTermDebt, index);
                AddFinancialValue(balanceSheet[i].longTermDebt, finyearsStatement[i], longTermDebt, index);
                AddFinancialValue(balanceSheet[i].retainedEarnings, finyearsStatement[i], retainedEarnings, index);
                AddFinancialValue(balanceSheet[i].cashAndShortTermInvestments, finyearsStatement[i], cash, index);                

                AddFinancialValue(cashflowStatment[i].freeCashFlow, finyearsStatement[i], freeCashFlow, index);
                AddFinancialValue(cashflowStatment[i].capitalExpenditure, finyearsStatement[i], capitalExpenditures, index);

                var fcfPerShare = cashflowStatment[i].freeCashFlow / incomeStatement[i].weightedAverageShsOutDil;
                AddFinancialValue(fcfPerShare, finyearsStatement[i], FCFperShare, index, false);
            }            

            financials.Revenue = revenue.Skip(Math.Max(0, revenue.Count - lastNoOfYears)).ToList();
            financials.NetIncome = netIncome.Skip(Math.Max(0, netIncome.Count - lastNoOfYears)).ToList();
            financials.OperatingMargin = operatingMargin.Skip(Math.Max(0, operatingMargin.Count - lastNoOfYears)).ToList();
            financials.Shares = shares.Skip(Math.Max(0, shares.Count - lastNoOfYears)).ToList();
            financials.EPS = EPS.Skip(Math.Max(0, EPS.Count - lastNoOfYears)).ToList();
            financials.FCFperShare = FCFperShare.Skip(Math.Max(0, FCFperShare.Count - lastNoOfYears)).ToList();
            financials.Equity = equity.Skip(Math.Max(0, equity.Count - lastNoOfYears)).ToList();
            financials.ShortTermDebt = shortTermDebt.Skip(Math.Max(0, shortTermDebt.Count - lastNoOfYears)).ToList();
            financials.LongTermDebt = longTermDebt.Skip(Math.Max(0, longTermDebt.Count - lastNoOfYears)).ToList();
            financials.RetainedEarnings = retainedEarnings.Skip(Math.Max(0, retainedEarnings.Count - lastNoOfYears)).ToList();
            financials.Cash = cash.Skip(Math.Max(0, cash.Count - lastNoOfYears)).ToList();
            financials.FreeCashFlow = freeCashFlow.Skip(Math.Max(0, freeCashFlow.Count - lastNoOfYears)).ToList();
            financials.CapitalExpenditures = capitalExpenditures.Skip(Math.Max(0, capitalExpenditures.Count - lastNoOfYears)).ToList();


            return financials;
        }

        private static void AddFinancialValue(decimal? value,  string calendarYear, List<YearVal> financialItem, int index, bool convertToBillions=true)
        {
            YearVal yearVal = new YearVal();
            yearVal.Year = Convert.ToInt32(calendarYear);
            if (convertToBillions)
                yearVal.Value = value / 1000000000;//convert to billions
            else
                yearVal.Value = value;

            if (index > 0)
            {
                var newVal = yearVal.Value;
                var oldVal = financialItem[index - 1].Value;
                if (newVal != null && oldVal != null && oldVal != 0)
                    yearVal.Growth = ((decimal)newVal - (decimal)oldVal) / Math.Abs((decimal)oldVal) * 100;
            }
            financialItem.Add(yearVal);
        }

        private static float? ConvertStringToBillions(string value)
        {
            if (value != "- -")
            {
                //try
                //{
                value = value.Replace("(", "-").Replace(")", "");


                float? number = null;
                if (value.ToUpper().EndsWith("K"))
                    number = float.Parse(value.Substring(0, value.Length - 1)) / 1000000;
                else
                    if (value.ToUpper().EndsWith("M"))
                    number = float.Parse(value.Substring(0, value.Length - 1)) / 1000;
                else
                        if (value.ToUpper().EndsWith("B"))
                    number = float.Parse(value.Substring(0, value.Length - 1));
                else
                            if (value.ToUpper().EndsWith("T"))
                    number = float.Parse(value.Substring(0, value.Length - 1)) * 1000;
                else
                    number = float.Parse(value);

                return number;
                
            }
            else
                return null;
        }

    }
}
