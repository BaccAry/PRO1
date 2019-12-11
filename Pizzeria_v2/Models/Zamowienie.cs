using System;
using System.Collections.Generic;

namespace Pizzeria_v2.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            ZamowieniePizza = new HashSet<ZamowieniePizza>();
        }

        public int IdZamowienie { get; set; }
        public int? IdUzytkownik { get; set; }
        public int? IdPromocja { get; set; }
        public int Ilosc { get; set; }
        public DateTime DataZamowienia { get; set; }

        public virtual Promocja IdPromocjaNavigation { get; set; }
        public virtual Uzytkownik IdUzytkownikNavigation { get; set; }
        public virtual ICollection<ZamowieniePizza> ZamowieniePizza { get; set; }
    }
}
