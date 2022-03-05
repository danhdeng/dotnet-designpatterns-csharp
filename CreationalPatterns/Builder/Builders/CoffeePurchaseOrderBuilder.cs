using CreationalPatterns.Builder.Interfaces;
using CreationalPatterns.Builder.Models;

namespace CreationalPatterns.Builder.Builders;

public class CoffeePurchaseOrderBuilder : IBuildsPurchaseOrders
{
    private string _id;
    private string _companyName;
    private string _companyAddress;
    private DateTime _requestDate;
    private Supplier _supplier;
    private List<LineItem> _lineItems;

    public void SetId()
    {
        var date = DateTime.UtcNow.ToString("yyyy-MM-dd");
        _id = $"coffee_{date}";
    }

    public void SetCompany()
    {
        _companyName = "Riverrun Dry Goods";
    }
    public void SetAddress()
    {
        _companyAddress = "18 Riverrun Lane";
    }
    public void SetRequestDate()
    {
        _requestDate = DateTime.UtcNow;
    }
    public void SetSupplier()
    {
        _supplier = new Supplier
        {
            Name = "Riverrun Dry Goods",
            ContactName = "Dan",
            Email = "contact@danvansolution.com",
        };
    }
    public void SetItems()
    {
        var orderItems = new List<LineItem>() {
            new("bread flour", 4, 1.2m),
            new("salt", 2, 0.3m),
            new("yeast", 8, 0.75m),

        };
        _lineItems = orderItems;
    }
    public PurchaseOrder BuilPurchaseOrder()
    {
        SetId();
        SetRequestDate();
        SetAddress();
        SetCompany();
        SetItems();
        SetSupplier();

        return new PurchaseOrder
        {
            Id = _id,
            CreatedOn = DateTime.UtcNow,
            CompanyName = _companyName,
            CompanyAddress = _companyAddress,
            LineItems = _lineItems,
            Supplier = _supplier,
            RequestDate = _requestDate
        };

    }
    public static implicit operator PurchaseOrder(CoffeePurchaseOrderBuilder builder)
    {
        return builder.BuilPurchaseOrder();
    }

}