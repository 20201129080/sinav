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
    
    public partial class Sorular
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sorular()
        {
            this.Secenekler = new HashSet<Secenekler>();
        }
    
        public int SoruId { get; set; }
        public int SinavSoruId { get; set; }
        public string SoruMetni { get; set; }
        public string DogruSecenek { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Secenekler> Secenekler { get; set; }
        public virtual Sinavlar Sinavlar { get; set; }
    }
}