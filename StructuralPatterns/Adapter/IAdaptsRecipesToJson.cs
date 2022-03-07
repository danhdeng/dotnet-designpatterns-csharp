namespace StructualPatterns.Adapter;
public interface IAdaptsRecipesToJson {
    public Task<string> GetRecipeAsJson(string recipeName);
}