using cwiczenia03.Exceptions;
namespace cwiczenia03.Containers;

public class RefrigeratedContainer : Container
{
    protected double Temperature;
    protected PossibleProducts AllowedProduct { get; private set; }
    public double RequiredTemperature
    {
        get
        {
            return GetRequiredTemperature(AllowedProduct);
        }
    }

    private double GetRequiredTemperature(PossibleProducts productType)
    {

        switch (productType)
        {
            case PossibleProducts.Bananas:
                return 13.3;
            case PossibleProducts.Chocolate:
                return 18.0;
            case PossibleProducts.Fish:
                return 2.0;
            case PossibleProducts.Meat:
                return -15.0; 
            case PossibleProducts.IceCream:
                return -30.0;
            case PossibleProducts.FrozenPizza:
                return 7.2;
            case PossibleProducts.Cheese:
                return 5.0;
            case PossibleProducts.Sausages:
                return 10.0;
            case PossibleProducts.Butter:
                return 20.5;
            case PossibleProducts.Eggs:
                return 19.0;
            
            default:
                return 0.0;
        }
    }
    
    public RefrigeratedContainer(double weight, double height, double maxLoad, double deep, string kind,  PossibleProducts allowedProduct, double temperature ) : base(weight, height, maxLoad, deep, "C")
    {
        Temperature = temperature;
        AllowedProduct = allowedProduct;
    }

    public override void Load(double cargoWeight)
    {

        if (Temperature < RequiredTemperature)
        {
            throw new TemperatureTooLowException("wrong temperature for this cargo");
        }

        base.Load(cargoWeight);
    }
  
}