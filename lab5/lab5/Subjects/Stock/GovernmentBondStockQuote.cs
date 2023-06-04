namespace lab5.Subjects.Stock;

public class GovernmentBondStockQuote : StockQuotes
{
    public WayOfPaying WayOfPaying { get; }

    public GovernmentBondStockQuote(double quotedPrice, WayOfPaying wayOfPaying)
        : base("Government Bond", quotedPrice)
    {
        WayOfPaying = wayOfPaying;
    }
}