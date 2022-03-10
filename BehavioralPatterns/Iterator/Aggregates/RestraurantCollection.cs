using BehavioralPatterns.Iterator.Iterators;
using BehavioralPatterns.Iterator.Models;

namespace BehavioralPatterns.Iterator.Aggregates;

public class RestraurantCollection : Aggregate {
    private List<Restraurant> _restraurants = new();
    private bool _isPopularitySorted;
    private bool _isRatingSorted;

    public override System.Collections.IEnumerator GetEnumerator()
    {
        return new RestraurantIterator(this);
    }

    public List<Restraurant> GetAll() => _restraurants;

    public void AddItem(Restraurant restraunt) { 
        _restraurants.Add(restraunt);
        if (_isPopularitySorted) {
            SortByPopularityDescending();
        }
        if (_isRatingSorted) {
            SortByRatingDescending();
        }
    }

    public void SortByRatingDescending()
    {
        _isRatingSorted = true;
        _restraurants =_restraurants.OrderByDescending(rest=>rest.Rating).ToList();
    }

    public void SortByPopularityDescending()
    {
        _isPopularitySorted = true;
        _restraurants =_restraurants.OrderByDescending(rest=>rest.VisitCount).ToList();
    }
}