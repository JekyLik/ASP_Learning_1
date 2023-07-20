namespace ASP_Learning_1.Models;

public class Product
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Product(string title, string description, double price, int quantity)
    {
        Title = title;
        Description = description;
        Price = price;
        Quantity = quantity;
    }
}