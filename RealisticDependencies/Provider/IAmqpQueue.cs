
using RealisticDependencies.Models;

namespace RealisticDependencies.Provider;
interface IAmqpQueue
{
    public void Add(QueueMessage item);
}
