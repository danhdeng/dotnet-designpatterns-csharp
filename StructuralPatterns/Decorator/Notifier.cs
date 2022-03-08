namespace StructualPatterns.Decorator;

public abstract class Notifier {
    public abstract Task HandleTableReadyMessage();
}