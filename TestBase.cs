using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace commitQualityPractice
{

    public class TestBase
    {
        public IPage page; // Field to hold the IPage instance
        public IBrowser browser; // Field to hold the browser instance
        public IPlaywright playwright; // Field to hold the Playwright instance

        [SetUp]
        public async Task SetUp()
        {
            playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var context = await browser.NewContextAsync();
            page = await context.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            if (browser != null)
            {
                await browser.CloseAsync();
            }
            if (playwright != null)
            {
                playwright.Dispose();
            }
        }

        [Test]
        public async Task Test1()
        {
            // Navigating to the page
            await page.GotoAsync(url: "http://eaapp.somee.com/");

            await page.ClickAsync(selector: "text=Login");

            // Screenshot
            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "loginpage.jpg"
            });
        }
    }
}
