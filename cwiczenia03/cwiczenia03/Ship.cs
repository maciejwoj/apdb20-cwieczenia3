using System.ComponentModel;

namespace cwiczenia03;

public class Ship
{
    public List<Container> ContainerList;

    public Ship(){
        ContainerList = new List<Container>();
    }

    public void AddContainer(Container container)
    {
        ContainerList.Add(container);
    }
    
}