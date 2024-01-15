using BL.OfflineCompaniesData.Models.RoicAi;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.CompaniesData.JsonModels.RoicAi
{
    public class RoicAiCompany
    {
        public CompanySummary CompanySummary { get; set; }
        public IncomeStatement IncomeStatement { get; set; }
        public BalanceSheet BalanceSheet { get; set; }
        public CashFlowStatement CashFlowStatement { get; set; }
    }
}
