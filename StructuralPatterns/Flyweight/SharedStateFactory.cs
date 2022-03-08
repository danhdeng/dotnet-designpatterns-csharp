using RealisticDependencies.Logger;

namespace StructualPatterns.Flyweight;

public class SharedStateFactory {

    private readonly Dictionary<string, NeighborhoodMemberSharedState> _flyweight = new();
    private readonly IApplicationLogger _logger=new ConsoleLogger();
    public SharedStateFactory(params NeighbourhoodMember[] members) {
        _logger.LogInfo("Initializing shared state (Flyweight) Factory");
        foreach (var member in members) {
            _flyweight[GetSharedStateHash(member)] = new NeighborhoodMemberSharedState(member, _logger);
        }
    }

    //Return a NeighborhoodMemberSharedState's string hash for a given state.
    private static string GetSharedStateHash(NeighbourhoodMember key)
    {
        var elements = new List<Object>
        {
            key.Subdivision,
            key.TransportationMethod
        };
        return String.Join(":", elements);
    }

    //Return an existing NeighborhoodMemberSharedState with a given state
    //or creates a new one adds it to the tracked flyweight.
    public NeighborhoodMemberSharedState GetFlyweight(NeighbourhoodMember sharedState) {
        var key = GetSharedStateHash(sharedState);
        if (_flyweight.ContainsKey(key)) { 
            return _flyweight[key];
        }
        _logger.LogInfo("FlyweightFactory: can't find a flyweight, creating new one.", ConsoleColor.Magenta);
        _flyweight[key] = new NeighborhoodMemberSharedState(sharedState, _logger);
        return _flyweight[key];
    }

    public void DisplayCache() {
        _logger.LogInfo($"== Shared State Cache: \n {string.Join("\n", _flyweight.Keys)}", ConsoleColor.Magenta);
    }
}