using System;
using System.Collections.Generic;

namespace Pizzeria_v2.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int IdSkladnik { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
