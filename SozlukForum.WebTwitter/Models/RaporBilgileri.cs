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
    
    public partial class RaporBilgileri
    {
        public int RaporBilgiId { get; set; }
        public int KullaniciId { get; set; }
        public int RaporId { get; set; }
    
        public virtual Kullanicilar Kullanicilar { get; set; }
        public virtual RaporlananPaylasimlar RaporlananPaylasimlar { get; set; }
    }
}
