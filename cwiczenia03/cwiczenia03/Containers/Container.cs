using cwiczenia03.Interfaces;

namespace cwiczenia03.Containers;

public abstract class Container : IContainer
{
    public double CargoWeight { get; set; }

    protected Container(double cargoWeight)
    {
        CargoWeight = cargoWeight;
    }
    
    public void Unload()
    {
        throw new NotImplementedException();
    }

    public virtual void Load(double cargoWeight)
    {
        CargoWeight = cargoWeight;
        throw new NotImplementedException();
    }
}