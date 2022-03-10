using BehavioralPatterns.Iterator.Aggregates;

namespace BehavioralPatterns.Iterator.Iterators;

public class RestraurantIterator : Iterator {
    
    private readonly RestraurantCollection _collection;

    private int _currentPosition = 0;
    public RestraurantIterator(RestraurantCollection collection) {
        _collection = collection;
    }

    public override object Current() => _collection.GetAll()[_currentPosition];

    public override int Key() => _currentPosition;

    public override bool MoveNext()
    {
        var nextPosition=_currentPosition + 1;
        if (nextPosition >= 0 && nextPosition < _collection.GetAll().Count) {
            _currentPosition = nextPosition;
            return true;
        }
        else { 
            return false;
        }
    }

    public override void Reset() => _currentPosition = 0;

}