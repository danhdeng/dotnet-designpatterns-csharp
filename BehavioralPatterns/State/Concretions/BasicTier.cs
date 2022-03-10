using RealisticDependencies;
using RealisticDependencies.Models;
using RealisticDependencies.Provider;

namespace BehavioralPatterns.State.Connections;

public class BasicTier : RewardsTier {
    private readonly ISendMails _emailer;
    public BasicTier(RewardsTier state, ISendMails emailer) : this(state.PointBalance, state.Account, emailer) {
        _emailer = emailer;
    }

    public BasicTier(int pointBalance, RewardsAccount account, ISendMails emailer) : base(emailer) {
        PointBalance = pointBalance;
        Account = account;
        Initialize();
    }

    public void Initialize()
    {
        AvailablePerks = new List<string> { "1 Free Coffee", "1 free Tea" };
    }

    public override void OnPurchase(int points) {
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
        if (PointBalance > Configuration.MinPremiumPointsBalance) { 
            var email=new EmailMessage(Account.GetPatronEmail(), "Congrats! You're now a Premium Rewards Member.");
            _emailer.SendMessage(email);
            Account.RewardsTier = new PremiumTier(this, _emailer);

        } 
    }
}