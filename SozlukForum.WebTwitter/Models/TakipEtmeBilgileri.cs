//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class TakipEtmeBilgileri
    {
        public int TakipEtBilgiId { get; set; }
        public int TakipEtId { get; set; }
        public int KullaniciId { get; set; }
    
        public virtual TakipEdenler TakipEdenler { get; set; }
    }
}