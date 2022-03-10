using BehavioralPatterns.Mediator.Models;
using RealisticDependencies.Logger;

namespace BehavioralPatterns.Mediator;

public abstract class FleetMember : ICommunicates
{
    protected IMediator Mediator;
    
    protected readonly IApplicationLogger Logger;
    public string Handle { get; private set; }

    protected readonly int Latitude;

    protected readonly int Longtitude;
    public FleetMember(IApplicationLogger logger,
        string handle, int lat, int lon)
    { 
        Logger = logger;
        Handle = handle;
        Latitude = lat;
        Longtitude = lon;
    }

    public abstract Task Receive(NetworkMessage message);
    
    public abstract Task Send(ICommunicates foodCart, NetworkMessage message);

    public abstract void SendMediator(IMediator mediator);

    public async Task SignalLocation() {
        await Task.Delay(250);
        var message = new NetworkMessage($"{Handle} Reporting From: [{Latitude}, {Longtitude}]");
        await Mediator.Broadcast(message);
    }
}