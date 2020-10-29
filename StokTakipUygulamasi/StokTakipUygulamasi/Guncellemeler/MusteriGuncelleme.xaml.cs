using StokTakipUygulamasi.Class;
using StokTakipUygulamasi.Class.Parametreler;
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

namespace StokTakipUygulamasi.Guncellemeler
{
    /// <summary>
    /// MusteriGuncelleme.xaml etkileşim mantığı
    /// </summary>
    public partial class MusteriGuncelleme : Window
    {
        Prm veri = new Prm();
        DataGrid grid;
        public MusteriGuncelleme(DataGrid gelen_grid, string musteriID)
        {
            InitializeComponent();
            this.grid = gelen_grid;

            string musteriGrubuSorgusu = "Select * from musteri_grubu";
            Genel.ComboBoxVeriCekme(cmb_MusteriGrubu,musteriGrubuSorgusu,"Musteri_Grubu");

            veri.MusteriID = Convert.ToInt32(musteriID);
            List<string> liste = Musteriler.musteriTumBilgileriCek(Convert.ToInt32(musteriID));
            txtMusteriAdi.Text = liste[1];
            txtMusteriSoyadi.Text = liste[2];
            txtMusteriVergiDairesi.Text = liste[3];
            txtMusteriVergiNumarasi.Text = liste[4];
            txtMusteriEmail.Text = liste[5];
            cmb_MusteriGrubu.SelectedItem = liste[6];
            txtIsTel.Text = liste[7];
            txtCepTel.Text = liste[8];
            txtMusteriAdres.Text = liste[9];
            txtFaxNo.Text = liste[10];
            veri.MusteriGrubuID = Convert.ToInt32(liste[11]);

            txtBilgiPenceresi.Text = $"Bu sayfadan {txtMusteriAdi} isimli müşterinin bilgilerini güncelleyebilirsiniz. [ Yanında * olanlar zorunludur. ]";

        }

        private void btn_MusteriyiGuncelle_Click(object sender, RoutedEventArgs e)
        {
            if (txtMusteriAdi.Text == "" || txtMusteriSoyadi.Text == "" || txtCepTel.Text == "")
            {
                Prm.Hata = 1;
                Prm.BilgiMesajiAlani = "Müşterinin adı, soyadı ve cep telefonu boş olamaz!";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
            }
            else
            {
                veri.MusteriAdi = txtMusteriAdi.Text;
                veri.MusteriSoyadi = txtMusteriSoyadi.Text;
                veri.MusteriFaxNo = txtFaxNo.Text;
                veri.MusteriVergiDairesi = txtMusteriVergiDairesi.Text;
                veri.MusteriVergiNo = txtMusteriVergiNumarasi.Text;
                veri.MusteriEmail = txtMusteriEmail.Text;
                veri.MusteriAdres = txtMusteriAdres.Text;
                veri.MusteriIstel = txtIsTel.Text;
                veri.MusteriCepTel = txtCepTel.Text;

                if (Musteriler.musteriGuncelle(veri))
                {
                    Prm.Hata = 0;
                    Prm.BilgiMesajiAlani = "Müşteri başarıyla güncellendi...";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
                    string aktifMusteriler = "select m.ID, concat(m.Musteri_Adi,' ',m.Musteri_Soyadi) as Musteri_AdSoyad , mg.Musteri_Grubu, mb.Is_Tel, mb.Cep_Tel, " +
              "mb.Adres from musteriler m " +
              "left join musteri_bilgileri mb on m.ID = mb.Musteri_ID left join musteri_grubu mg on mg.ID = m.Musteri_Grubu_ID where m.Silindi_Mi=0;";
                    Genel.GridiDoldurGenel(grid, aktifMusteriler);
                    this.Close();
                }
                else
                {
                    Prm.Hata = 1;
                    Prm.BilgiMesajiAlani = "Müşteri güncellenirken bir sorun oldu!";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
                }

            }
          
            
        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // bool popupAcikMi = true; // Kişi elle kapatmak isterse diye
        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {

            Bonus.PopupShow(popup_bilgi);

        }

    }
}
