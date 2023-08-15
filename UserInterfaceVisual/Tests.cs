using NUnit.Framework;
using UserInterfaceVisual.pageObjects;

namespace UserInterfaceVisual;

[TestFixture]
public class Tests : BaseTest
{
    [Test]
    public void checkTheTestResults()
    {
        var mainPage = new MainPage();
        mainPage.State.WaitForDisplayed();

        Assert.Multiple(() =>
        {
            Assert.That(mainPage.State.IsDisplayed, Is.True, "Главная страница не загрузилась");
            Assert.That(mainPage.IsSearchFiledDisplayed, Is.True, "Поле поиска не найдено");
        });

        mainPage.ClickSearchFiled();
        mainPage.SetTextOnSearchField();

        Assert.Multiple(() =>
        {
            Assert.That(mainPage.AreSearchResultsDisplayed, Is.True, "Результат поиска не отобразился");
            Assert.That(mainPage.AreSearchResultCorrect(), Is.True,
                "Значения первого результата поиска и TestData не совпадают");
            Assert.That(mainPage.GetLinkOfTheFirstSearchResult(), Is.True,
                "Отсутствует атрибут href у элемента списка");
            Assert.That(mainPage.IsLinkIsCorrect(), Is.True, "Ссылка у элемента списка некорректна");
            Assert.That(mainPage.GetImageDifference(), Is.True,
                "Изображения из поиска и Матрас Аскона Формула 160х200 не совпадают");
        });
    }
}