using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlaywrightTests;


public class Introduction
{

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        //Playwright 
        using var playwright=await Playwright.CreateAsync();// starts downloading playwright things from the internet


        //open /lunch a browser (By defaut its Headess)

        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });


        //Page
        var page=await browser.NewPageAsync();


        await page.GotoAsync("http://www.eaapp.somee.com");
       // await page.ClickAsync("text=Login");
        await page.GetByText("Login").ClickAsync();
        /*await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "EAApp.jpg"
        });*/
    

        //  FillAsync()   ise like sendKeys() in Selenium
        await page.GetByText("UserName").FillAsync("admin");
        await page.GetByText("Password").FillAsync("password");
        await page.GetByText("Log in").ClickAsync();

        var isExist = await page.Locator("text='Employee Details'").IsVisibleAsync();
     
   
                   Assert.IsTrue(isExist);

    }







}