using BL.OfflineCompaniesData.Models.RoicAi_Old;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.CompaniesData.JsonModels.RoicAi_Old
{
    public class RoicAiCompany_Old
    {
        public CompanySummary_Old CompanySummary { get; set; }
        public IncomeStatement_Old IncomeStatement { get; set; }
        public BalanceSheet_Old BalanceSheet { get; set; }
        public CashFlowStatement_Old CashFlowStatement { get; set; }
        public MacroTrendsData MacroTrendsData { get; set; }
    }
}
