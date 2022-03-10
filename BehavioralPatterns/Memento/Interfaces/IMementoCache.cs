using BehavioralPatterns.Memento;

namespace BehavioralPatterns.Memento.Interfaces;

public interface IMementoCache
{
    void SafeKeepState(Memento memeto);

    Memento GetPreviousStateAndUpdateMemory();

    Memento[] PeekMemory();
}
