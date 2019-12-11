using System;
using System.Collections.Generic;

namespace PRO1.Models
{
    public partial class Promocja
    {
        public Promocja()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdPromocja { get; set; }
        public string Nazwa { get; set; }
        public int IdPizza { get; set; }
        public int Cena { get; set; }

        public Pizza IdPizzaNavigation { get; set; }
        public ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
