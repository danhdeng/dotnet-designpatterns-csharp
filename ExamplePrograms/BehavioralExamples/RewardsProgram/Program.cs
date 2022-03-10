using BehavioralPatterns.State;
using RealisticDependencies.Logger;
using RealisticDependencies.Provider;

namespace ExamplePrograms.BehavioralPrograms.RewardsProgram;

internal static class Program {
    private static void Main() {
        var logger = new ConsoleLogger();

        var emailer = new Emailer(logger);

        logger.LogInfo("☕ Welcome to the Cafe Rewards Program");
        logger.LogInfo("--------------------------------------");

        //Sign pu for the Rewards Program
        var rewards = new RewardsAccount(logger, emailer, "Dan");

        logger.LogInfo("Simulating Customer Activity");
        logger.LogInfo("-----------------------------");
        //Simulate Customer Activity
        rewards.OnPurchase(1);
        rewards.OnPurchase(1);
        rewards.OnPurchase(1);
        rewards.OnPurchase(1);
        rewards.OnPurchase(1);
        rewards.OnPurchase(1);
        rewards.UsePoints(2);
        rewards.UsePoints(1);
    }
}
