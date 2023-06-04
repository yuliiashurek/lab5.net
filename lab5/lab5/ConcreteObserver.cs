using lab5.Subjects;

namespace lab5;

public class Observer : IObserver
{
    public string UserName { get; }

    public Observer(string userName)
    {
        UserName = userName;
    }
    public void AddSubscriber(ISubject subject)
    {
        subject.RegisterObserver(this);
    }
    public void RemoveSubscriber(ISubject subject)
    {
        subject.RemoveObserver(this);
    }

    public void Update(ISubject subject)
    {
        Console.WriteLine(UserName + " sees updated info: \n"  + subject.SubjectToString());
    }
}