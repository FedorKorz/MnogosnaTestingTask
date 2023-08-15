using Aquality.Selenium.Browsers;
using NUnit.Framework;
using UserInterfaceVisual.Resources;

namespace UserInterfaceVisual;

public class BaseTest
{
    private dynamic? _browser;

    [SetUp]
    public void Setup()
    {
        var url = ExternalVarsStorage.Url;
        
        _browser = AqualityServices.Browser;
        _browser.Maximize();
        _browser.GoTo(url);
        _browser.WaitForPageToLoad();
    }

    [TearDown]
    public void Teardown()
    {
        _browser?.Quit();
    }
}