using CreationalPatterns.FactoryMethod.VehicleTypes;
using RealisticDependencies.Logger;
using RealisticDependencies.Provider;

namespace CreationalPatterns.FactoryMethod;

public class BicycleDeliveryCreator : DeliveryCreateor {
    public BicycleDeliveryCreator(IAmqpQueue deliveryQueue, IApplicationLogger logger): base(deliveryQueue, logger) { }

    protected override IDeliversFood RegisterVehicle()
    {
        var bicycle = new Bicycle() {
            Color="blue",
            Style="Road", 
            Make="Trek",
            Model="Foo",
        };
        _logger.LogInfo("Registering a Bicycle to deliver food", ConsoleColor.Cyan);
        return bicycle;
    }
}