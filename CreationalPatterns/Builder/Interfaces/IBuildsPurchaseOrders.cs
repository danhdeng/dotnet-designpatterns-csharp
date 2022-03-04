using CreationalPatterns.Builder.Models;

namespace CreationalPatterns.Builder.Interfaces;

public interface IBuilderPurchaseOrders {
    void SetId();
    void SetCompany();
    void SetAddress();
    void SetRequestDate();
    void SetSupplier();
    void SetItems();
    PurchaseOrder BuilPurchaseOrder();


}