using BehavioralPatterns.Interpreter;
using RealisticDependencies.Logger;

namespace ExamplePrograms.BehavioralPrograms.ChocolateShopBarcodes;

internal class Program {
    private static void Main() {
        var logger = new ConsoleLogger();
        var context = new BarcodeContext();

        logger.LogInfo("🍫 Welcome to the Chocolate Shop Barcode Scanner Utility");
        logger.LogInfo("--------------------------------------------------------");
        logger.LogInfo("Please enter the barcode:");
        context.BarcodeExpression = Console.ReadLine();

        var client = new BarcodeClient(logger, context);

        client.TranslateBarcode();
    }
}