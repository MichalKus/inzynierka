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
    
    public partial class Posilek
    {
        public Posilek()
        {
            this.Spis_Posilkow = new HashSet<Spis_Posilkow>();
        }
    
        public int Id { get; set; }
        public string Potrawa { get; set; }
        public Nullable<double> Kalorycznosc { get; set; }
        public Nullable<double> Bialko { get; set; }
        public Nullable<double> Weglowodany { get; set; }
        public Nullable<double> Tluszcz { get; set; }
    
        public virtual ICollection<Spis_Posilkow> Spis_Posilkow { get; set; }
    }
}