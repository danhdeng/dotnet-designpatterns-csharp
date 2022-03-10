namespace BehavioralPatterns.Observer.Interfaces;

public interface ISubject {
    //Attaches an observer to the subject
    void Attach(IObserver observer);

    //Detaches an observer to the subject
    void Detach(IObserver observer);

    //Notify all observer about an event
    void Notify();
}
