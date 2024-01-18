using BL.Adapters;
using BL.CompaniesData;
using BL.CompaniesData.JsonModels.RoicAi;
using BL.Models;
using BL.OnlineCompaniesData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace BL
{
    public class CompanyScreener
    {
        private string workingFolder = "Companies_2023";        

        public string currentTicker;
        public List<Company> currentfilteredCompanies;
        public string progress;        

        public CompanyScreener()
        {
        
        }

        public List<Company> GetFilteredCompanies(CompanyFilter filter, BackgroundWorker bgw)
        {
            CompaniesDataAggregator companiesDataAggregator = new CompaniesDataAggregator();

            List<Company> filteredCompanies = new List<Company>();           

            if (Directory.Exists(workingFolder))
            {
                // Get all first-level child folders
                var childFolders = Directory.GetDirectories(workingFolder).ToList();

                int counter = 0;
                Random rand = new Random();
                
                foreach (var companyFolder in childFolders)
                {
                    Company company = new Company();
                    counter++;
                    progress = $"{counter.ToString()} of {childFolders.Count.ToString()}";

                    if (bgw.CancellationPending)
                    {
                        return filteredCompanies;
                    }

                    try
                    {                        
                        company = companiesDataAggregator.GetCompany(Path.GetFileName(companyFolder), filter.DiscountRate);

                        if (company == null)
                            continue;

                        currentTicker = company.Ticker;


                        if (filter != null)
                        {
                            //List<decimal> values = company.CalculateIntrinsicAndDiscountedValues(discountedInterestRate: filter.DiscountRate, terminalMultiple: company.Average_P_FCF_Multiple.Value);

                            if (company.Financials != null)
                            {
                                if (company.Financials.FreeCashFlow.Count > 2
                                    && company.AverageEquityGrowth >= filter.MinAvgEqGrowth
                                    && company.AverageRevenueGrowth >= filter.MinAvgRevenueGrowth
                                    && company.AverageEPSGrowth >= filter.MinAvgEPSGrowth
                                    && company.AverageFreeCashFlowGrowth >= filter.MinAvgFreeCashFlowGrowth
                                    && company.AverageROIC >= filter.MinAvgROIC)
                                {
                                    var refPrice = GetRefPrice(company, filter);

                                    if ((decimal)company.CurrentPrice <= refPrice && company.IntrinsicValue > 0)
                                    {
                                        filteredCompanies.Add(company);                                        
                                    }
                                }
                            }

                            currentfilteredCompanies = filteredCompanies;
                        }
                        
                        Thread.Sleep(200 + rand.Next(200));
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }


            return filteredCompanies;
        }
        
        public async Task SaveCompanies(List<Company> companies)
        {
            string json = JsonConvert.SerializeObject(companies);
            await File.WriteAllTextAsync("companies.json", json);
        }
        private decimal GetRefPrice(Company company, CompanyFilter filter)
        {
            var refPrice = company.IntrinsicValue;
            switch (filter.PriceFilter)
            {
                case PriceFilter.IntrinsicValue:
                    refPrice = company.IntrinsicValue;
                    break;
                case PriceFilter.MOS10:
                    refPrice = company.IntrinsicValue_Discounted10;
                    break;
                case PriceFilter.MOS30:
                    refPrice = company.IntrinsicValue_Discounted30;
                    break;
                case PriceFilter.MOS50:
                    refPrice = company.IntrinsicValue_Discounted50;
                    break;
                case PriceFilter.IntrinsicValuePremium10:
                    refPrice = company.IntrinsicValue * (decimal)1.1;
                    break;
                case PriceFilter.IntrinsicValuePremium20:
                    refPrice = company.IntrinsicValue * (decimal)1.2;
                    break;
                case PriceFilter.Unlimited:
                    refPrice = decimal.MaxValue;
                    break;
                default:
                    refPrice = company.IntrinsicValue;
                    break;
            }

            return (decimal)refPrice;
        }
        
    }
}

