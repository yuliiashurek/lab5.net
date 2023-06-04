using lab5.Subjects;

namespace lab5;

public interface IObserver
{
    void Update(ISubject subject);
}