namespace BehavioralPatterns.Iterator.Models;

public record Restraurant
{
    public Restraurant(string name, int rating, int visitCount) {
        Name = name;
        Rating = rating;
        VisitCount = visitCount;
    }

    public string Name { get; private set; }
    public int Rating { get; private set; }
    public int VisitCount { get; private set; }
}
