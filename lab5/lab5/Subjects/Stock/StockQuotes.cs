namespace lab5.Subjects.Stock;

public abstract class StockQuotes : ISubject
{
    public string Name { get; }
    private readonly List<IObserver> _observers = new();
    public double QuotedPrice { get; private set; }
    public DateTime LastUpdated { get; private set; }
    public double PercentageDifference { get; private set; }

    protected StockQuotes(string name,double quotedPrice)
    {
        QuotedPrice = quotedPrice;
        Name = name;
        LastUpdated = DateTime.Now;
        PercentageDifference = 0;
    }
    
    public void SetNewQuotedPrice(double newQuotedPrice)
    {
        PercentageDifference = ((newQuotedPrice * 100) / QuotedPrice) - 100;
        QuotedPrice = newQuotedPrice;
        LastUpdated = DateTime.Now;
        NotifyObservers();
    }
    // public double GetQuotedPrice()
    // {
    //     return QuotedPrice;
    // }

    public void RegisterObserver(IObserver observer)
    {
        Console.WriteLine("Observer Added : " + ((Observer)observer).UserName);
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        Console.WriteLine("Observer Removed : " + ((Observer)observer).UserName);
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        Console.WriteLine("Currency rates have changed. Therefore, notifying all registered users...");
        foreach (IObserver observer in _observers)
        {
            observer.Update(this);
        }
    }
}