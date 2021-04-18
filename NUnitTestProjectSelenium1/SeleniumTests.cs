using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

public class SeleniumTests
{
    IWebDriver driver;   // create instance of object


    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();   // executed before every test
    }


    [Test]
    public void DirBgGoPassIframeWindowZodiacCheck()
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver.Navigate().GoToUrl("https://dir.bg/");
        driver.Manage().Window.Maximize();
        // Find the iframe you need an access it by its "id"
        driver.SwitchTo().Frame("gdpr-consent-notice");
        // Click on Accept All button
        driver.FindElement(By.XPath("//*[@id=\"save\"]/span[1]/div/span")).Click();
        //Go back to main page
        driver.SwitchTo().ParentFrame();

        driver.FindElement(By.XPath("//*[@id=\"main\"]/header/div[1]/div/nav/div/a")).Click();
        driver.FindElement(By.LinkText("Зодиак")).Click();
        driver.FindElement(By.LinkText("Рак")).Click();

        driver.FindElement(By.CssSelector(".zodiaName")).Click();
        Assert.That(driver.FindElement(By.XPath("//*[@id=\"rak\"]/h1")).Text, Is.EqualTo("Рак 22 Юни - 23 Юли"));
    }
    [Test]
    public void Test_NakovComTitle()
    {

        driver.Navigate().GoToUrl("https://nakov.com");
        var pageTitle = driver.Title;   // В C# можем да декларираме така!


        Assert.That(pageTitle.Contains("Svetlin Nakov"));
        Assert.That(driver.Title.Contains("Official Web Site and Blog"));
    }
    [Test]
    public void Test_SoftUniHeadlineNews()
    {
        driver.Navigate().GoToUrl("https://softuni.bg/");
        driver.FindElement(By.XPath("/html/body/div[2]/div/header/div/div[2]/div[1]/a")).Click();


        // F12 в сайта, намирам заглавието и десен бутон-> copy-> copy XPath Full!
        var headLineTitle = driver.FindElement(By.XPath(
            "/html/body/footer/div/ul/li[3]/div/ul/li[1]/a"));

        var itemText = headLineTitle.Text;

        Assert.That(itemText != null && itemText != "");
        System.Console.WriteLine(itemText);
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
