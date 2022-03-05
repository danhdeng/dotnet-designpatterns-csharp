using CreationalPatterns.Prototype.Interfaces;
using RealisticDependencies.Logger;

namespace CreationalPatterns.Prototype;

public class PrototypeFactory {
    private readonly ITableIcon _table;
    private readonly IChairIcon _chair;
    private readonly IApplicationLogger _logger;

    public PrototypeFactory(ITableIcon table, IChairIcon chair, IApplicationLogger logger) {
        _table = table;
        _chair = chair;
        _logger = logger;
    }

    public IChairIcon CloneChair() {
        _logger.LogInfo("Creating a clone of chair", ConsoleColor.Cyan);

        return (IChairIcon) _chair.DeepClone();
    }

    public ITableIcon CloneTable()
    {
        _logger.LogInfo("Creating a clone of Table", ConsoleColor.Green);

        return (ITableIcon)_table.DeepClone();
    }
}