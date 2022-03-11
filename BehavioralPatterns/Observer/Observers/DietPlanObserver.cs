using BehavioralPatterns.Observer.Interfaces;
using RealisticDependencies.Logger;

namespace BehavioralPatterns.Observer.Observers;

public class DietPlanObserver : IObserver {
    private readonly IApplicationLogger _logger;

    public DietPlanObserver(IApplicationLogger logger) {
        _logger = logger;
    }

    public void Update(ISubject subject) {
        _logger.LogInfo($"Diet Plan Observer: State has just changed: {(subject as Subject).State.Message} on {(subject as Subject).State.LastUpdated}");

    }
}