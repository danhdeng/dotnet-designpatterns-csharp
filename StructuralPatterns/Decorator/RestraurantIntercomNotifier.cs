namespace StructualPatterns.Decorator;

public class RestraurantIntercomNotifier : Notifier
{

    public override Task HandleTableReadyMessage() { 
        Console.ForegroundColor= ConsoleColor.Green;
        Console.WriteLine(":: Restraurant Intercom -  Your table is ready");
        Console.ResetColor();
        return Task.CompletedTask;
    } 
}