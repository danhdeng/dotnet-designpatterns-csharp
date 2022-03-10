using BehavioralPatterns.Memento.Interfaces;

namespace BehavioralPatterns.Memento;

public class CartMemory : IMementoCache
{
    private readonly Stack<Memento> _memory = new Stack<Memento>();
    public void SafeKeepState(Memento memeto)
    {
        _memory.Push(memeto);
    }

    public Memento GetPreviousStateAndUpdateMemory()
    {
        //pop the last memory out
        _memory.TryPop(out Memento memeto);
        return memeto;
    }

    public Memento[] PeekMemory()
    {
        var memoryCopy = new Memento[_memory.Count];
        _memory.CopyTo(memoryCopy, 0);
        return memoryCopy;
    }
}