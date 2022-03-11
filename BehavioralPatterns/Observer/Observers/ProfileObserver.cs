using BehavioralPatterns.Observer.Interfaces;
using RealisticDependencies.Logger;

namespace BehavioralPatterns.Observer.Observers;

public class ProfileObserver : IObserver
{
    private readonly IApplicationLogger _logger;

    public ProfileObserver(IApplicationLogger logger) {
        _logger = logger;
    }
    public void Update(ISubject subject)
    {
        _logger.LogInfo($"Profile Observer: State has just changed: {(subject as Subject).State.Message} on {(subject as Subject).State.LastUpdated}");
    }
}