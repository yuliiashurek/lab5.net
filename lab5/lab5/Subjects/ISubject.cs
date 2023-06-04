namespace lab5.Subjects;

public interface ISubject
{
    string Name { get; }
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}