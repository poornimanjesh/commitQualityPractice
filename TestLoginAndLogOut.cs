using Microsoft.Playwright;

namespace commitQualityPractice
{

    public class TestLoginAndLogOut :TestBase
    {
        //public IPage page; // Declare the 'page' variable  
        //public IBrowser Browser; // Correctly declare the 'Browser' variable as IBrowser

        [SetUp]
        public async Task SetUp()
        {
            // Ensure 'Browser' is initialized before calling 'NewPageAsync'
            //if (Browser == null)
            //{
            //    var playwright = await Playwright.CreateAsync();
            //    Browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            //}

           // page = await Browser.NewPageAsync(); // Initialize the 'page' variable  
        }

        [Test]
        public async Task Test_LoginAndLogOut()
        {
            // Navigating to the page  
            await page.GotoAsync(url: "http://eaapp.somee.com/");

            await page.ClickAsync(selector: "text=Login");

            // Screenshot  
            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "loginpage.jpg"
            });

            await page.FillAsync(selector: "#UserName", value: "admin");
            await page.FillAsync(selector: "#Password", value: "password");
            await page.ClickAsync(selector: "text=Log in");

            var isExists = await page.Locator(selector: "text='Employee Details'").IsVisibleAsync();
            Assert.That(isExists, Is.True, "Login failed"); // Updated to use Assert.That with Is.True  
        }

        
    }
}
