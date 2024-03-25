using System.Runtime.InteropServices.JavaScript;
using cwiczenia03.Exceptions;
using cwiczenia03.Interfaces;

namespace cwiczenia03.Containers;

public abstract class Container : IContainer
{
    protected double LoadWeight { get; set; }
    protected double Height { get; set; }
    protected double Weight { get; set; }
    protected double MaxLoad { get; set; }
    protected double Deep { get; set; }
    protected String SerialNumber { get; set;  }
    protected string? Kind { get; set; }
    protected static int Id = 0;

    protected Container(double weight, double height, double maxLoad,double deep, string kind  )
    {
        Kind = kind;
        Weight = Weight;
        Height = height;
        MaxLoad = maxLoad;
        Deep = deep;
        SerialNumber = "KON-" + Kind + "-" +  Id++;
    }
    
    public void Unload()
    {
        LoadWeight = 0;
    }

    public virtual void Load(double cargoWeight)
    {
        if ((LoadWeight + cargoWeight) > MaxLoad)
        {
            throw new OverfillException();
        }
        else
        {
            LoadWeight += cargoWeight;
        }
    }
}