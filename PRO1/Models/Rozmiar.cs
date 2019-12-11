using System;
using System.Collections.Generic;

namespace PRO1.Models
{
    public partial class Rozmiar
    {
        public Rozmiar()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int IdRozmiar { get; set; }
        public string Nazwa { get; set; }

        public ICollection<Pizza> Pizza { get; set; }
    }
}
