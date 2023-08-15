

using UserInterfaceVisual.Utils;

namespace UserInterfaceVisual.Resources;

public static class ExternalVarsStorage
{
    public static readonly string UserInput = UtilsJson.ReadJsonFile("userInput");
    public static readonly string Url = UtilsJson.ReadJsonFile("url");
    public static readonly string NeededSearchResult = UtilsJson.ReadJsonFile("neededSearchResult"); 
    public static readonly string Link = UtilsJson.ReadJsonFile("link");
}