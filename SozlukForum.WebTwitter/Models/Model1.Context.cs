﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SozlukForum.WebTwitter.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SozlukEntitiesTest : DbContext
    {
        public SozlukEntitiesTest()
            : base("name=SozlukEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BlokBilgileri> BlokBilgileri { get; set; }
        public virtual DbSet<BloklananPaylasimlar> BloklananPaylasimlar { get; set; }
        public virtual DbSet<Etkilesimler> Etkilesimler { get; set; }
        public virtual DbSet<Kategoriler> Kategoriler { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<Paylasimlar> Paylasimlar { get; set; }
        public virtual DbSet<RaporBilgileri> RaporBilgileri { get; set; }
        public virtual DbSet<RaporlananPaylasimlar> RaporlananPaylasimlar { get; set; }
        public virtual DbSet<Resimler> Resimler { get; set; }
        public virtual DbSet<TakipEdenler> TakipEdenler { get; set; }
        public virtual DbSet<TakipEdilenBilgileri> TakipEdilenBilgileri { get; set; }
        public virtual DbSet<TakipEdilenler> TakipEdilenler { get; set; }
        public virtual DbSet<TakipEtmeBilgileri> TakipEtmeBilgileri { get; set; }
        public virtual DbSet<Yorumlar> Yorumlar { get; set; }
        public virtual DbSet<PaylasimMetinleri> PaylasimMetinleri { get; set; }
        public virtual DbSet<YorumMetinleri> YorumMetinleri { get; set; }
    }
}