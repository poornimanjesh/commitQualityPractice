using commitQualityPractice_Playwright.Pages;
using Microsoft.Playwright;
LoginPage lp;

namespace commitQualityPractice_Playwright.Tests
{
    public class TestLoginAndLogOut : TestBase
    {
        [SetUp]
        public async Task SetUp()
        {
            // Navigating to the page  
            await page.GotoAsync(url: "http://eaapp.somee.com/");
        }

        [Test]
        public async Task clickLoginLink()
        {
            // Updated to use WaitForURLAsync instead of the obsolete WaitForNavigationAsync
            var navigationTask = page.WaitForURLAsync("**/Login");
            LoginPage lp = new LoginPage(page);
            await lp.clickLoginlink();
            await navigationTask;
        }

        [Test]
        public async Task Test_EmployeeDetailsVisible()
        {
            LoginPage lp = new LoginPage(page);
            lp.clickLoginlink();
            lp.FillUserNameTextField("admin");
            lp.FillPasswordTextField("password");
            lp.ClickLogInButton();
            lp.IsEmployeeDetailsTextVisible();
        }

        [Test]
        public async Task Test_ClickEmployeelistLink()
        {
            LoginPage lp = new LoginPage(page);
            await lp.clickLoginlink();
            await lp.FillUserNameTextField("admin");
            await lp.FillPasswordTextField("password");
            await lp.ClickLogInButton();

            // Corrected the declaration and initialization of waitResponse
            Task<IRequest> waitResponse = page.WaitForRequestAsync(urlOrPredicate: "**/Employee");
            await lp.ClickEmployeeListLink();
            var getResponse = await waitResponse; // Fixed the incorrect reference to WaitForResponseAsync
        }
    }
}
