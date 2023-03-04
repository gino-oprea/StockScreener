
using System.Collections.Generic;

public class RootRoicAiModel
{
    public Props props { get; set; }
}

public class Props
{
    public PageProps pageProps { get; set; }
}

public class PageProps
{    
    public PagePropsData data { get; set; }
    public YaPrice ya_price { get; set; }
}
public class YaPrice
{     
    public Price price { get; set; }
}
public class Price
{    
    public RegularMarketPrice regularMarketPrice { get; set; }
    
    public MarketCap marketCap { get; set; }

    public string longName { get; set; }
}

public class RegularMarketPrice
{
    public float raw { get; set; }
    public string fmt { get; set; }
}

public class OpenInterest
{
    public string longName { get; set; }

}
public class MarketCap
{
    public long raw { get; set; }
    public string fmt { get; set; }
    public string longFmt { get; set; }
}
public class PagePropsData
{    
    public Data data { get; set; }    
}

public class Data
{
    public bool success { get; set; }   
    
    public List<Bsy> bsy { get; set; }
    
    public List<Cfy> cfy { get; set; }
    
    public List<Isy> isy { get; set; }

    public List<Outlook> outlook { get; set; }
}

public class Outlook
{
    public List<Ratio> ratios { get; set; }   
}

public class Ratio
{   
    public float? peRatioTTM { get; set; }    
}

public class Cfy
{
    public string date { get; set; }
    public string symbol { get; set; }
    public string reportedCurrency { get; set; }
    public string cik { get; set; }
    public string fillingDate { get; set; }
    public string acceptedDate { get; set; }
    public string calendarYear { get; set; }
    public string period { get; set; }
    public object netIncome { get; set; }
    public object depreciationAndAmortization { get; set; }
    public long deferredIncomeTax { get; set; }
    public object stockBasedCompensation { get; set; }
    public object changeInWorkingCapital { get; set; }
    public long accountsReceivables { get; set; }
    public long inventory { get; set; }
    public long accountsPayables { get; set; }
    public long otherWorkingCapital { get; set; }
    public long otherNonCashItems { get; set; }
    public object netCashProvidedByOperatingActivities { get; set; }
    public long investmentsInPropertyPlantAndEquipment { get; set; }
    public long acquisitionsNet { get; set; }
    public long purchasesOfInvestments { get; set; }
    public object salesMaturitiesOfInvestments { get; set; }
    public long otherInvestingActivites { get; set; }
    public long netCashUsedForInvestingActivites { get; set; }
    public long debtRepayment { get; set; }
    public long commonStockIssued { get; set; }
    public long commonStockRepurchased { get; set; }
    public long dividendsPaid { get; set; }
    public long otherFinancingActivites { get; set; }
    public long netCashUsedProvidedByFinancingActivities { get; set; }
    public long effectOfForexChangesOnCash { get; set; }
    public object netChangeInCash { get; set; }
    public object cashAtEndOfPeriod { get; set; }
    public object cashAtBeginningOfPeriod { get; set; }
    public object operatingCashFlow { get; set; }
    public long? capitalExpenditure { get; set; }
    public float? freeCashFlow { get; set; }
    public string link { get; set; }
    public string finalLink { get; set; }
}

public class Bsy
{
    public string date { get; set; }
    public string symbol { get; set; }
    public string reportedCurrency { get; set; }
    public string cik { get; set; }
    public string fillingDate { get; set; }
    public string acceptedDate { get; set; }
    public string calendarYear { get; set; }
    public string period { get; set; }
    public object cashAndCashEquivalents { get; set; }
    public object shortTermInvestments { get; set; }
    public float? cashAndShortTermInvestments { get; set; }
    public object netReceivables { get; set; }
    public long inventory { get; set; }
    public object otherCurrentAssets { get; set; }
    public object totalCurrentAssets { get; set; }
    public object propertyPlantEquipmentNet { get; set; }
    public object goodwill { get; set; }
    public object intangibleAssets { get; set; }
    public object goodwillAndIntangibleAssets { get; set; }
    public object longTermInvestments { get; set; }
    public long taxAssets { get; set; }
    public object otherNonCurrentAssets { get; set; }
    public object totalNonCurrentAssets { get; set; }
    public long otherAssets { get; set; }
    public object totalAssets { get; set; }
    public object accountPayables { get; set; }
    public float? shortTermDebt { get; set; }
    public long taxPayables { get; set; }
    public long deferredRevenue { get; set; }
    public object otherCurrentLiabilities { get; set; }
    public object totalCurrentLiabilities { get; set; }
    public float? longTermDebt { get; set; }
    public long deferredRevenueNonCurrent { get; set; }
    public long deferredTaxLiabilitiesNonCurrent { get; set; }
    public object otherNonCurrentLiabilities { get; set; }
    public object totalNonCurrentLiabilities { get; set; }
    public long otherLiabilities { get; set; }
    public object capitalLeaseObligations { get; set; }
    public object totalLiabilities { get; set; }
    public long preferredStock { get; set; }
    public long commonStock { get; set; }
    public float? retainedEarnings { get; set; }
    public long accumulatedOtherComprehensiveIncomeLoss { get; set; }
    public object othertotalStockholdersEquity { get; set; }
    public float? totalStockholdersEquity { get; set; }
    public object totalEquity { get; set; }
    public object totalLiabilitiesAndStockholdersEquity { get; set; }
    public long minorityInterest { get; set; }
    public object totalLiabilitiesAndTotalEquity { get; set; }
    public object totalInvestments { get; set; }
    public object totalDebt { get; set; }
    public long netDebt { get; set; }
    public string link { get; set; }
    public string finalLink { get; set; }
}

public class Isy
{    public string date { get; set; }
    public string symbol { get; set; }
    public string reportedCurrency { get; set; }
    public string cik { get; set; }
    public string fillingDate { get; set; }
    public string acceptedDate { get; set; }
    public string calendarYear { get; set; }
    public string period { get; set; }
    public float? revenue { get; set; }
    public object costOfRevenue { get; set; }
    public object? grossProfit { get; set; }
    public double grossProfitRatio { get; set; }
    public object researchAndDevelopmentExpenses { get; set; }
    public object generalAndAdministrativeExpenses { get; set; }
    public object sellingAndMarketingExpenses { get; set; }
    public object sellingGeneralAndAdministrativeExpenses { get; set; }
    public long otherExpenses { get; set; }
    public object operatingExpenses { get; set; }
    public object costAndExpenses { get; set; }
    public long? interestIncome { get; set; }
    public long interestExpense { get; set; }
    public object depreciationAndAmortization { get; set; }
    public object ebitda { get; set; }
    public double ebitdaratio { get; set; }
    public object operatingIncome { get; set; }
    public float? operatingIncomeRatio { get; set; }
    public long totalOtherIncomeExpensesNet { get; set; }
    public object incomeBeforeTax { get; set; }
    public double incomeBeforeTaxRatio { get; set; }
    public object incomeTaxExpense { get; set; }
    public float? netIncome { get; set; }
    public double netIncomeRatio { get; set; }
    public double? eps { get; set; }
    public float? epsdiluted { get; set; }
    public object weightedAverageShsOut { get; set; }
    public float? weightedAverageShsOutDil { get; set; }
    public string link { get; set; }
    public string finalLink { get; set; }
}

