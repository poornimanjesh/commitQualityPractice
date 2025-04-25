using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace commitQualityPractice
{

    public class TestLogin

    {
        [SetUp]
        public void setUp()
        {

        }
        [Test]
        public async Task Test1()
        {
            //playwright initializing
            using var PWDriver = await Playwright.CreateAsync();
            // Browser initializing
            await using var browser = await PWDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            //page initializing
            var page = await browser.NewPageAsync();
            //navigating to the page
            await page.GotoAsync(url: "http://eaapp.somee.com/");

            await page.ClickAsync(selector: "text=Login");

            // screenshot

            await page.ScreenshotAsync(new PageScreenshotOptions
            {

                Path = "loginpage.jpg"

            });
        }
    }
}
