using System;
using System.Collections.Generic;

namespace Pizzeria_v2.Models
{
    public partial class Administrator
    {
        public int IdAdministrator { get; set; }
        public int IdUzytkownik { get; set; }

        public virtual Uzytkownik IdUzytkownikNavigation { get; set; }
    }
}
