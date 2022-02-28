using RealisticDependencies.Logger;
using RealisticDependencies.Models;

namespace RealisticDependencies.Provider;

public class Emailer : ISendMails {
    private readonly IApplicationLogger _logger;

    public Emailer(IApplicationLogger logger) {
        _logger = logger;
    }

    public async Task SendMessage(EmailMessage message) {
        await Task.Delay(1000);
        _logger.LogInfo($"Send Email to :{message.To} with Message: {message.Content}", ConsoleColor.Cyan);
    }
}