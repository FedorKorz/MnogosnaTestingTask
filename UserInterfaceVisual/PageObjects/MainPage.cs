using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using SkiaSharp;
using UserInterfaceVisual.Resources;

namespace UserInterfaceVisual.pageObjects;

public class MainPage : Form
{
    private readonly string _userInput = ExternalVarsStorage.UserInput;
    private readonly string _neededSearchResult = ExternalVarsStorage.NeededSearchResult;
    private readonly string _link = ExternalVarsStorage.Link;
    
    public MainPage() : base(By.XPath("//div[@class='header__logo']//a//*[name()='svg']"), "Main Page")
    {
    }

    private IComboBox Image =>
        ElementFactory.GetComboBox(By.XPath("//img[@alt='Матрас Аскона Фитнес Формула 160x200']"), "Image");

    private ITextBox SearchField =>
        ElementFactory.GetTextBox(By.XPath("//input[@class='js-search-input']"), "Search Field On Main Page");

    private ITextBox SearchFieldPopUp =>
        ElementFactory.GetTextBox(By.XPath("//input[@id='search-input']"), "Search Field Pop Up On Main Page");

    private ITextBox SearchResult =>
        ElementFactory.GetTextBox(By.XPath("//div[contains(@class, 'slinks__list--popular')]/a"),
            "First Search Result");

    private ITextBox SearchResultWithNeededText =>
        ElementFactory.GetTextBox(By.XPath($"//div[contains(text(),'{_neededSearchResult}')]"),
            "Result Топперы Аскона 160х200 hasn't appeared");


    public bool IsSearchFiledDisplayed()
    {
        return SearchField.State.WaitForDisplayed();
    }

    public void ClickSearchFiled()
    {
        SearchField.ClickAndWait();
    }

    public void SetTextOnSearchField()
    {
        SearchFieldPopUp.SendKeys(_userInput);
    }

    public bool AreSearchResultsDisplayed()
    {
        SearchResult.State.WaitForDisplayed();
        return SearchResult.State.IsDisplayed;
    }

    public bool AreSearchResultCorrect()
    {
        return SearchResultWithNeededText.State.WaitForDisplayed()
               &&
               SearchResultWithNeededText.Text.Contains(_neededSearchResult);
    }

    public bool GetLinkOfTheFirstSearchResult()
    {
        return SearchResult.GetAttribute("href").Length > 0;
    }

    public bool IsLinkIsCorrect()
    {
        return SearchResult.GetAttribute("href").Equals(_link);
    }

    public bool GetImageDifference()
    {
        var bitmap = SKBitmap.Decode("Resources/Матрас Аскона Фитнес Формула 160x200.jpg");
        var image = SKImage.FromBitmap(bitmap);
        return Image.Visual.GetDifference(image) < 1;
    }
}