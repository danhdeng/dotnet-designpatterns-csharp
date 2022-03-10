namespace BehavioralPatterns.Memento;

/// <summary>
/// Provide a "Snapshot" that can be used by a Doughnut Shopping cart
/// to restore its state
/// </summary>
public class CartMemento : Memento {
    private readonly DateTime _date;
    private readonly string _state;

    public CartMemento(string state) {
        _date = DateTime.UtcNow;
        _state = state;
    }

    public override string GetState() => _state;

    public override DateTime GetSnapshotDate() => _date;
}