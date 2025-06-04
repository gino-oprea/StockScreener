using System;
using System.Collections.Generic;
using System.Text;

namespace BL.ModelsUI
{
    [Serializable]
    public class Financials
    {        
        public List<YearVal> Revenue { get; set; }
        public List<YearVal> Equity { get; set; }
        public List<YearVal> EPS { get; set; }
        public List<YearVal> FCFperShare { get; set; }
        public List<YearVal> OperatingMargin { get; set; }
        public List<YearVal> FreeCashFlow { get; set; }  
        public List<YearVal> CapitalExpenditures { get; set; }                
        public List<YearVal> ROIC { get; set; }
        public List<YearVal> Shares { get; set; }
        public List<YearVal> NetIncome { get; set; }
        public List<YearVal> RetainedEarnings { get; set; }
        public List<YearVal> Cash { get; set; }
        public List<YearVal> ShortTermDebt { get; set; }
        public List<YearVal> LongTermDebt { get; set; }
        
    }
}
