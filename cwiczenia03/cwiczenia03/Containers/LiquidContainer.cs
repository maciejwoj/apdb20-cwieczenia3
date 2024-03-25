using cwiczenia03.Exceptions;
using cwiczenia03.Interfaces;

namespace cwiczenia03.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool _isHazardous;
    
    public LiquidContainer(double weight, double height, double maxLoad,double deep, bool isHazardous, string kind ) : base(weight, height, maxLoad,deep, kind )
    {
        _isHazardous = isHazardous;
    }

    public override void Load(double cargoWeight)
    {
        if (_isHazardous)
        {
            if (cargoWeight > MaxLoad * 0.5)
            {
                NotifyDangerousSituation(SerialNumber);
                throw new OverfillException();
            }
        }
        else
        {
            if (cargoWeight > MaxLoad * 0.9)
            {
                NotifyDangerousSituation(SerialNumber);
                throw new OverfillException();
            }
        }
        base.Load(cargoWeight);
    }

    public void NotifyDangerousSituation(string containerNumber)
    {
        Console.Write($"Dangerous situation in {containerNumber}");
    }
}