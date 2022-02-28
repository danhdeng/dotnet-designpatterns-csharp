
namespace RealisticDependencies.API;
interface IRecipesApi
{
    public interface IRecipesApi { 
        /// <summary>
        /// Returns XML Response of a Recipe
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        Task<string> MakeHttpRequestForRecipe(string recipe);
    }
}
