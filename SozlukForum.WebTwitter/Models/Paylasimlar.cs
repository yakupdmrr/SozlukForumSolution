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
    
    public partial class Paylasimlar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paylasimlar()
        {
            this.BloklananPaylasimlar = new HashSet<BloklananPaylasimlar>();
            this.Etkilesimler = new HashSet<Etkilesimler>();
            this.PaylasimMetinleri = new HashSet<PaylasimMetinleri>();
            this.RaporlananPaylasimlar = new HashSet<RaporlananPaylasimlar>();
            this.Resimler = new HashSet<Resimler>();
        }
    
        public string PaylasimId { get; set; }
        public int KategoriId { get; set; }
        public int KullaniciId { get; set; }
        public int PaylasimTipi { get; set; }
        public string GirilmeZamani { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BloklananPaylasimlar> BloklananPaylasimlar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Etkilesimler> Etkilesimler { get; set; }
        public virtual Kategoriler Kategoriler { get; set; }
        public virtual Kullanicilar Kullanicilar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaylasimMetinleri> PaylasimMetinleri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaporlananPaylasimlar> RaporlananPaylasimlar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resimler> Resimler { get; set; }
    }
}
