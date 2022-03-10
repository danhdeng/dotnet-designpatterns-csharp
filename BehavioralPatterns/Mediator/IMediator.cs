using BehavioralPatterns.Mediator.Models;

namespace BehavioralPatterns.Mediator;

public interface IMediator {
    public Task Register(ICommunicates member);
    public Task DeliverPayload(string handle, NetworkMessage message);

    public Task DeliverPayload(List<FleetMember> receivers, NetworkMessage message);

    public Task Broadcast(NetworkMessage message);
}