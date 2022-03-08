namespace StructualPatterns.Decorator;

public abstract class NotificationDecorator : Notifer {
    protected Notifer Component;

    public NotificationDecorator(Notifer component) { 
        Component = component;
    }

    public override async Task HandleTableReadyMessage() => await Component.HandleTableReadyMessage();
}