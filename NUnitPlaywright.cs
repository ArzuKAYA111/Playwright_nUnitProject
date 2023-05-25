using Microsoft.Playwright.NUnit;
//using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlaywrightTests;


public class NUnitPlaywright  : PageTest          //This allows to inherit      Microsoft.Playwright.NUnit class       (   : >>  means  extent)
{

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
       /*  
       Toplu coomant out yaptigim kismi yapmaya artik gerek yok     Onceden olusturdugum "page" yerine simdi "Page" kullanacagim

        *  //Playwright 
            using var playwright=await Playwright.CreateAsync();// starts downloading playwright things from the internet


          //open /lunch a browser (By defaut its Headess)

           await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
           {
            Headless = false,
            });


        //Page
        var page=await browser.NewPageAsync();*/


        await Page.GotoAsync("http://www.eaapp.somee.com");
       // await page.ClickAsync("text=Login");
        await Page.GetByText("Login").ClickAsync();
      
        //  FillAsync()   ise like sendKeys() in Selenium
        await Page.GetByText("UserName").FillAsync("admin");
        await Page.GetByText("Password").FillAsync("password");
        await Page.GetByText("Log in").ClickAsync();




        /* 
              var isExist = await Page.Locator("text='Employee Details'").IsVisibleAsync();
                 Assert.IsTrue(isExist);

       Insted of Asser we can use  Expect() method      It comes from ILocatorAssertions
*/

        await Expect(Page.Locator("text='Employee Details'")).ToBeVisibleAsync();


    }







}