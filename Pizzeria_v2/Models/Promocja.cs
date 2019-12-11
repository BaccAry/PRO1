using System;
using System.Collections.Generic;

namespace Pizzeria_v2.Models
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

        public virtual Pizza IdPizzaNavigation { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
