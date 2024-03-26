using cwiczenia03.Containers;

namespace cwiczenia03;

public class Ship
{
    public List<Container> ContainerList;
    public int Speed { get; set; }
    public double MaxCarry { get; set; }

    public Ship(int speed, double maxCarry)
    {
        Speed = speed;
        MaxCarry = maxCarry;
        ContainerList = new List<Container>();
    }

    public void AddContainer(Container container)
    {
        ContainerList.Add(container);
    }

    public void DeleteContainer(Container container)
    {
        ContainerList.Remove(container);
    }

}