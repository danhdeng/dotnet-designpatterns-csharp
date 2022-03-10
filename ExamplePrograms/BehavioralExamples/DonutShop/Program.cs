using BehavioralPatterns.Memento;
using BehavioralPatterns.Memento.Constants;
using RealisticDependencies.Logger;

namespace ExamplePrograms.BehavioralPrograms.DoughnutShop;

internal class Program {
    private static void Main() {
        var logger = new ConsoleLogger();
        logger.LogInfo("🍩 Welcome to the Doughnut Shop.  Let's demo our cart client...");
        logger.LogInfo("----------------------------------------------------------------");

        //the underlying cart representation
        var shoppingCart = new Cart(logger);

        //The implementation of cart memory we'd like to use in our client
        var memory = new CartMemory();

        var cartClient = new CartClient(shoppingCart, memory, logger);

        cartClient.Add(Doughnut.Chocolate);
        cartClient.Add(Doughnut.Vanilla);
        cartClient.Add(Doughnut.Blueberry);

        Thread.Sleep(1_500);
        cartClient.Add(Doughnut.Chocolate);
        Thread.Sleep(1_500);
        cartClient.Add(Doughnut.Chocolate);
        Thread.Sleep(1_000);
        cartClient.Add(Doughnut.Chocolate); 
        Thread.Sleep(800);
        cartClient.Add(Doughnut.Chocolate);
        Thread.Sleep(500);
        cartClient.Add(Doughnut.Chocolate);
        Thread.Sleep(2_000);
        logger.LogInfo("----------------------------------------------------------------", ConsoleColor.Cyan);
        logger.LogInfo("Initial Cart:", ConsoleColor.Cyan);
        logger.LogInfo("----------------------------------------------------------------", ConsoleColor.Cyan);
        cartClient.Print();

        cartClient.Undo();
        cartClient.Undo();
        cartClient.Undo();

        logger.LogInfo("----------------------------------------------------------------", ConsoleColor.Cyan);
        logger.LogInfo("Final Cart after Undo Operations:", ConsoleColor.Cyan);
        logger.LogInfo("----------------------------------------------------------------", ConsoleColor.Cyan);

        cartClient.Print();

        logger.LogInfo("----------------------------------------------------------------", ConsoleColor.Cyan);
        logger.LogInfo("Current Memory Dump:", ConsoleColor.Cyan);
        logger.LogInfo("----------------------------------------------------------------", ConsoleColor.Cyan);

        cartClient.GetMemoryDump();
    }
}