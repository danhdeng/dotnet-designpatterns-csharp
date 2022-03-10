namespace BehavioralPatterns.Mediator.Models;

public class NetworkMessage
{
    private string _payload;

    private readonly DateTime _timeSent = DateTime.UtcNow;

    private ICommunicates _from;
    public NetworkMessage(string payload) => (_payload) = (payload);

    public string GetTimeStamp() => _timeSent.ToString("T");

    public ICommunicates GetSender() => _from;

    public string Read() => _payload;

    public void Sign(ICommunicates signature)
    {
        _from = signature;
        _payload = $"<@{signature.Handle} : {_payload}>";
    }
}