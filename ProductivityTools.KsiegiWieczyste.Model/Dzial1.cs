using System;

namespace ProductivityTools.KsiegiWieczyste.Model
{
    public class Dzial1
    {
        public int Dzial1Id { get; set; }
        public string NumerKsiegi { get; set; }
        public string NumerBudynku { get; set; }
        public string NumerLokalu { get; set; }
        public string IdentyfikatorLokalu { get; set; }
        public string PrzeznaczenieLokalu { get; set; }
        public string OpisLokalu { get; set; }
        public string OpisPomieszczenPrzynaleznych { get; set; }
        public int Kondygnacja { get; set; }
        public double PowierzchniaRazemZPrzynaleznymi { get; set; }
    }
}
