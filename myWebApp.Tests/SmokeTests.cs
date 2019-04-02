using IntelliTect.TestTools.Selenate;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using Xunit;

namespace myWebApp.Tests
{
    public class SmokeTests : IDisposable
    {
        public SmokeTests()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            Browser = new Browser(new ChromeDriver(Path.Combine("."), options));
            Browser.Driver.Navigate().GoToUrl("http://localhost:5000");
        }

        [Fact]
        public void VerifySiteLaunches()
        {
            Assert.Contains("Hello, world!", Browser.Driver.PageSource);
        }

        public void Dispose()
        {
            Browser.Driver.Quit();
        }

        private Browser Browser { get; }
    }
}
