namespace lab5.Subjects.Currency;

public interface ICurrencyInfo
{
    string Code { get; }
    string Name { get; }
    string ShortName { get; }
    decimal ExchangeRate { get; }
    DateTime DateForRate { get; }
}