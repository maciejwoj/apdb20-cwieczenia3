using cwiczenia03.Interfaces;

namespace cwiczenia03.Containers;

public class GasContainer : Container, IHazardNotifier
{
    protected double Pressure;
    public GasContainer(double weight, double height, double maxLoad, double deep, string kind, double pressure) : base(weight, height, maxLoad, deep, "G")
    {
        Pressure = pressure;
    }

    public override void Unload()
    {
        LoadWeight = 0.05 * LoadWeight;
    }

    public void NotifyDangerousSituation(string containerNumber)
    {
        Console.Write($"Dangerous situation in {containerNumber}");
    }
}