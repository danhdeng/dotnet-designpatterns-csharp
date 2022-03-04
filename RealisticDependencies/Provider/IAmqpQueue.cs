
using RealisticDependencies.Models;

namespace RealisticDependencies.Provider;
public interface IAmqpQueue
{
    public void Add(QueueMessage item);
}
