using RealisticDependencies.Logger;

namespace BehavioralPatterns.State;

/// <summary>
/// Maintains an instance of a particular Concrete State that
/// defines the current state
/// </summary>
public class RewardsStateContext {
    private readonly IApplicationLogger _logger;
    private RewardsTier _mode;
    public RewardsStateContext(IApplicationLogger logger, RewardsTier mode) {
        _logger = logger;
        TransitionTo(mode);
    }

    public void TransitionTo(RewardsTier mode)
    {
        _logger.LogInfo($"Context: Transitioning to {mode.GetType().Name}.");
            _mode = mode;
            _mode.SetContext(this);
    }
}