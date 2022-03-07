using BehavioralPatterns.ChainOfResponsibility.Models;

namespace BehavioralPatterns.ChainOfResponsibility.Interfaces;

public interface IHandler {
    KombuchaSale? Handle(KombuchaSale request);
    IHandler SetNext(IHandler handler);
}
