using System;
using System.Collections.Generic;

namespace PRO1.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int IdSkladnik { get; set; }
        public string Nazwa { get; set; }

        public ICollection<Pizza> Pizza { get; set; }
    }
}
