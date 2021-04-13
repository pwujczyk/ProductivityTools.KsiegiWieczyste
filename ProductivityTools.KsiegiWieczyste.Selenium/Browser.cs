using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProductivityTools.KsiegiWieczyste.Model;
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



        public void ZaladujPrzegladanieAktualnejTresci()
        {
            Thread.Sleep(5000);
            var przegladanieAktualnejTresci = Driver.FindElement(By.Id("przyciskWydrukZwykly"));
            przegladanieAktualnejTresci.Click();
        }

        public void PobierzDzialPierwszy(string numer)
        {
            Dzial1 dzial1 = new Dzial1();
            dzial1.NumerKsiegi = numer;
            var trs = Driver.FindElements(By.TagName("TR"));
            foreach (var tr in trs)
            {
                var tds = tr.FindElements(By.TagName("td"));

                // Console.WriteLine($"tds:{i} == {tds[i].Text}");
                if (tds[0].Text.StartsWith("Ulica"))
                {
                    dzial1.NumerBudynku = tds[4].Text;
                    dzial1.NumerLokalu = tds[5].Text;
                }

                if (tds[0].Text.StartsWith("Identyfikator lokalu"))
                {
                    dzial1.IdentyfikatorLokalu = tds[1].Text;
                }

                if (tds[0].Text.StartsWith("Przeznaczenie lokalu"))
                {
                    dzial1.PrzeznaczenieLokalu = tds[1].Text;
                }

                if (tds[0].Text.StartsWith("Opis lokalu"))
                {
                    dzial1.OpisLokalu = tds[1].Text;
                }

                if (tds[0].Text.StartsWith("Opis pomieszcze"))
                {
                    dzial1.OpisPomieszczenPrzynaleznych = tds[1].Text;
                }


                if (tds[0].Text.StartsWith("Kondygnacja"))
                {
                    int kondygancja = -1000;
                    int.TryParse(tds[1].Text, out kondygancja);
                    dzial1.Kondygnacja = kondygancja;
                }

                if (tds[0].Text.StartsWith("Pole powierzchni"))
                {
                    string s = tds[1].Text;
                    s = s.Replace("M2", "").Trim();
                    float powierzchnia = 0;
                    float.TryParse(s, out powierzchnia);
                    dzial1.PowierzchniaRazemZPrzynaleznymi = powierzchnia;
                }

            }

            //context.Dzial1.Add(dzial1);
            //context.SaveChanges();
        }

        public void PobierzDetaleDzialuDrugiego(string numer)
        {

            var trs = Driver.FindElements(By.TagName("TR"));
            foreach (var tr in trs)
            {
                var tds = tr.FindElements(By.TagName("td"));

                // Console.WriteLine($"tds:{i} == {tds[i].Text}");
                if (tds[0].Text.StartsWith("Osoba fizyczna"))
                {
                    Dzial2 dzial2 = new Dzial2();
                    dzial2.NumerKsiegi = numer;

                    string txt = tds[1].Text;
                    var parts = txt.Split(',');
                    dzial2.Nazwa = parts[0];
                    dzial2.ImieOjca = parts[1];
                    dzial2.ImieMatki = parts[2];
                    dzial2.Pesel = parts[3];

                    //context.Dzial2.Add(dzial2);
                    //context.SaveChanges();
                }
            }
        }

        public void PobierzDetaleDzialuCzwartego(string numer)
        {
            Dzial4 dzial4 = null; ;
            var trs = Driver.FindElements(By.TagName("TR"));
            foreach (var tr in trs)
            {
                var tds = tr.FindElements(By.TagName("td"));

                // Console.WriteLine($"tds:{i} == {tds[i].Text}");
                if (tds[0].Text.StartsWith("Rodzaj hipoteki"))
                {
                    dzial4 = new Dzial4();
                    dzial4.NumerKsiegi = numer;

                    dzial4.RodzajHipoteki = tds[1].Text;
                }

                if (tds[0].Text.StartsWith("Suma"))
                {
                    string kwota = tds[1].Text;
                    int koniecKwoty = kwota.IndexOf("(");
                    string samawartosc = kwota.Substring(0, koniecKwoty);

                    decimal wartosc;
                    decimal.TryParse(samawartosc, out wartosc);
                    dzial4.Kwota = wartosc;
                }

                if (tds[0].Text.StartsWith("Wierzytelność"))
                {
                    dzial4.Kredyt = tds[3].Text;
                }

                if (tds[0].Text.StartsWith("Inna osoba prawna"))
                {
                    dzial4.Wierzyciel = tds[2].Text;
                }
            }

            if (dzial4 != null)
            {
                //context.Dzial4.Add(dzial4);
                //context.SaveChanges();
            }
        }



        public  void ZaladujDzialDrugi()
        {
            ZaladujDzial("Dział II");
        }

        public void ZaladujDzialCzwarty()
        {
            ZaladujDzial("Dział IV");
        }

        private void ZaladujDzial(string dzial)
        {
            Thread.Sleep(2000);
            var inputs = Driver.FindElements(By.TagName("input"));
            foreach (var input in inputs)
            {
                Console.WriteLine(input.GetAttribute("value"));
                if (input.GetAttribute("value") == dzial)
                {
                    input.Click();
                    break;
                }
            }
        }
    }
}
