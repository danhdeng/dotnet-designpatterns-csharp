
namespace RealisticDependencies.Models;
public class QueueMessage
{
    public string Content { get; }

    public QueueMessage(string content) {
        Content = content;
    }
}
