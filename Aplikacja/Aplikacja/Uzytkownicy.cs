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
    
    public partial class Uzytkownicy
    {
        public Uzytkownicy()
        {
            this.Diety = new HashSet<Diety>();
        }
    
        public int ID { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public Nullable<int> ID_Profilu { get; set; }
    
        public virtual Dane Dane { get; set; }
        public virtual ICollection<Diety> Diety { get; set; }
    }
}
