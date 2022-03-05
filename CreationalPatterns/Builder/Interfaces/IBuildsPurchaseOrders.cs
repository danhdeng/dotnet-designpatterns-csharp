using CreationalPatterns.Builder.Models;

namespace CreationalPatterns.Builder.Interfaces;

public interface IBuildsPurchaseOrders {
    void SetId();
    void SetCompany();
    void SetAddress();
    void SetRequestDate();
    void SetSupplier();
    void SetItems();
    PurchaseOrder BuilPurchaseOrder();


}