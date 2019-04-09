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
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");
            Output.WriteLine("Launching Chrome...");
            Browser = new Browser(new ChromeDriver(Path.Combine("."), options));
            //Browser.Driver.Navigate().GoToUrl("http://www.google.com");
            Browser.Driver.Navigate().GoToUrl("http://localhost:5000");
        }

        [Fact]
        public void VerifySiteLaunches()
        {
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
