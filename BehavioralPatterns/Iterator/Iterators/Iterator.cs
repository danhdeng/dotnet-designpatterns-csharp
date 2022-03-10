using System.Collections;

namespace BehavioralPatterns.Iterator.Iterators;
/// <summary>
/// extend System.Collections IEnumerator,
/// which defines all the methods we need to 
/// iterate
/// </summary>
public abstract class Iterator : IEnumerator {
    object IEnumerator.Current => Current();

    //return the key of the current element
    public abstract int Key();

    //Return the current element
    public abstract object Current();
    public abstract bool MoveNext();
    public abstract void Reset();

} 
