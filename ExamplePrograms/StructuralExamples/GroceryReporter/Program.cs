using RealisticDependencies.Logger;
using StructualPatterns.Facade;

namespace ExamplPrograms.StructuralProgram.GroceryReporter;

internal class Program {
    private static void Main() {
        var logger = new ConsoleLogger();
        logger.LogInfo("Welcome to the Grocery Report System");

        var reporter=new DailyReporter();

        /// under the hood, the GroceryStoreManager is completing some 
        /// complex business logic. 
        /// due to this facade, we can deal with our business needs
        /// at a higher level of abstraction than working with the 
        /// GroceryStoreManager classes directly in this layer.

        reporter.KickOffProduceReport();
    }
}