using System;
using System.Collections.Generic;

namespace PRO1.Models
{
    public partial class Zamowienie
    {
        public int IdZamowienie { get; set; }
        public int? IdUzytkownik { get; set; }
        public int? IdPizza { get; set; }
        public int? IdPromocja { get; set; }
        public int Ilosc { get; set; }
        public DateTime DataZamowienia { get; set; }

        public Pizza IdPizzaNavigation { get; set; }
        public Promocja IdPromocjaNavigation { get; set; }
        public Uzytkownik IdUzytkownikNavigation { get; set; }
    }
}
