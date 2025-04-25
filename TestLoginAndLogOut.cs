using Microsoft.Playwright;

namespace commitQualityPractice
{

    public class TestLoginAndLogOut :TestBase
    {
        [SetUp]
        public async Task SetUp()
        {
            // Navigating to the page  
            await page.GotoAsync(url: "http://eaapp.somee.com/");

        }


        [Test]
        public async Task Test_logInButtonClick()
        {
           

            await page.ClickAsync(selector: "text=Login");

            // Screenshot
            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "loginpage.jpg"
            });
        }

        [Test]
        public async Task Test_EmployeeDetailsVisible()
        {
           
            await page.ClickAsync(selector: "text=Login");
            await page.FillAsync(selector: "#UserName", value: "admin");
            await page.FillAsync(selector: "#Password", value: "password");
            await page.ClickAsync(selector: "text=Log in");

            var isExists = await page.Locator(selector: "text='Employee Details'").IsVisibleAsync();
            Assert.That(isExists, Is.True, "Login failed"); // Updated to use Assert.That with Is.True  
        }

        
    }
}
