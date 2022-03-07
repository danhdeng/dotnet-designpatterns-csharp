using Newtonsoft.Json;
using RealisticDependencies.API;
using System.Xml;

namespace StructualPatterns.Adapter;

public class RecipeFinder : IAdaptsRecipesToJson {
    private readonly RecipesApi _recipeApi;

    public RecipeFinder(RecipesApi recipeApi) {
        _recipeApi = recipeApi;
    }

    public async Task<string> GetRecipeAsJson(string recipeName) {
        var recipeXML=await _recipeApi.MakeHttpRequestForRecipe(recipeName);
        var doc = new XmlDocument();
        doc.LoadXml(recipeXML);
        var jsonResult=JsonConvert.SerializeObject(doc);
        return jsonResult;
    }
}