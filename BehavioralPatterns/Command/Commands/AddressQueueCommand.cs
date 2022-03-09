using RealisticDependencies.Logger;
using RealisticDependencies.Models;
using RealisticDependencies.Provider;

namespace BehavioralPatterns.Command.Commands;

public class AddressQueueCommand : ICommand
{
    private readonly IApplicationLogger _logger;
    private readonly IAmqpQueue _queue;
    private readonly string _address;

    public AddressQueueCommand(
        RealisticDependencies.Logger.IApplicationLogger logger,
        IAmqpQueue queue,
        string address)
    {
        _logger = logger;
        _queue = queue;
        _address = address;
        
    }

    public void Execute() {
        _logger.LogInfo("Adding User Address to Compost AWS Queue", ConsoleColor.Blue);
        _queue.Add(new QueueMessage(_address));
    }

}