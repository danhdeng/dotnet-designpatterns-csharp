using RealisticDependencies.Provider;

namespace BehavioralPatterns.State;

public abstract class RewardsTier {
    private readonly ISendMails _emailer;

    public RewardsTier(ISendMails emailer) {
        _emailer = emailer;
    }

    protected List<string> AvailablePerks;

    public int PointBalance { get; set; }
    public RewardsAccount Account { get; set; }

    protected RewardsStateContext RewardsStateContext;

    public void SetContext(RewardsStateContext rewardsStateContext) {
        RewardsStateContext = rewardsStateContext;
    }

    public abstract void OnPurchase(int points);
    public abstract void UsePoints(int points);
}