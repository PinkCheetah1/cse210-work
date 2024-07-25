public class Shop
{
    // Attributes
    int _points;
    List<ShopItem> _shopItems;

    // Constructors\
    public Shop(int points, List<ShopItem> shopItems)
    {
        _points = points;
        _shopItems = shopItems;
    }

    // Methods
    public void DisplayItems()
    {
        int itemIndex = 0;
        foreach (ShopItem item in _shopItems)
        {
            itemIndex += 1;
            Console.WriteLine($"{itemIndex}. {item.RenderDisplay()}");
        }
    }

    public void DisplayShopMenu()
    {
        // Menu written by ChatGPT
        Console.WriteLine($"Total Points: {_points}p");
        Console.WriteLine("Shop Menu:");
        Console.WriteLine("    1. Buy Item");
        Console.WriteLine("    2. New Item");
        Console.WriteLine("    3. Restock Item");
        Console.WriteLine("    4. Return to Menu");
    }

    public int OpenShop(int points)
    {
        bool shopIsOpen = true;
        _points = points;
        int itemIndex;




        
        Console.Clear();
        Console.WriteLine("Welcome to the shop!");

        // Switch outline written by ChatGPT
        while (shopIsOpen)
        {
            DisplayItems();
            Console.WriteLine();
            DisplayShopMenu();
            Console.Write("What would you like to do? ");
            string userInput;
            userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    // Buy Item
                    Console.Write("What item would you like to buy? ");
                    userInput = Console.ReadLine();
                    itemIndex = int.Parse(userInput);
                    if (itemIndex <= _shopItems.Count())
                    {
                        if (itemIndex > 0)
                        {
                            // Do stuff
                            _points = _shopItems[itemIndex-1].BuyItem(_points);
                            Console.WriteLine("Thank you! Returning to shop menu. ");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number greater than 0. Returning to shop... ");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Please enter a number between 1 and {_shopItems.Count()}");
                    }
                    break;

                case "2":
                    // New Item
                    // Case 2 written by ChatGPT
                    Console.Write("Enter item name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter item description: ");
                    string description = Console.ReadLine();
                    Console.Write("Enter item stock: ");
                    int stock = int.Parse(Console.ReadLine());
                    Console.Write("Enter item cost: ");
                    int cost = int.Parse(Console.ReadLine());

                    // Add new item to shop items list
                    _shopItems.Add(new ShopItem(name, description, stock, cost));
                    Console.WriteLine("Item added successfully!");
                    Console.WriteLine();
                    break;

                case "3":
                    // Restock Item
                    Console.Write("What item would you like to restock? ");
                    itemIndex = int.Parse(Console.ReadLine());
                    if (itemIndex <= _shopItems.Count())
                    {
                        if (itemIndex > 0)
                        {
                            // Do stuff
                            Console.Write("How much would you like to add to this item's stock? ");
                            int restockNum = int.Parse(Console.ReadLine());
                            _shopItems[itemIndex - 1].AddStock(restockNum);
                            Console.WriteLine("Item restocked. ");
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number greater than 0. Returning to shop... ");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Please enter a number between 1 and {_shopItems.Count()}");
                    }
                    break;

                case "4":
                    // Return to Menu
                    shopIsOpen = false;
                    Console.WriteLine("Returning to main menu... ");
                    break;

                default:
                    // Invalid input
                    Console.WriteLine("Invalid input. Please choose a valid option.");
                    break;
            }
        }
        Console.WriteLine("Thank you! Returning to menu... ");

        return _points;
    }


    // Static method to load shop from file
    public static Shop LoadShopFromFile(string filePath)
    {
        // This method was written mostly by
        // ChatGPT with careful guidance
        List<ShopItem> shopItems = new List<ShopItem>();

        // Read all lines from the file
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            // Split the line into parts using the delimiter "||"
            string[] parts = line.Split(new[] { "||" }, StringSplitOptions.None);

            // Ensure the line has the correct number of parts
            if (parts.Length == 4)
            {
                string name = parts[0];
                string description = parts[1];
                int stock = int.Parse(parts[2]);
                int cost = int.Parse(parts[3]);

                // Add new ShopItem to the list
                shopItems.Add(new ShopItem(name, description, stock, cost));
                Console.WriteLine("Adding item to items list");
            }
            else
            {
                Console.WriteLine("Error: parts length != 4");
                Console.WriteLine($"Parts Length: {parts.Length}");
            }
        }

        Console.WriteLine("Shop has been created)");
        // Initialize the shop with 0 points since total points are not included in the file
        return new Shop(0, shopItems);
    }


    public void Save(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (ShopItem item in _shopItems)
            {
                writer.WriteLine(item.RenderSave());
            }
        }
    }

}