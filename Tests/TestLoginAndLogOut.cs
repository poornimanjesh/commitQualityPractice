using commitQualityPractice_Playwright.Pages;
using Microsoft.Playwright;
LoginPage lp;

namespace commitQualityPractice_Playwright.Tests
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
        public async Task Test_EmployeeDetailsVisible()
        {

           LoginPage lp = new LoginPage(page);
            lp.clickLoginlink();
            lp.FillUserNameTextField("admin");
            lp.FillPasswordTextField("password");
            lp.ClickLogInButton();
            lp.IsEmployeeDetailsTextVisible();
        }

        
    }
}
