using Org.BouncyCastle.Utilities.Net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipUygulamasi.Class.Parametreler
{
    public class Prm
    {

        #region Static Parametreler
        public static sbyte Hata;
        public static string BilgiMesajiAlani;
        public static string BelgelerimYolu = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString();
        public static string ResimAdi;
        public static string BarkodNo;
        public static string grd_UrunlerListesi;
        public static bool checkbox_Satista_Olanlar;
        public static bool checkbox_indirimde_olmayanlar;
        public static bool checkbox_odenen_veresiyeler;
        public static bool checkbox_eski_toptancilari_getir;
        public static bool checkbox_silinen_musteriler;
        public static bool checkbox_silinen_calisanlar;
        #endregion



        #region Ekleme / Güncelleme Parametreleri
        private int _hesapTuruID;
        private int _ToptanciID;
        private int _CalisanID;
        private int _faturaID;

        private string _ID;  // Ürün Id olarak kullanıyoruz.
        private string _urunAdi;
        private string _barkod_No;
        private string _aciklama;
        private string _resim;
        private Nullable<int> _kdv_Orani;
        private Nullable<int> _kar_Orani;
        private Nullable<int> _satis_Fiyati;
        private Nullable<int> _olcu_Birimi_ID;
        private string _olcu_Birimi;
        private bool _satista_Mi;
        private Nullable<int> _olcu_miktar;
        private int _KritikDurum;

        // İndirim parametreleri
        private string _indirim_ID;
        private DateTime _IndirimBaslangicTarihi;
        private DateTime _IndirimBitisTarihi;
        private Nullable<int> _indirimYuzde;
        private int _indirimliSatisFiyati;
        private int _indirimTabanFiyati;
        private bool _indirimde_mi;

        // Veresiye Bilgileri
        private int _veresiye_ID;
        private string _veresiyeIslemTarihi;
        private string _veresiyeParaTuru;
        private DateTime _veresiyeSonOdemeTarihi;
        private int _veresiyeToplamBorc;
        private string _veresiyeAciklama;
        private string _islemTuru;
        private int _veresiyeTahsilat;
        private int _veresiyeKalanBorc;
        private int _calisanYetkiID;


        // Toptancı Bilgileri
        private string _toptanciAdi;
        private string _toptanciAdresi;
        private string _toptanciAciklamasi;
        private string _toptanciCepTel;
        private string _toptantiIsTel;
        private string _toptanciFaxNo;


        //Siparis Güncelleme
        private int _urun_ID;
        private int _siparis_ID;
        private DateTime _siparisTarihi;
        private int _siparis_Adeti;
        private bool _siparis_Iptal;
        private string _siparis_Iptal_Aciklama;


        // Müşteriler
        private string _musteriFaxNo;
        private string _musteriVergiNo;
        private string _musteriVergiDairesi;
        private string _musteriNo;
        private string _musteriAdi;
        private string _musteriSoyadi;
        private string _musteriEmail;
        private string _musteriAdres;
        private string _musteriIstel;
        private string _musteriCepTel;
        private int _musteriGrubuID;
        private Nullable<int> _musteriID;


        // Çalışanlar
        private string _calisanNo;
        private string _calisanID;
        private string _calisanAdi;
        private string _calisanSoyadi;
        private string _calisanKadi;
        private string _calisanSifre;
        private string _calisanFoto;
        private string _calisanAdres;
        private string  _calisanIP;
        private string _calisanTel;
        private string _calisanEmail;
        private string _calisanTC;


        //StokAdet
        private int _stok_ID;
        private int _stok_Eldeki_Miktar;
       
        private int _stok_Toplam_Giris;
        private int _stok_Toplam_Cikis;

        //Urun Alis
        private DateTime _urun_alis_Tarihi;
        private int _urun_alis_Fiyat;

        //Fatura 
        private string _faturaNo;

        //Urun İade;
        private string _iade_Sebei;
        private int _iade_Adet;
        private DateTime _iade_Tarihi;

        

        // Gelen değerlerin hepsinin baş harfini büyük yaptık. (CultureInfo ile)
        public string UrunAdi { get => _urunAdi; set => _urunAdi = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value); }
        public string Barkod_No { get => _barkod_No; set => _barkod_No = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value); }
        public string Aciklama { get => _aciklama; set => _aciklama = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value); }
        public Nullable<int> KDV_Orani { get => _kdv_Orani; set => _kdv_Orani = value; }
        public Nullable<int> Kar_Orani { get => _kar_Orani; set => _kar_Orani = value; }
        public Nullable<int> Satis_Fiyati { get => _satis_Fiyati; set => _satis_Fiyati = value; }
        public Nullable<int> Olcu_Birimi_ID { get => _olcu_Birimi_ID; set => _olcu_Birimi_ID = value; }
        public bool Satista_Mi { get => _satista_Mi; set => _satista_Mi = value; }
        public string Resim { get => _resim; set => _resim = value; }
        public Nullable<int> Olcu_Miktar { get => _olcu_miktar; set => _olcu_miktar = value; }
        public string Olcu_Birimi { get => _olcu_Birimi; set => _olcu_Birimi = value; }
        public string ID { get => _ID; set => _ID = value; }
        public string Indirim_ID { get => _indirim_ID; set => _indirim_ID = value; }
        public DateTime IndirimBaslangicTarihi { get => _IndirimBaslangicTarihi; set => _IndirimBaslangicTarihi = value; }
        public DateTime IndirimBitisTarihi { get => _IndirimBitisTarihi; set => _IndirimBitisTarihi = value; }
        public int IndirimliSatisFiyati { get => _indirimliSatisFiyati; set => _indirimliSatisFiyati = value; }
        public int IndirimTabanFiyati { get => _indirimTabanFiyati; set => _indirimTabanFiyati = value; }
        public int? IndirimYuzde { get => _indirimYuzde; set => _indirimYuzde = value; }
        public bool Indirimde_mi { get => _indirimde_mi; set => _indirimde_mi = value; }

        #endregion

        public int  ToptanciID { get => _ToptanciID; set => _ToptanciID = value; }
        public int  CalisanID { get => _CalisanID; set => _CalisanID = value; }
        public int UrunID { get => _urun_ID; set => _urun_ID = value; }
        public int SiparisAdet { get => _siparis_Adeti; set => _siparis_Adeti = value; }
        public DateTime SiparisTarihi { get => _siparisTarihi; set => _siparisTarihi = value; }

        public bool SiparisIptal { get => _siparis_Iptal; set => _siparis_Iptal = value; }
        public string SiparisIptalAciklama { get => _siparis_Iptal_Aciklama; set => _siparis_Iptal_Aciklama = value; }
       
        
        public int Stok_ID { get => _stok_ID; set => _stok_ID = value; }
        public int Stok_EldekiMiktar { get => _stok_Eldeki_Miktar; set => _stok_Eldeki_Miktar = value; }
        public int KritikDurum { get => _KritikDurum; set => _KritikDurum = value; }
        public int Stok_Toplam_Cikis { get => _stok_Toplam_Cikis; set => _stok_Toplam_Cikis = value; }
        public int Stok_Toplam_Giris { get => _stok_Toplam_Giris; set => _stok_Toplam_Giris = value; }
        public string MusteriNo { get => _musteriNo; set => _musteriNo = value; }
        public string MusteriAdi { get => _musteriAdi; set => _musteriAdi = value; }
        public string MusteriSoyadi { get => _musteriSoyadi; set => _musteriSoyadi = value; }
        public string MusteriEmail { get => _musteriEmail; set => _musteriEmail = value; }
        public string MusteriAdres { get => _musteriAdres; set => _musteriAdres = value; }
        public string MusteriIstel { get => _musteriIstel; set => _musteriIstel = value; }
        public string MusteriCepTel { get => _musteriCepTel; set => _musteriCepTel = value; }
        public int MusteriGrubuID { get => _musteriGrubuID; set => _musteriGrubuID = value; }
        public Nullable<int> MusteriID { get => _musteriID; set => _musteriID = value; }
        public string VeresiyeIslemTarihi { get => _veresiyeIslemTarihi; set => _veresiyeIslemTarihi = value; }
        public int HesapTuruID { get => _hesapTuruID; set => _hesapTuruID = value; }
        public string VeresiyeParaTuru { get => _veresiyeParaTuru; set => _veresiyeParaTuru = value; }
        public DateTime VeresiyeSonOdemeTarihi { get => _veresiyeSonOdemeTarihi; set => _veresiyeSonOdemeTarihi = value; }
        public int VeresiyeToplamBorc { get => _veresiyeToplamBorc; set => _veresiyeToplamBorc = value; }
        public string VeresiyeAciklama { get => _veresiyeAciklama; set => _veresiyeAciklama = value; }
        public string IslemTuru { get => _islemTuru; set => _islemTuru = value; }
        public int VeresiyeTahsilat { get => _veresiyeTahsilat; set => _veresiyeTahsilat = value; }
        public int VeresiyeKalanBorc { get => _veresiyeKalanBorc; set => _veresiyeKalanBorc = value; }
        public int FaturaID { get => _faturaID; set => _faturaID = value; }
        public string ToptanciAdi { get => _toptanciAdi; set => _toptanciAdi = value; }
        public string ToptanciAdresi { get => _toptanciAdresi; set => _toptanciAdresi = value; }
        public string ToptanciAciklamasi { get => _toptanciAciklamasi; set => _toptanciAciklamasi = value; }
        public string ToptanciCepTel { get => _toptanciCepTel; set => _toptanciCepTel = value; }
        public string ToptantiIsTel { get => _toptantiIsTel; set => _toptantiIsTel = value; }
        public string ToptanciFaxNo { get => _toptanciFaxNo; set => _toptanciFaxNo = value; }
        public string MusteriVergiNo { get => _musteriVergiNo; set => _musteriVergiNo = value; }
        public string MusteriVergiDairesi { get => _musteriVergiDairesi; set => _musteriVergiDairesi = value; }
        public string MusteriFaxNo { get => _musteriFaxNo; set => _musteriFaxNo = value; }
        public string CalisanAdi { get => _calisanAdi; set => _calisanAdi = value; }
        public string CalisanSoyadi { get => _calisanSoyadi; set => _calisanSoyadi = value; }
        public string CalisanKadi { get => _calisanKadi; set => _calisanKadi = value; }
        public string CalisanSifre { get => _calisanSifre; set => _calisanSifre = value; }
        public string CalisanFoto { get => _calisanFoto; set => _calisanFoto = value; }
        public string CalisanAdres { get => _calisanAdres; set => _calisanAdres = value; }
        public string CalisanTel { get => _calisanTel; set => _calisanTel = value; }
        public string CalisanEmail { get => _calisanEmail; set => _calisanEmail = value; }
        public string CalisanTC { get => _calisanTC; set => _calisanTC = value; }
        public string CalisanIP { get => _calisanIP; set => _calisanIP = value; }
        public int Veresiye_ID { get => _veresiye_ID; set => _veresiye_ID = value; }
        public int CalisanYetkiID { get => _calisanYetkiID; set => _calisanYetkiID = value; }
        public string CalisanNo { get => _calisanNo; set => _calisanNo = value; }
        public string CalisanID1 { get => _calisanID; set => _calisanID = value; }
        public int UrunAlisFiyat { get => _urun_alis_Fiyat; set => _urun_alis_Fiyat = value; }
        public DateTime UrunAlisTarih { get => _urun_alis_Tarihi; set => _urun_alis_Tarihi = value; }
        public String FaturaNo { get => _faturaNo; set => _faturaNo = value; }
        public String IadeSebei { get => _iade_Sebei; set => _iade_Sebei = value; }
        public int IadeAdeti { get => _iade_Adet; set => _iade_Adet = value; }
        public DateTime IadeTarihi { get => _iade_Tarihi; set => _iade_Tarihi = value; }
    }
}
