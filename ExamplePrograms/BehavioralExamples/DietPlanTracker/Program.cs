using BehavioralPatterns.Observer;
using BehavioralPatterns.Observer.Observers;
using RealisticDependencies.Logger;

namespace ExamplePrograms.BehavioralPrograms.DietPlanTracker;

internal class Program {
    private static void Main() {
        var logger = new ConsoleLogger();

        logger.LogInfo("😅 Welcome to the Diet Plan Client");
        logger.LogInfo("----------------------------------");

        var subject = new Subject(logger);

        var profileObserver = new ProfileObserver(logger);
        subject.Attach(profileObserver);

        var dietPlanObserver=new DietPlanObserver(logger);
        subject.Attach(dietPlanObserver);

        subject.UpdagteEmailAddress();
        subject.UpdagteEmailAddress();
        subject.Detach(dietPlanObserver);
        subject.UpdagteEmailAddress();

    }
}