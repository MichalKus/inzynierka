﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BazaDanychEntities : DbContext
    {
        public BazaDanychEntities()
            : base("name=BazaDanychEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Uzytkownicy> Uzytkownicy { get; set; }
        public virtual DbSet<Dane> Dane { get; set; }
        public virtual DbSet<Historia_Danych> Historia_Danych { get; set; }
        public virtual DbSet<Kategorie> Kategorie { get; set; }
        public virtual DbSet<Produkty> Produkty { get; set; }
        public virtual DbSet<Diety> Diety { get; set; }
        public virtual DbSet<Suplementy> Suplementy { get; set; }
        public virtual DbSet<Jedzenie> Jedzenie { get; set; }
        public virtual DbSet<Posilki> Posilki { get; set; }
    }
}
