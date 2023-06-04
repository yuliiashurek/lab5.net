using System.Text;
using lab5.Subjects;
using lab5.Subjects.Currency;
using lab5.Subjects.Stock;

namespace lab5;

public static class ExtensionToString
{
    public static string ListOfCurrencyInfoToString(this List<ICurrencyInfo> currencyInfos)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var currencyInfo in currencyInfos)
        {
            sb.AppendLine(currencyInfo.CurrencyInfoToString());
        }

        return sb.ToString();
    }

    public static string CurrencyInfoToString(this ICurrencyInfo currencyInfo)
    {
        return
            $"Code: {currencyInfo.Code}, Name: {currencyInfo.Name}, ShortName: {currencyInfo.ShortName}, " +
            $"ExchangeRate: {currencyInfo.ExchangeRate}, DateTime: {currencyInfo.DateForRate}";
    }

    public static string StockQuotesToString(this StockQuotes stockQuotes)
    {
        return $"QuotedPrice: {stockQuotes.QuotedPrice}, LastUpdated: {stockQuotes.LastUpdated}, PercentageDifference: {stockQuotes.PercentageDifference}";
    
    }

    public static string CurrencyRatesToString(this CurrencyRates currencyRates)
    {
        return currencyRates.CurrencyInfos.ListOfCurrencyInfoToString();
    }

    public static string SubjectToString(this ISubject subject)
    {
        StringBuilder stringBuilder = new StringBuilder(subject.Name);
        if (subject is StockQuotes stockQuotes)
        {
            stringBuilder.AppendLine(stockQuotes.StockQuotesToString());
        }
        else if (subject is CurrencyRates currencyRates)
        {
            stringBuilder.AppendLine(currencyRates.CurrencyRatesToString());
        }

        return stringBuilder.ToString();
    }
}