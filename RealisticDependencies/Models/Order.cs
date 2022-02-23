namespace RealisticDependencies.Models;

public class Order { 
    public DateTime TimeOfPurchase { get; set; }
    public decimal TotalPrice { get; set; }
    public List<string> ListItems { get; set; }
}