using System.Runtime.InteropServices.JavaScript;
using cwiczenia03.Exceptions;
using cwiczenia03.Interfaces;

namespace cwiczenia03.Containers;

public abstract class Container : IContainer
{
    public double LoadWeight { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public double MaxLoad { get; set; }
    public double Deep { get; set; }
    public String SerialNumber { get; set;  }
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
    
    public virtual void Unload()
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