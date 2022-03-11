using BehavioralPatterns.Visitor;
using BehavioralPatterns.Visitor.DataProcessors;
using BehavioralPatterns.Visitor.Interfaces;
using BehavioralPatterns.Visitor.Visitors;
using RealisticDependencies;
using RealisticDependencies.Database;
using RealisticDependencies.Logger;
using RealisticDependencies.Provider;

namespace ExamplePrograms.BehavioralPrograms.FarmerMarketResearch;

internal class Program {
    private static void Main() {
        var logger = new ConsoleLogger();
        var emailer = new Emailer(logger);
        var farmerDatabase = new Database(Configuration.ConnectionString, logger);
        var floristDatabase = new Database(Configuration.ConnectionString, logger);
        var bakeryDatabase = new Database(Configuration.ConnectionString, logger);

        logger.LogInfo("🌾 Welcome to the Farmer's Market Research Application!");
        logger.LogInfo("-------------------------------------------------------");

        //Various existing components know how to produce the data we need
        //But we do't want to modify them by add new repsonsibilities, like
        //generating reports. we make these Visitable, so that a Visitor
        //can use them as it needs.
        var bakeryDataProcessor =new BakeryDataProcessor(emailer, bakeryDatabase);
        var farmerDataProcessor = new FarmerDataProcessor(bakeryDatabase);
        var floristDataProcessor = new FloristDataProcessor(emailer, bakeryDatabase);

        var dataProcessors = new List<IVisitable<Report>>
        {
            bakeryDataProcessor,
            farmerDataProcessor,
            floristDataProcessor
        };

        var reporter = new ReportRunner(logger);

        logger.LogInfo("==== Generating Sales Reports ====");
        reporter.RunReports(dataProcessors, new SaleDataVisitor(logger));

        logger.LogInfo("==== Generating Market Reports ====");
        reporter.RunReports(dataProcessors, new MarketResearchReportVisitor(logger));

    }
}