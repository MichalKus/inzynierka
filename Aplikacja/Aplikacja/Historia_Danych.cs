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
    
    public partial class Historia_Danych
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public Nullable<int> Wiek { get; set; }
        public Nullable<double> Waga { get; set; }
        public Nullable<double> Wzrost { get; set; }
        public Nullable<double> Obwod_Pasa { get; set; }
        public Nullable<double> Obwod_Bioder { get; set; }
        public int ID_Profilu { get; set; }
        public Nullable<double> Zapotrzebowanie { get; set; }
    
        public virtual Dane Dane { get; set; }
    }
}
