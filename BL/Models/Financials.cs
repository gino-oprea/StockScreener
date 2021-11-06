using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public class Financials
    {
        public SourceType Source { get; set; }
        public List<YearVal> Revenue { get; set; }
        public List<YearVal> Equity { get; set; }
        public List<YearVal> EPS { get; set; }
        public List<YearVal> FreeCashFlow { get; set; }  
        public List<YearVal> CapitalExpenditures { get; set; }
        //public List<YearVal> ROE { get; set; }


        public List<YearVal> NetIncome { get; set; }
        public List<YearVal> RetainedEarnings { get; set; }
        public List<YearVal> LongTermDebt { get; set; }
        
    }
}
