using RealisticDependencies;
using RealisticDependencies.Models;
using RealisticDependencies.Provider;

namespace BehavioralPatterns.State.Connections;

public class PremiumTier : RewardsTier
{
    private readonly ISendMails _emailer;
    public PremiumTier(RewardsTier state, ISendMails emailer) : this(state.PointBalance, state.Account, emailer)
    {
        _emailer = emailer;
    }

    public PremiumTier(int pointBalance, RewardsAccount account, ISendMails emailer) : base(emailer)
    {
        PointBalance = pointBalance;
        Account = account;
        Initialize();
    }

    public void Initialize()
    {
        AvailablePerks = new List<string> { "1 Free Coffee", "1 free Tea" };
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
            Account.RewardsTier = new BasicTier(this, _emailer);
        }
    }
}