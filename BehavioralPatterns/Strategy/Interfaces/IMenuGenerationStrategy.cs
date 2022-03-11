using BehavioralPatterns.Strategy.Models;

namespace BehavioralPatterns.Strategy.Interfaces;
/// <summary>
/// A strategy for generating a menu, Classes that implement
/// this behavior must produce an instance of a Menu Object.
/// </summary>
public interface IMenuGenatrationStrategy {
    Task<Menu> GenerateMenu();
}