public class ShopItem
{
    // Attributes
    string _name;
    string _description;
    int _stock;
    int _cost;

    // Constructor
    public ShopItem( string name, string description, int stock, int cost)
    {
        // Following written by ChatGPT
        _name = name;
        _description = description;
        _stock = stock;
        _cost = cost;
    }

    // Methods
    public string RenderDisplay()
    {
        return $"| ({_stock}) {_cost}p | {_name}: {_description}";
    }

    public void AddStock(int newStock)
    {
        _stock += newStock;
    }

    public int BuyItem(int playerPoints)
    {
        if (_stock < 1)
        {
            Console.WriteLine("This item is out of stock. ");
            return playerPoints;
        }
        if (playerPoints <= _cost)
        {
            Console.WriteLine("You do not have enough points to buy this. ");
            return playerPoints;
        }

        // Will only run if player has enough points and
        // item is in stock
        _stock -= 1;
        Console.WriteLine($"Successfully bought 1 {_name} for {_cost}p! ");
        return playerPoints - _cost;

    }

    public string RenderSave()
    {
        return $"{_name}||{_description}||{_stock}||{_cost}";
    }
}