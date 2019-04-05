using IntelliTect.TestTools.Selenate;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace myWebApp.Tests
{
    public class SmokeTests : IDisposable
    {
        public SmokeTests(ITestOutputHelper output)
        {
            Output = output;
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            Output.WriteLine("Launching Chrome...");
            //string chromeDriverLocation = Path.Combine(".");
            string chromeDriverLocation = "C:\\app";
            Output.WriteLine($"Search location for Chromedriver: {chromeDriverLocation}");
            IWebDriver driver = new ChromeDriver(chromeDriverLocation);
            IWebDriver driver2 = new ChromeDriver(chromeDriverLocation, options);
            //Browser = new Browser(new ChromeDriver(Path.Combine("."), options));
            //Browser = new Browser(new ChromeDriver("C:\\app", options));
            Browser.Driver.Navigate().GoToUrl("http://localhost:5000");
        }

        [Fact]
        public void VerifySiteLaunches()
        {
            Output.WriteLine("Running test VerifySiteLaunches...");
            Assert.Contains("Hello, world!", Browser.Driver.PageSource);
            Output.WriteLine("Test passes!");
        }

        public void Dispose()
        {
            Browser.Driver.Quit();
        }

        private Browser Browser { get; }
        private ITestOutputHelper Output { get; }
    }
}
