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
    
    public partial class TakipEdilenler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TakipEdilenler()
        {
            this.TakipEdilenBilgileri = new HashSet<TakipEdilenBilgileri>();
        }
    
        public int TakipEdilenId { get; set; }
        public int KullaniciId { get; set; }
    
        public virtual Kullanicilar Kullanicilar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TakipEdilenBilgileri> TakipEdilenBilgileri { get; set; }
    }
}
