using sinav.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using sinav.ViewModel;

namespace sinav.Controllers
{
    public class ServisController : ApiController
    {
        Db1Entities1 db = new Db1Entities1();
        KontrolModel sonuc = new KontrolModel();
        private int sinavId;

        #region Ogrenci
        [HttpGet]
        [Route("api/ogrenciliste")]
        public List<OgrenciModel> OgrenciListe()
        {
            List<OgrenciModel> liste = db.Ogrenci.Select(x => new OgrenciModel()
            {
                ogrId = x.ogrId,
                ogrNo = x.ogrNo,
                ogrAdSoyad = x.ogrAdSoyad,
                ogrTel = x.ogrTel,
                
            }).ToList();
            return liste;

        }
        [HttpGet]
        [Route("api/ogrencibyid/{ogrId}")]
        public OgrenciModel OgrenciById(int ogrId)
        {
            OgrenciModel kayit = db.Ogrenci.Where(s => s.ogrId == ogrId).Select(x => new
           OgrenciModel()
            {
                ogrId = x.ogrId,
                ogrNo = x.ogrNo,
                ogrAdSoyad = x.ogrAdSoyad,
                ogrTel = x.ogrTel,
            }).SingleOrDefault();
            return kayit;
        }
        [HttpPost]
        [Route("api/ogrenciekle")]
        public KontrolModel OgrenciEkle(OgrenciModel model)
        {
            if (db.Ogrenci.Count(s => s.ogrNo == model.ogrNo) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Öğrenci Numarası Kayıtlıdır!";
                return sonuc;
            }
            Ogrenci yeni = new Ogrenci();
            yeni.ogrNo = model.ogrNo;
            yeni.ogrAdSoyad = model.ogrAdSoyad;
            yeni.ogrTel = model.ogrTel;
            db.Ogrenci.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Öğrenci Eklendi";
            return sonuc;
        }
        [HttpPut]
        [Route("api/ogrenciduzenle")]
        public KontrolModel OgrenciDuzenle(OgrenciModel model)
        {
            Ogrenci kayit = db.Ogrenci.Where(s => s.ogrId == model.ogrId).SingleOrDefaul
t();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.ogrNo = model.ogrNo;
            kayit.ogrAdSoyad = model.ogrAdSoyad;
            kayit.ogrTel = model.ogrTel;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Öğrenci Düzenlendi";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/ogrencisil/{ogrId}")]
        public KontrolModel OgrenciSil(int ogrId)
        {
            Ogrenci kayit = db.Ogrenci.Where(s => s.ogrId == ogrId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
                if (db.GirilenSinav.Count(s => s.GOgrId == ogrId) > 0)
                {
                    sonuc.islem = false;
                    sonuc.mesaj = "Öğrenci Üzerinde Kayıtlı Sinav Olduğundan Öğrenci Silinemez
                   !";
     return sonuc;
                }
                db.Ogrenci.Remove(kayit);
                db.SaveChanges();
                sonuc.islem = true;
                sonuc.mesaj = "Öğrenci Silindi";
                return sonuc;
            }
        }
        #endregion
        #region Sinavlar
        [HttpGet]
        [Route("api/sinavliste")]
        public List<SinavModel> SinavListe()
        {
            List<SinavModel> liste = db.Sinavlar.Select(x => new SinavModel()
            {
                sinavId = x.sinavId,
                sinavAd = x.sinavAd,
                sinavtarihi = x.sinavtarihi,
                sinavKodu = x.sinavKodu,
                sinavOgrSayisi = x.GirilenSinav.Count()

            }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/sinavbyid/{sinavId}")]
        public SinavModel sinavById(int sinavId)
        {
            SinavModel kayit = db.Sinavlar.Where(s => s.sinavId == sinavId).Select(x => new SinavModel
           ()
          {
                sinavId = x.sinavId,
                sinavAd = x.sinavAd,
                sinavtarihi = x.sinavtarihi,
                sinavKodu = x.sinavKodu,
                sinavOgrSayisi = x.GirilenSinav.Count()

            }).SingleOrDefault();
            return kayit;
        }
        [HttpPost]
        [Route("api/sinavekle")]
        public KontrolModel SinavEkle(SinavModel model)
        {
            if (db.Sinavlar.Count(s => s.sinavKodu == model.sinavKodu) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Sınav Kodu Kayıtlıdır!";
                return sonuc;
            }
            Sinavlar yeni = new Sinavlar();
            yeni.sinavKodu = model.sinavKodu;
            yeni.sinavAd = model.sinavAd;
            yeni.sinavtarihi = model.sinavtarihi;
            db.Sinavlar.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Sınav Eklendi";
            return sonuc;
        }

        [HttpPut]
        [Route("api/sinavduzenle")]
        public KontrolModel SinavDuzenle(SinavModel model)
        {
            Sinavlar kayit = db.Sinavlar.Where(s => s.sinavId == model.sinavId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.sinavKodu = model.sinavKodu;
            kayit.sinavAd = model.sinavAd;
            kayit.sinavtarihi = model.sinavtarihi;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Sinav Düzenlendi";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/sinavsil/{sinavId}")]
        public KontrolModel SinavSil(int sinavId)
        {
            Sinavlar kayit = db.Sinavlar.Where(s => s.sinavId == sinavId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            if (db.GirilenSinav.Count(s => s.GSinavId == sinavId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Sinava Kayıtlı Öğrenci Olduğu İçin Sinav Silinemez!";
                return sonuc;
            }
            db.Sinavlar.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Sinav Silindi";
            return sonuc;
        }
        #endregion
        #region GirilenSinav
        [HttpGet]
        [Route("api/ogrencisinavliste/{ogrId}")]
        public List<GirilenSinavModel> OgrenciSinavListe(int ogrId)
        {
            List<GirilenSinavModel> liste = db.GirilenSinav.Where(s => s.GOgrId == ogrId).Select(x
           => new GirilenSinavModel()
           {
               GirilenSinavId = x.GirilenSinavId,
               GSinavId = x.GSinavId,
               GOgrId = x.GOgrId,
               VerilenCevaplar = x.VerilenCevaplar, 
            }).ToList();
            foreach (var girilenSinav in liste)
            {
                girilenSinav.ogrBilgi = OgrenciById(girilenSinav.GOgrId);
                girilenSinav.sinavBilgi = SinavById(girilenSinav.GSinavId);
            }
            return liste;
        }
        [HttpGet]
        [Route("api/sinavogrenciliste/{sinavId}")]
        public List<GirilenSinavModel> SinavOgrenciListe(int sinavId)
        {
               List<GirilenSinavModel> liste = db.GirilenSinav.Where(s => s.GSinavId == sinavId).Select
           (x => new GirilenSinavModel()
           {
               GirilenSinavId = x.GirilenSinavId,
               GSinavId = x.GSinavId,
               GOgrId = x.GOgrId,
               VerilenCevaplar = x.VerilenCevaplar,

           }).ToList();
            foreach (var girilenSinav in liste)
            {
                girilenSinav.ogrBilgi = OgrenciById(girilenSinav.GOgrId);
                girilenSinav.sinavBilgi = SinavById(girilenSinav.GSinavId);
            }
            return liste;
        }
    }

    #endregion
        #region Sonuc
    [HttpGet]
    [Route("api/basariliste")]
    public List<BasariModel> BasariListe()
    {
           List<BasariModel> liste = db.Sonuc.Select(x => new BasariModel()
        {
            SonucSinavId = x.SonucSinavId,
            SonucOgrId = x.SonucOgrId,
            SinavPuani = x.SnavPuani,
            BasariDurumu = x.BasariDurumu,
        }).ToList();
        return liste;
    
    }
    #endregion
        #region Sorular
    [HttpGet]
    [Route("api/sorularliste")]
    public List<SorularModel> SorularListe()
    {
        List<SorularModel> liste = db.Sorular.Select(x => new SorularModel()
        {
            SoruId =x.SoruId,
            SinavSoruId = x.SinavSoruId,
            SoruMetni = x.SoruMetni,
            DogruSecenek = x.DogruSecenek,
        }).ToList();
        return liste;

        [HttpPost]
        [Route("api/soruekle")]
        public KontrolModel SoruEkle(SorularModel model)
        {
            if (db.Sorular.Count(s => SoruId == model.SoruId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "İlgili Soru Kayıtlıdır!";
                return sonuc;
            }
            Sorular yeni = new Sorular();
            yeni.SoruId = model.SoruId;
            yeni.SinavSoruId= model.SinavSoruId;
            yeni.SoruMetni = model.SoruMetni;
            yeni.DogruSecenek = model.DogruSecenek;
            db.Sorular.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Soru Eklendi";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/sorusil/{SoruId}")]
        public KontrolModel SoruSil(int SoruId)
        {
            Sorular kayit = db.Sorular.Where(s => s.SoruId == SoruId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Soru Bulunamadı!";
                return sonuc;
            }
            db.Sorular.Remove(sorular);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Soru Silindi";
            return sonuc;
        }
        #endregion
        #region Secenekler
        [HttpGet]
        [Route("api/secenekliste")]
        public List <SeceneklerModel> SecenekListe()
       {
        List<SeceneklerModel> liste = db.Secenekler.Select(x => new SeceneklerModel()
        {
            SecenekId = x.SecenekId,
            SecenekSoruId = x.SecenekSoruId,
            SecenekMetni = x.SecenekMetni,
        }).ToList();
        return liste;
        }
        #endregion