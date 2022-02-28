using RealisticDependencies.Logger;
using RealisticDependencies.Models;

namespace RealisticDependencies.Provider;

public class CloudQueue : IAmqpQueue {
    private IApplicationLogger _logger;

    public CloudQueue(IApplicationLogger logger) {
        _logger = logger;
    }

    public void Add(QueueMessage item) {
        Thread.Sleep(500);

        _logger.LogInfo($"Added to queue: {item.Content}", ConsoleColor.Magenta);
    }
}