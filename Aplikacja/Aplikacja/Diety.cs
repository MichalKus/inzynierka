//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aplikacja
{
    using System;
    using System.Collections.Generic;
    
    public partial class Diety
    {
        public int Id { get; set; }
        public Nullable<int> Zapotrzebowanie { get; set; }
        public Nullable<double> Bialko { get; set; }
        public Nullable<double> Weglowodany { get; set; }
        public Nullable<double> Tluszcz { get; set; }
        public Nullable<double> Kalorycznosc { get; set; }
        public Nullable<int> Ilosc_Posilkow { get; set; }
        public Nullable<System.DateTime> Data_Rozpoczecia { get; set; }
        public Nullable<System.DateTime> Data_Zakonczenia { get; set; }
        public int ID_Uzytkownika { get; set; }
    
        public virtual Uzytkownicy Uzytkownicy { get; set; }
    }
}
