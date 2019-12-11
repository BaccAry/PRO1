using System;
using System.Collections.Generic;

namespace Pizzeria_v2.Models
{
    public partial class ZamowieniePizza
    {
        public int IdZamowieniePizza { get; set; }
        public int IdZamowienie { get; set; }
        public int IdPizza { get; set; }

        public virtual Pizza IdPizzaNavigation { get; set; }
        public virtual Zamowienie IdZamowienieNavigation { get; set; }
    }
}
