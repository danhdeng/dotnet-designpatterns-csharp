
using RealisticDependencies.Logger;

namespace StructualPatterns.Composition;

public class MixAndMaxBundle : TeaCarton {
    protected List<TeaCarton> SubCartons = new();
    private readonly IApplicationLogger _logger;

    public MixAndMaxBundle(IApplicationLogger logger)
    {
        _logger = logger;
    }
 
    public override void Add(TeaCarton carton)
    {
        _logger.LogInfo($"Adding  a carton of {carton} to the MixAndMathcnBundle");
        SubCartons.Add(carton);
    }

    public virtual void BuildBundle(Dictionary<TeaCarton, int> order)
    {
        foreach (var (teaCarton, quantity) in order) {
            for (var i = 0; i < quantity; i++) {
                SubCartons.Add(teaCarton);
            }
        }

    }

    public virtual void Remove(TeaCarton carton)
    {
        _logger.LogInfo($"Removing  a carton of {carton} to the MixAndMathcnBundle");
        SubCartons.Remove(carton);
    }


    public override int GetNumberOfServings()=> SubCartons.Sum(carton=> carton.GetNumberOfServings());  


    public override bool ContainsSubCarton() => false;