using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sinav.ViewModel
{
    public class SinavModel
    {
        internal int sinavOgrSayisi;

        public int sinavId { get; set; }
        public string sinavAd { get; set; }
        public System.DateTime sinavtarihi { get; set; }
        public string sinavKodu { get; set; }

    }
}