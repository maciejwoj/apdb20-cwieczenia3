using cwiczenia03.Interfaces;

namespace cwiczenia03.Containers;

public class GasContainer : Container, IHazardNotifier
{
    public GasContainer(double weight, double height, double maxLoad, double deep, string kind) : base(weight, height, maxLoad, deep, kind)
    {
    }

    public void NotifyDangerousSituation(string containerNumber)
    {
        Console.Write($"Dangerous situation in {containerNumber}");
    }
}