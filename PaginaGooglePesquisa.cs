using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
[TestFixture]
public class BuscasGoogle
{
    public IWebDriver driver;
    public IDictionary<string, object> vars { get; private set; }
    public IJavaScriptExecutor js;
    [SetUp]
    public void SetUp()
    {
        //Acesso pelo Firefox

        /*var options = new FirefoxOptions() {
                 BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe"
        };

             driver = new FirefoxDriver(options);*/
     
        //Acesso pelo Chrome

            var options = new ChromeOptions()
        {
            BinaryLocation = @"C:\Program Files\Google\Chrome\Application\chrome.exe"
        };

        driver = new ChromeDriver(options);

        js = (IJavaScriptExecutor)driver;
        vars = new Dictionary<string, object>();
    }
    [TearDown]
    protected void TearDown()
    {
        driver.Quit();
    }
  
    [Test]
    public void EstouComSorte()
    {
        driver.Navigate().GoToUrl("https://www.google.com/");
        driver.Manage().Window.Size = new System.Drawing.Size(1296, 1000);
        driver.FindElement(By.Name("q")).Click();
        driver.FindElement(By.Name("q")).SendKeys("concert technologies");
        Thread.Sleep(3000);
        driver.FindElement(By.Name("btnI")).Click();
        Assert.AreEqual(driver.Title, "Concert Technologies | Tecnologia e Inovação para o seu negócio | Home");
    }


    [Test]
    public void BotaoGmail()
    {
        driver.Navigate().GoToUrl("https://www.google.com/");
        driver.Manage().Window.Size = new System.Drawing.Size(1296, 1000);
        driver.FindElement(By.LinkText("Gmail")).Click();
        Assert.That(driver.Title, Is.EqualTo("Gmail: email gratuito, privado e seguro | Google Workspace"));
        driver.FindElement(By.LinkText("Inicie sessão")).Click();
        Thread.Sleep(3000);
        Assert.That(driver.FindElement(By.CssSelector("#headingText > span")).Text, Is.EqualTo("Fazer login"));
    }


    [Test]
    public void GoogleImagens()
    {
        driver.Navigate().GoToUrl("https://www.google.com/");
        driver.Manage().Window.Size = new System.Drawing.Size(1296, 1000);
        driver.FindElement(By.LinkText("Imagens")).Click();
        Assert.That(driver.Title, Is.EqualTo("Imagens do Google"));
    }


    [Test]
    public void PesquisaGoogle()
    {
        driver.Navigate().GoToUrl("https://www.google.com/");
        driver.Manage().Window.Size = new System.Drawing.Size(1296, 1000);
        driver.FindElement(By.Name("q")).Click();
        driver.FindElement(By.Name("q")).SendKeys("concert technologies");
        Thread.Sleep(2000);
        driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
        Thread.Sleep(5000);
        driver.FindElement(By.XPath("//h3[contains(.,\'Concert Technologies | Tecnologia e Inovação para o seu ...\')]")).Click();
        Assert.AreEqual(driver.Title, "Concert Technologies | Tecnologia e Inovação para o seu negócio | Home");
    }


    public string WaitForWindow(int timeout)
    {
        try
        {
            Thread.Sleep(timeout);
        }
        catch (Exception e)
        {
            Console.WriteLine("{0} Exception caught.", e);
        }
        var whNow = ((IReadOnlyCollection<object>)driver.WindowHandles).ToList();
        var whThen = ((IReadOnlyCollection<object>)vars["WindowHandles"]).ToList();
        if (whNow.Count > whThen.Count)
        {
            return whNow.Except(whThen).First().ToString();
        }
        else
        {
            return whNow.First().ToString();
        }
    }
    [Test]
    public void PesquisaImagens()
    {
       
            driver.Navigate().GoToUrl("https://www.google.com/");
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 1000);
            driver.FindElement(By.LinkText("Imagens")).Click();
            driver.FindElement(By.Name("q")).Click();
            driver.FindElement(By.Name("q")).SendKeys("concert technologies");
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//a/div/img")).Click();
            {
                var element = driver.FindElement(By.CssSelector(".isv-r:nth-child(1) .fxgdke"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            js.ExecuteScript("window.scrollTo(0,145)");
            vars["WindowHandles"] = driver.WindowHandles;
            driver.FindElement(By.CssSelector(".tvh9oe:nth-child(2) .KSvtLc")).Click();
            vars["win1131"] = WaitForWindow(2000);
            vars["root"] = driver.CurrentWindowHandle;
            driver.SwitchTo().Window(vars["win1131"].ToString());
            Assert.That(driver.Title, Is.EqualTo("Concert Technologies | Tecnologia e Inovação para o seu negócio | Home"));
            driver.SwitchTo().Window(vars["root"].ToString());
                  
    }
}