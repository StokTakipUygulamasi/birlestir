using StokTakipUygulamasi.Class.Parametreler;
using StokTakipUygulamasi.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Org.BouncyCastle.Asn1.Cms;
using MySqlX.XDevAPI;

namespace StokTakipUygulamasi.Guncellemeler
{
    /// <summary>
    /// VeresiyeBorcOdeme.xaml etkileşim mantığı
    /// </summary>
    public partial class VeresiyeBorcOdeme : Window
    {
        public TimeSpan MyTime { get; set; }
        DataGrid grid;
        Prm veri = new Prm();
        public VeresiyeBorcOdeme(DataGrid gelen_grid, int veresiye_ID)
        {
            InitializeComponent();
            InitializeComponent();
            this.grid = gelen_grid;
            veri.Veresiye_ID = veresiye_ID;
            string[] veresyeGuncellemeGelenler = Veresiyeler.veresiyeGuncelleCek(veresiye_ID);
            txtMusteriAdiSoyadi.Text = veresyeGuncellemeGelenler[0];
            txtToplamBorc.Text = veresyeGuncellemeGelenler[1];
            MyTime = DateTime.Now.TimeOfDay;
            DataContext = this;
            Genel.SaatDakikaCombobox(cmbSaat, cmbDakika);
            cmb_IslemTuru.Text = "Nakit";

            txtBilgiPenceresi.Text = $"Bu sayfadan {txtMusteriAdiSoyadi} isimli müşteriye ilişkin borç ödemesi yapabilirsiniz. [ Yanında * olanlar zorunludur. ]";
        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {
            Bonus.PopupShow(popup_bilgi);
        }

        private void txtOdenenTutar_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) // Harf girilmesini engelliyoruz.
            {
                e.Handled = true;
            }
        }

        private void btn_Ode_Click(object sender, RoutedEventArgs e)
        {
            string musteriKalanrBorcBul = $@"(select Borc from veresiye_detay where Veresiye_ID = '{veri.Veresiye_ID}' order by ID DESC limit 1)";
            int musteriKalanBorcCek = Genel.tekilVeriCekmeInt(musteriKalanrBorcBul,"Borc");
            string musteriIDBul = $@"(select Musteri_ID from veresiye where Id='{veri.Veresiye_ID}')";
            int musteriID = Genel.tekilVeriCekmeInt(musteriIDBul,"Musteri_ID");
            veri.VeresiyeAciklama = txtAciklama.Text;
            veri.CalisanID = 1;
            int kalanBorc;
            if (txtOdenenTutar.Text != "")
            {
                kalanBorc = musteriKalanBorcCek - Convert.ToInt32(txtOdenenTutar.Text);
                veri.VeresiyeTahsilat = Convert.ToInt32(txtOdenenTutar.Text);
            }
            else
            {
                kalanBorc = musteriKalanBorcCek;
                veri.VeresiyeTahsilat = 0;
            }
            
            veri.VeresiyeKalanBorc = kalanBorc;
            veri.IslemTuru = cmb_IslemTuru.Text;
            

            string yil,ay,gun,saat,dakika,saniye, birlesmisZaman;
            yil = dateTarih.SelectedDate.GetValueOrDefault().Year.ToString();
            ay = dateTarih.SelectedDate.GetValueOrDefault().Month.ToString();
            gun = dateTarih.SelectedDate.GetValueOrDefault().Day.ToString();
            saat = cmbSaat.Text;
            dakika = cmbDakika.Text;

            DateTime zaman = DateTime.Now;
            saniye = zaman.Second.ToString();

            birlesmisZaman = yil+"-"+ay+"-" + gun + " " + saat + ":" + dakika + ":" + saniye;
            veri.VeresiyeIslemTarihi = birlesmisZaman;

            if (Convert.ToInt32(txtOdenenTutar.Text)>musteriKalanBorcCek)
            {
                Prm.Hata = 1;
                Prm.BilgiMesajiAlani = "Ödenen tutar mevcut borçtan fazla olamaz!";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
            }
            else
            {
                if (Veresiyeler.veresiyeBorcOde(veri) && Veresiyeler.veresiyeBorcGuncelle(veri.Veresiye_ID, veri.VeresiyeKalanBorc))
                {
                    Prm.Hata = 0;
                    Prm.BilgiMesajiAlani = "Borç ödeme işlemi başarılı";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
                    string sorgu_VeresiyeDoldur = "select ver.ID as 'ID', Concat(mus.Musteri_Adi,' ',mus.Musteri_Soyadi) as Musteri_AdSoyad, musbil.Cep_Tel, mus.E_mail, musbil.Adres, ver.Toplam_Bakiye, ver.Para_Turu ,ver.Son_Odeme_Tarihi from musteriler mus left join musteri_bilgileri musbil on mus.ID = musbil.Musteri_ID left join veresiye ver on ver.Musteri_ID = mus.ID where ver.Toplam_Bakiye>0";
                    Genel.GridiDoldurGenel(grid, sorgu_VeresiyeDoldur);
                    this.Close();
                }
                else
                {
                    Prm.Hata = 1;
                    Prm.BilgiMesajiAlani = "Borç ödeme işlemi sırasında bir sorun oldu";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
                }
            }



           


        }
    }
}
