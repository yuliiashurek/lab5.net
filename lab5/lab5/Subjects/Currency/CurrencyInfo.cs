namespace lab5.Subjects.Currency;

public class CurrencyInfo : ICurrencyInfo
{
    public string Code { get; }
    public string Name { get; }
    public string ShortName { get; }
    public decimal ExchangeRate { get; }
    public DateTime DateForRate { get; }
    
    public CurrencyInfo(string code, string name, string shortName, decimal exchangeRate, DateTime dateForRate)
    {
        Code = code;
        Name = name;
        ShortName = shortName;
        ExchangeRate = exchangeRate;
        DateForRate = dateForRate;
    }
}