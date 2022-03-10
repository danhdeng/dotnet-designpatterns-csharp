using BehavioralPatterns.State.Connections;
using RealisticDependencies.Logger;
using RealisticDependencies.Provider;

namespace BehavioralPatterns.State;

public class RewardsAccount {
    private readonly IApplicationLogger _logger;
    private readonly string _patron;
    private readonly RewardsTier _state;

    public RewardsAccount(
        IApplicationLogger logger,
        ISendMails emailer,
        string patron) {
        _logger = logger;
        _patron = patron;
        RewardsTier = new BasicTier(0, this, emailer);
        _state = new BasicTier(RewardsTier, emailer);
    }
    public double PointBalance => _state.PointBalance;
    public RewardsTier RewardsTier { get; set; }

    public string GetPatronEmail() => _patron;

    public void OnPurchase(int points) { 
        _state.OnPurchase(points);
        _logger.LogInfo($"You earned {points} points", ConsoleColor.Green);
        _logger.LogInfo($"Current Points: {PointBalance}", ConsoleColor.Green);
        _logger.LogInfo($"Rewards Status: {RewardsTier.GetType().Name}", ConsoleColor.Green);
        _logger.LogInfo($"____________________________________________________");
    }
    public void UsePoints(int points) {
        _state.UsePoints(points);
        _logger.LogInfo($"You used {points} points", ConsoleColor.Yellow);
        _logger.LogInfo($"Current Points: {PointBalance}", ConsoleColor.Yellow);
        _logger.LogInfo($"Rewards Status: {RewardsTier.GetType().Name}", ConsoleColor.Yellow);
        _logger.LogInfo($"____________________________________________________");

    }
}