using ProductivityTools.KsiegiWieczyste.Selenium;
using System;
using System.Xml.Schema;

namespace ProductivityTools.KsiegiWieczyste.App
{
    public class Class1
    {
        Browser Browser = new Browser();

        public void OtworzKsiege(string wydzial, string numer, string cyfrakontrola)
        {
            this.Browser.WyszukajKsiege(wydzial, numer, cyfrakontrola);
        }
    }
}
