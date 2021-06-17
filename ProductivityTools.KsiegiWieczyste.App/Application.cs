using ProductivityTools.KsiegiWieczyste.ApiClient;
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
            var ksiega = new Model.Ksiega();
            this.Browser.ZaladujPrzegladanieAktualnejTresci();
            this.Browser.PobierzDzialPierwszy(numer, ksiega);
            this.Browser.ZaladujDzialDrugi();
            this.Browser.PobierzDetaleDzialuDrugiego(numer, ksiega);
            this.Browser.ZaladujDzialCzwarty();
            this.Browser.PobierzDetaleDzialuCzwartego(numer, ksiega);
        }

        public void ZaldujKsiegeDoBaz2y(string numer)
        {
            var ksiega = new Model.Ksiega();
            ksiega.Dzial1 = new Model.Dzial1();
            ksiega.Dzial1.IdentyfikatorLokalu = "98";
            ksiega.Dzial1.Kondygnacja = 3;
            ksiega.Dzial1.NumerBudynku = "3b";
            ksiega.Dzial1.NumerKsiegi = "fdsa";
        }

        private void SendToDatabase(Model.Ksiega ksiega)
        {
            Client client = new Client();
            client.Sent(ksiega);
        }
    }
}
