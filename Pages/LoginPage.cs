using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace commitQualityPractice_Playwright.Pages
{
    public class LoginPage
    {
        private static IPage _page;
        public LoginPage(IPage page) => _page = page;
        public ILocator _Loginlink=> _page.Locator(selector: "text=Login");
        public ILocator _UserNameTextField => _page.Locator(selector: "#UserName");
        public ILocator _PasswordTextField => _page.Locator(selector: "text=Log in");
        public ILocator _LogInButton => _page.Locator(selector: "input", new PageLocatorOptions { HasTextString = "Log in" });
        public ILocator _EmployeeDetailsText => _page.Locator(selector: "text='Employee Details'");

       

      
      
       public async Task clickLoginlink() => await _Loginlink.ClickAsync();
       public async Task FillUserNameTextField(string userName) => await _UserNameTextField.FillAsync(userName);
       public async Task FillPasswordTextField(string password) => await _PasswordTextField.FillAsync(password);
       public async Task ClickLogInButton() => await _LogInButton.ClickAsync();
       public async Task<bool> IsEmployeeDetailsTextVisible() => await _EmployeeDetailsText.IsVisibleAsync();
        

    }
}
