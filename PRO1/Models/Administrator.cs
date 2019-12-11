using System;
using System.Collections.Generic;

namespace PRO1.Models
{
    public partial class Administrator
    {
        public int IdAdministrator { get; set; }
        public int IdUzytkownik { get; set; }

        public Uzytkownik IdUzytkownikNavigation { get; set; }
    }
}
