using lab5.Subjects.Currency.XmlCurrency;
using Timer = System.Threading.Timer;

namespace lab5.Subjects.Currency;

public class CurrencyRates : ISubject
{
    private readonly List<IObserver> _observers;
    
    public string Name { get; }
    public List<ICurrencyInfo> CurrencyInfos { get; private set; }
    private readonly WorkWithXml _workWithXml;
    private Timer _timer;


    public CurrencyRates(WorkWithXml workWithXml)
    {
        Name = "Currency Rates";
       _workWithXml = workWithXml;
        _observers = new List<IObserver>();
        CurrencyInfos = _workWithXml.CurrencyInfos;
        _timer = new Timer(TimerElapsed, null, 0, 1000);
    }

    private void TimerElapsed(object? state)
    {
        (bool hasChanged, List<ICurrencyInfo>? currencyInfoListFromXml) = _workWithXml.Reload();
        if (hasChanged)
        {
            CurrencyInfos = currencyInfoListFromXml!;
            NotifyObservers();
        }
    }

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