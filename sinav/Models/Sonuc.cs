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
    
    public partial class Sonuc
    {
        public int SonucSinavId { get; set; }
        public int SonucOgrId { get; set; }
        public int SinavPuani { get; set; }
        public string BasariDurumu { get; set; }
    
        public virtual Ogrenci Ogrenci { get; set; }
    }
}
