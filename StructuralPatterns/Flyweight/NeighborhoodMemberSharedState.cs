using RealisticDependencies.Logger;

namespace StructualPatterns.Flyweight;

public class NeighborhoodMemberSharedState {
    private readonly NeighbourhoodMember _shareState;
    private readonly IApplicationLogger _logger;

    public NeighborhoodMemberSharedState(NeighbourhoodMember person, IApplicationLogger logger) {
        _shareState = person;
        _logger = logger;
    }

    public void RenderPosition(NeighbourhoodMember uniqueState) {
        _logger.LogInfo($"Adding new member to ({uniqueState.PositionX}, {uniqueState.PositionY})", ConsoleColor.Green);
        _logger.LogInfo($"shared state ({_shareState.TransportationMethod}, {_shareState.Subdivision})", ConsoleColor.Green);
    }
}