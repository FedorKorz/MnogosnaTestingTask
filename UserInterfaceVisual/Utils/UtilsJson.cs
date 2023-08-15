using Newtonsoft.Json;
using NUnit.Framework;

namespace UserInterfaceVisual.Utils;

public static class UtilsJson
{
    private static readonly string PathJson = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../")) +
                                              "Resources/testData.json";

    public static string ReadJsonFile(string key)
    {
        TestContext.WriteLine(PathJson);
        try
        {
            dynamic file = JsonConvert.DeserializeObject(File.ReadAllText(PathJson));
            return Convert.ToString(file?[$"{key}"]);
        }
        catch
        {
            return string.Empty;
        }
    }
}