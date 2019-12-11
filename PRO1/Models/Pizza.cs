using System;
using System.Collections.Generic;

namespace PRO1.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            Promocja = new HashSet<Promocja>();
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdPizza { get; set; }
        public string Nazwa { get; set; }
        public int IdSkladnik { get; set; }
        public int Cena { get; set; }
        public int IdRozmiar { get; set; }

        public Rozmiar IdRozmiarNavigation { get; set; }
        public Skladnik IdSkladnikNavigation { get; set; }
        public ICollection<Promocja> Promocja { get; set; }
        public ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
