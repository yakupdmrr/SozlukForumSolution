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
    
    public partial class BloklananPaylasimlar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BloklananPaylasimlar()
        {
            this.BlokBilgileri = new HashSet<BlokBilgileri>();
        }
    
        public int BlokPaylasimId { get; set; }
        public string PaylasimId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlokBilgileri> BlokBilgileri { get; set; }
        public virtual Paylasimlar Paylasimlar { get; set; }
    }
}
