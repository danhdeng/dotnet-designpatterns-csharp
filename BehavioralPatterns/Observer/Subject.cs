using BehavioralPatterns.Observer.Interfaces;
using RealisticDependencies.Logger;

namespace BehavioralPatterns.Observer;

public class Subject : ISubject {
    public ObserverState State { get; set; } = new();
    //basic list of subscribers
    private readonly List<IObserver> _observers = new();
    private readonly IApplicationLogger _logger;

    public Subject(IApplicationLogger logger) {
        _logger = logger;
    }
    //the subscription management methods

    public void Attach(IObserver observer) {
        _logger.LogInfo("Subject: Attached an observer", ConsoleColor.Magenta);
        _observers.Add(observer);

    }

    public void Detach(IObserver observer) {
        _logger.LogInfo("Subject: Detached an observer", ConsoleColor.Magenta);
        _observers.Remove(observer);
    }

    //Trigger an update in each subscriber.
    public void Notify() {
        _logger.LogInfo("Subject: notifying all observers", ConsoleColor.Magenta);
        foreach (var observer in _observers) {
            observer.Update(this);
        }
    }

    public void UpdagteEmailAddress() { 
        _logger.LogInfo("Updating email", ConsoleColor.Magenta);
        State = new ObserverState
        {
            LastUpdated = DateTime.Now,
            Message = "EmailUpdate"
        };

        _logger.LogInfo($"Subject: State has just changed: {State.Message} on {State.LastUpdated}");
        Thread.Sleep(500);
        Notify();
    }
}