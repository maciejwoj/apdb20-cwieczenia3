// See https://aka.ms/new-console-template for more information

using cwiczenia03;
using cwiczenia03.Containers;
using cwiczenia03.Exceptions;

internal class Program
{
    public static void Main(string[] args)
    {
        List<Container> containers = new List<Container>();
        List<Ship> ships = new List<Ship>();


        static void CreateContainer(List<Container> containers)
        {
            Console.WriteLine("Choose the type of container to create:");
            Console.WriteLine("1. Gas Container");
            Console.WriteLine("2. Liquid Container");
            Console.WriteLine("3. Refrigerated Container");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter weight: ");
                    double weight = double.Parse(Console.ReadLine());
                    Console.Write("Enter height: ");
                    double height = double.Parse(Console.ReadLine());
                    Console.Write("Enter max load: ");
                    double maxLoad = double.Parse(Console.ReadLine());
                    Console.Write("Enter deep: ");
                    double deep = double.Parse(Console.ReadLine());
                    Console.Write("Enter pressure: ");
                    double pressure = double.Parse(Console.ReadLine());

                    // Tworzymy kontener typu GasContainer i dodajemy do listy
                    containers.Add(new GasContainer(weight, height, maxLoad, deep, "G", pressure));
                    Console.WriteLine("Gas Container created successfully!");
                    break;

                case "2":
                    Console.Write("Enter weight: ");
                    double weightL = double.Parse(Console.ReadLine());
                    Console.Write("Enter height: ");
                    double heightL = double.Parse(Console.ReadLine());
                    Console.Write("Enter max load: ");
                    double maxLoadL = double.Parse(Console.ReadLine());
                    Console.Write("Enter deep: ");
                    double deepL = double.Parse(Console.ReadLine());
                    Console.Write("Is hazardous (true/false): ");
                    bool isHazardous = bool.Parse(Console.ReadLine());


                    containers.Add(new LiquidContainer(weightL, heightL, maxLoadL, deepL, isHazardous, "L"));
                    Console.WriteLine("Liquid Container created successfully!");
                    break;

                case "3":
                    Console.Write("Enter weight: ");
                    double weightC = double.Parse(Console.ReadLine());
                    Console.Write("Enter height: ");
                    double heightC = double.Parse(Console.ReadLine());
                    Console.Write("Enter max load: ");
                    double maxLoadC = double.Parse(Console.ReadLine());
                    Console.Write("Enter deep: ");
                    double deepC = double.Parse(Console.ReadLine());
                    Console.Write("Enter allowed product (e.g., Meat, Fish, Dairy, Fruit, Vegetable, Other): ");
                    string allowedProductStr = Console.ReadLine();
                    PossibleProducts allowedProduct;
                    Enum.TryParse(allowedProductStr, out allowedProduct);
                    Console.Write("Enter temperature: ");
                    double temperature = double.Parse(Console.ReadLine());

                    // Tworzymy kontener typu RefrigeratedContainer i dodajemy do listy
                    containers.Add(new RefrigeratedContainer(weightC, heightC, maxLoadC, deepC, "C", allowedProduct,
                        temperature));
                    Console.WriteLine("Refrigerated Container created successfully!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                    break;
            }

            void LoadContainer(List<Container> containers)
            {
                for (int i = 0; i < containers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {containers[i].SerialNumber}");
                }

                Console.Write("Select container to load (enter number): ");
                int containerIndex = int.Parse(Console.ReadLine()) - 1;
                if (containerIndex < 0 || containerIndex >= containers.Count)
                {
                    Console.WriteLine("Invalid container index.");
                    return;
                }

                Container selectedContainer = containers[containerIndex];
                Console.Write("Enter cargo weight: ");
                double cargoWeight = double.Parse(Console.ReadLine());

                try
                {
                    selectedContainer.Load(cargoWeight);
                    Console.WriteLine($"Cargo loaded successfully into container {selectedContainer.SerialNumber}.");
                }
                catch (OverfillException)
                {
                    Console.WriteLine("Cargo weight exceeds container's capacity. Loading failed.");
                }
            }
        }
        
        
        void LoadContainer(List<Container> containers)
        {

            if (containers.Count == 0)
            {
                Console.WriteLine("No containers available.");
                return;
            }

            Console.WriteLine("Available containers:");
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {containers[i].SerialNumber}");
            }


            Console.Write("Select container (enter number): ");
            int containerIndex = int.Parse(Console.ReadLine()) - 1;
            
            if (containerIndex < 0 || containerIndex >= containers.Count)
            {
                Console.WriteLine("Invalid container index.");
                return;
            }
            
            Container selectedContainer = containers[containerIndex];
            Console.WriteLine($"Container {selectedContainer.SerialNumber} selected.");
            Console.Write("enter load weight: ");
            double newLoad = double.Parse(Console.ReadLine()) - 1;
            
            selectedContainer.Load(newLoad);
        }


        void UnloadContainer(List<Container> containers)
        {
            Console.WriteLine("Available containers:");
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {containers[i].SerialNumber}");
            }

            Console.Write("Select container to unload (enter number): ");
            int containerIndex = int.Parse(Console.ReadLine()) - 1;

            if (containerIndex < 0 || containerIndex >= containers.Count)
            {
                Console.WriteLine("Invalid container index.");
                return;
            }

            Container selectedContainer = containers[containerIndex];
            selectedContainer.Unload();
            Console.WriteLine($"Container {selectedContainer.SerialNumber} unloaded successfully.");
        }


        void ReplaceContainer(List<Container> containers)
        {

            Console.WriteLine("Available containers:");
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {containers[i].SerialNumber}");
            }


            Console.Write("Select first container to replace (enter number): ");
            int firstContainerIndex = int.Parse(Console.ReadLine()) - 1;


            if (firstContainerIndex < 0 || firstContainerIndex >= containers.Count)
            {
                Console.WriteLine("Invalid container index.");
                return;
            }


            Console.Write("Select second container to replace (enter number): ");
            int secondContainerIndex = int.Parse(Console.ReadLine()) - 1;


            if (secondContainerIndex < 0 || secondContainerIndex >= containers.Count)
            {
                Console.WriteLine("Invalid container index.");
                return;
            }

            Container firstContainer = containers[firstContainerIndex];
            Container secondContainer = containers[secondContainerIndex];
            containers[firstContainerIndex] = secondContainer;
            containers[secondContainerIndex] = firstContainer;

            Console.WriteLine(
                $"Containers {firstContainer.SerialNumber} and {secondContainer.SerialNumber} replaced successfully.");
        }


        void PrintContainersInformation(List<Container> containers)
        {

            if (containers.Count == 0)
            {
                Console.WriteLine("No containers available.");
                return;
            }

            foreach (var container in containers)
            {
                Console.WriteLine($"Serial Number: {container.SerialNumber}");
                Console.WriteLine($"Weight: {container.Weight} kg");
                Console.WriteLine($"Height: {container.Height} cm");
                Console.WriteLine($"Max Load: {container.MaxLoad} kg");
                Console.WriteLine($"Deep: {container.Deep} cm");
                Console.WriteLine($"Load Weight: {container.LoadWeight} kg");
                Console.WriteLine();
            }
        }


        void CreateShip(List<Ship> ships)
        {

            Console.Write("Enter speed (in knots): ");
            int speed = int.Parse(Console.ReadLine());
            Console.Write("Enter maximum carry capacity (in tons): ");
            double maxCarry = double.Parse(Console.ReadLine());
            Ship newShip = new Ship(speed, maxCarry);
            ships.Add(newShip);
            Console.WriteLine("New ship created successfully!");
        }


        void LoadContainerIntoShip(List<Ship> ships, List<Container> containers)
        {

            if (ships.Count == 0)
            {
                Console.WriteLine("No ships available.");
                return;
            }


            Console.WriteLine("Available ships:");
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine(
                    $"{i + 1}. Ship {i + 1} (Speed: {ships[i].Speed} knots, Max Carry: {ships[i].MaxCarry} tons)");
            }


            Console.Write("Select ship to load container into (enter number): ");
            int shipIndex = int.Parse(Console.ReadLine()) - 1;


            if (shipIndex < 0 || shipIndex >= ships.Count)
            {
                Console.WriteLine("Invalid ship index.");
                return;
            }

            Ship selectedShip = ships[shipIndex];


            Console.WriteLine("Available containers:");
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {containers[i].SerialNumber}");
            }


            Console.Write("Select container to load into the ship (enter number): ");
            int containerIndex = int.Parse(Console.ReadLine()) - 1;


            if (containerIndex < 0 || containerIndex >= containers.Count)
            {
                Console.WriteLine("Invalid container index.");
                return;
            }

            selectedShip.AddContainer(containers[containerIndex]);
            Console.WriteLine(
                $"Container {containers[containerIndex].SerialNumber} loaded successfully onto Ship {shipIndex + 1}.");
        }


void DeleteContainerFromShip(List<Ship> ships)
{
    
    Console.WriteLine("Available ships:");
    for (int i = 0; i < ships.Count; i++)
    {
        Console.WriteLine($"{i + 1}. Ship {i + 1} (Speed: {ships[i].Speed} knots, Max Carry: {ships[i].MaxCarry} tons)");
    }


    Console.Write("Select ship to delete container from (enter number): ");
    int shipIndex = int.Parse(Console.ReadLine()) - 1;


    if (shipIndex < 0 || shipIndex >= ships.Count)
    {
        Console.WriteLine("Invalid ship index.");
        return;
    }


    if (ships[shipIndex].ContainerList.Count == 0)
    {
        Console.WriteLine("Selected ship does not have any containers loaded.");
        return;
    }
    Ship selectedShip = ships[shipIndex];
    Console.WriteLine("Containers on selected ship:");
    for (int i = 0; i < selectedShip.ContainerList.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {selectedShip.ContainerList[i]}");
    }
    
    Console.Write("Select container to delete from the ship (enter number): ");
    int containerIndex = int.Parse(Console.ReadLine()) - 1;
    
    if (containerIndex < 0 || containerIndex >= selectedShip.ContainerList.Count)
    {
        Console.WriteLine("Invalid container index.");
        return;
    }


    Container removedContainer = selectedShip.ContainerList[containerIndex];
    selectedShip.DeleteContainer(removedContainer);
}


void PrintShipsInformation(List<Ship> ships)
{
    Console.WriteLine("Printing ships information...");
    
    if (ships.Count == 0)
    {
        Console.WriteLine("No ships available.");
        return;
    }
    
    foreach (var ship in ships)
    {
        Console.WriteLine($"Speed: {ship.Speed} knots");
        Console.WriteLine($"Max Carry: {ship.MaxCarry} tons");
        Console.WriteLine($"Number of Containers: {ship.ContainerList.Count}");
        Console.WriteLine();
    }
}


        while (true)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("1 - Create container");
            Console.WriteLine("2 - Load container");
            Console.WriteLine("3 - Create ship");
            Console.WriteLine("4 - Load container into ship");
            Console.WriteLine("5 - Delete container from the ship");
            Console.WriteLine("6 - Unload container");
            Console.WriteLine("7 - Replace container with another");
            Console.WriteLine("8 - Print ships information");
            Console.WriteLine("9 - Print containers information");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("==========================================");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateContainer(containers);
                    break;
                case "2":
                    LoadContainer(containers);
                    break;
                case "3":
                    UnloadContainer(containers);
                    break;
                case "4":
                    ReplaceContainer(containers);
                    break;
                case "5":
                    PrintContainersInformation(containers);
                    break;
                case "6":
                    CreateShip(ships);
                    break;
                case "7":
                    LoadContainerIntoShip(ships, containers);
                    break;
                case "8":
                    DeleteContainerFromShip(ships);
                    break;
                case "9":
                    PrintShipsInformation(ships);
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

}