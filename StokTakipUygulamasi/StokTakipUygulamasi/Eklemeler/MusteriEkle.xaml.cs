using System;
using System.Collections.Generic;
using StokTakipUygulamasi.UserController;
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
using StokTakipUygulamasi.Class.Parametreler;
using System.IO;
using Microsoft.Win32;
using StokTakipUygulamasi.Class;

namespace StokTakipUygulamasi.Eklemeler
{
    /// <summary>
    /// MusteriEkle.xaml etkileşim mantığı
    /// </summary>
    public partial class MusteriEkle : Window
    {
        DataGrid grid;
        Prm veri = new Prm();
        public MusteriEkle(DataGrid gelen_grid)
        {
            InitializeComponent();
            this.grid = gelen_grid;
            string musteri_grubu_cekme_sorgusu = "Select * from musteri_grubu";
            Genel.ComboBoxVeriCekme(cmb_MusteriGrubu, musteri_grubu_cekme_sorgusu, "Musteri_Grubu");
            cmb_MusteriGrubu.SelectedItem = "Genel";

            txtBilgiPenceresi.Text = "Bu sayfadanyeni bir müşteri ekleyebilirsiniz. [ Yanında * olanlar zorunludur. ]";
        }


        // bool popupAcikMi = true; // Kişi elle kapatmak isterse diye
        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {

            Bonus.PopupShow(popup_bilgi);

        }

        private void txtCepTel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) // Harf girilmesini engelliyoruz.
            {
                e.Handled = true;
            }

        }

        private void txtCepIsTel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) // Harf girilmesini engelliyoruz.
            {
                e.Handled = true;
            }

        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_MusteriEkle_Click(object sender, RoutedEventArgs e)
        {
            if (txtMusteriAdi.Text=="" || txtMusteriSoyadi.Text=="" || txtCepTel.Text=="")
            {
                Prm.Hata = 1;
                Prm.BilgiMesajiAlani = "Müşteri adı, soyadı ve cep telefonu boş olamaz!";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
            }
            else
            {
                string musteri_grubu_id_cek = $@"Select ID from musteri_grubu where Musteri_Grubu='{cmb_MusteriGrubu.SelectedItem}'";
                veri.MusteriGrubuID =  Genel.tekilVeriCekmeInt(musteri_grubu_id_cek,"ID");
                veri.MusteriAdi = txtMusteriAdi.Text;
                veri.MusteriSoyadi = txtMusteriSoyadi.Text;
                veri.MusteriIstel = txtIsTel.Text;
                veri.MusteriCepTel = txtCepTel.Text;
                veri.MusteriAdres = txtAdres.Text;
                veri.MusteriEmail = txtEmail.Text;
                if (Musteriler.musteriEkle(veri))
                {
                    Prm.Hata = 0;
                    Prm.BilgiMesajiAlani = "Müşteri Eklendi...";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
                    string aktifMusteriler = "select concat(m.Musteri_Adi,' ',m.Musteri_Soyadi) as Musteri_AdSoyad , mg.Musteri_Grubu, mb.Is_Tel, mb.Cep_Tel, " +
                                             "mb.Adres from musteriler m " +
                                             "left join musteri_bilgileri mb on m.ID = mb.Musteri_ID left join musteri_grubu " +
                                             "mg on mg.ID = m.Musteri_Grubu_ID where m.Silindi_Mi=0;";
                    Genel.GridiDoldurGenel(grid, aktifMusteriler);
                }
                else
                {
                    Prm.Hata = 1;
                    Prm.BilgiMesajiAlani = "Müşteri eklenirken bir sorun oldu!";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
                }

                this.Close();
                
            }
        }
    }
}
