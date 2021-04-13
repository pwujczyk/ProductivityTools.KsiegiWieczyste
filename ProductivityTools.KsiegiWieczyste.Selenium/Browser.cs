using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using System.Threading;

namespace ProductivityTools.KsiegiWieczyste.Selenium
{
    public class Browser
    {
        IWebDriver Driver;

        public Browser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("test-type");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("no-sandbox");
            options.AddArgument("disable-infobars");
            //options.AddArgument("--headless"); //hide browser
            options.AddArgument("--start-maximized");
            //options.AddArgument("--window-size=1100,300");
           // options.AddUserProfilePreference("profile.default_content_setting_values.images", 2);

           // options.AddArgument(@"user-data-dir=C:\Users\pwujczyk\AppData\Local\Google\Chrome\User Data");
            this.Driver = new ChromeDriver(options);
            //Driver.Manage().Window.Size = new Size(1024, 968);
            
            //driver.Manage().Window.Size = new System.Drawing.Size(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width + 10, System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height + 10);

        }

        public void WyszukajKsiege(string wydzial, string numer, string cyfrakontrola)
        {
            Driver.Url = "https://ekw.ms.gov.pl/eukw_ogol/menu.do";

            Thread.Sleep(2000);
            var inputs = Driver.FindElements(By.TagName("a"));
            foreach (var input in inputs)
            {
                Console.WriteLine(input.GetAttribute("href"));
                if (input.GetAttribute("href") == "https://ekw.ms.gov.pl/eukw_ogol/KsiegiWieczyste")
                {
                    input.Click();
                    break;
                }
            }

            var kodWydzialu = Driver.FindElement(By.Id("kodWydzialuInput"));
            kodWydzialu.SendKeys(wydzial);
            Thread.Sleep(2000);

            var numerKsiegiWieczystej = Driver.FindElement(By.Id("numerKsiegiWieczystej"));
            numerKsiegiWieczystej.SendKeys(numer);
            Thread.Sleep(2000);

            var cyfraKontrolna = Driver.FindElement(By.Id("cyfraKontrolna"));
            cyfraKontrolna.SendKeys(cyfrakontrola);

            Thread.Sleep(2000);
            var wyszukaj = Driver.FindElement(By.Id("wyszukaj"));
            wyszukaj.Click();
        }
    }
}
