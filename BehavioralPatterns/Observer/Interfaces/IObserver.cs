namespace BehavioralPatterns.Observer.Interfaces;

public interface IObserver {
    //Receives update from subject
    void Update(ISubject subject);
}