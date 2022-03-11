using RealisticDependencies;
using RealisticDependencies.Models;
using RealisticDependencies.Provider;

namespace BehavioralPatterns.State.Connections;

/// <summary>
/// Implements particular behaviors associated with the state of
/// a Rewards State Context
/// </summary>
public class BasicTier : RewardsTier
{
    private readonly ISendMails _emailer;
    public BasicTier(
        RewardsTier state,
        ISendMails emailer) : this(state.PointBalance, state.Account, emailer)
    {
        _emailer = emailer;
    }

    public BasicTier(
        int pointsBalance,
        RewardsAccount account,
        ISendMails emailer) : base(emailer)
    {
        PointBalance = pointsBalance;
        Account = account;
        Initialize();
    }

    private void Initialize()
    {
        AvailablePerks = new List<string> { "1 Free Coffee", "1 Free Tea" };
    }

    public override void OnPurchase(int points)
    {
        PointBalance += points;
        RefreshState();
    }

    public override void UsePoints(int points)
    {
        PointBalance -= points;
        RefreshState();
    }

    private void RefreshState()
    {
        if (PointBalance > Configuration.MinPremiumPointsBalance)
        {
            var email = new EmailMessage(Account.GetPatronEmail(), "Congrats! You're now a Premium Rewards Member.");
            _emailer.SendMessage(email).Wait();
            Account.RewardsTier = new PremiumTier(this, _emailer);
        }
    }

}