using ProductivityTools.KsiegiWieczyste.Selenium;
using System;
using System.Xml.Schema;

namespace ProductivityTools.KsiegiWieczyste.App
{
    public class Application
    {
        Browser Browser = new Browser();

        public void OtworzKsiege(string wydzial, string numer, string cyfrakontrola)
        {
            this.Browser.WyszukajKsiege(wydzial, numer, cyfrakontrola);
        }

        public void ZaldujKsiegeDoBazy(string numer)
        {
            this.Browser.ZaladujPrzegladanieAktualnejTresci();
            this.Browser.PobierzDzialPierwszy(numer);
            this.Browser.ZaladujDzialDrugi();
            this.Browser.PobierzDetaleDzialuDrugiego(numer);
            this.Browser.ZaladujDzialCzwarty();
            this.Browser.PobierzDetaleDzialuCzwartego(numer);
        }
    }
}
