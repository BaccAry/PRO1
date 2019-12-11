using System;
using System.Collections.Generic;

namespace Pizzeria_v2.Models
{
    public partial class Rozmiar
    {
        public Rozmiar()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int IdRozmiar { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
