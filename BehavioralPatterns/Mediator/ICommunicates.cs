using BehavioralPatterns.Mediator.Models;

namespace BehavioralPatterns.Mediator;

public interface ICommunicates {
    public string Handle { get; }
    public Task Send(ICommunicates to, NetworkMessage message);
    public Task Receive(NetworkMessage message);

    void SendMediator(IMediator mediator);

}