//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sinav.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sinavlar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sinavlar()
        {
            this.GirilenSinav = new HashSet<GirilenSinav>();
            this.Sorular = new HashSet<Sorular>();
        }
    
        public int sinavId { get; set; }
        public string sinavAd { get; set; }
        public System.DateTime sinavtarihi { get; set; }
        public string sinavKodu { get; set; }

    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GirilenSinav> GirilenSinav { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sorular> Sorular { get; set; }
    }
}
