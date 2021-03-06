﻿using StokTakipUygulamasi.Class;
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

namespace StokTakipUygulamasi.Eklemeler
{
    /// <summary>
    /// ToptanciEkle.xaml etkileşim mantığı
    /// </summary>
    public partial class ToptanciEkle : Window
    {
        DataGrid grid;
        public ToptanciEkle(DataGrid gelen_grid)
        {
            InitializeComponent();
            this.grid = gelen_grid;

            txtBilgiPenceresi.Text = "Bu sayfadan yeni bir toptancı ekleyebilirsiniz. [ Yanında * olanlar zorunludur. ]";
        }

        private void txtCepTel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) // Harf girilmesini engelliyoruz.
            {
                e.Handled = true;
            }
        }

        private void txtIsTel_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) // Harf girilmesini engelliyoruz.
            {
                e.Handled = true;
            }
        }

        private void txtFaxNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) // Harf girilmesini engelliyoruz.
            {
                e.Handled = true;
            }
        }


        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {

            Bonus.PopupShow(popup_bilgi);

        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Toptanciyi_Ekle_Click(object sender, RoutedEventArgs e)
        {
            if (txtToptanciAdi.Text != "" && txtIsTel.Text != "" && txtToptanciAdresi.Text != "")
            {
                Prm veri = new Prm();
                veri.ToptanciAdi = txtToptanciAdi.Text;
                veri.ToptanciAdresi = txtToptanciAdresi.Text;
                veri.ToptanciCepTel = txtCepTel.Text;
                veri.ToptantiIsTel = txtIsTel.Text;
                veri.ToptanciFaxNo = txtFaxNo.Text;
                veri.ToptanciAciklamasi = txtAciklama.Text;
                if (Toptancilar.toptanciEkle(veri))
                {
                    Prm.Hata = 0;
                    Prm.BilgiMesajiAlani = "Toptancı başarıyla eklendi...";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
                    string toptanciGridDoldur = $@"(select t.ID, t.Toptanci_Adi, t.Adres, t.Aciklama, tb.Cep_Tel, tb.Is_Tel, tb.Fax_No from toptancilar t left join toptanci_bilgileri tb on t.ID = tb.Toptanci_ID where t.Silindi_Mi=0)";
                    Genel.GridiDoldurGenel(grid, toptanciGridDoldur);
                    this.Close();
                }
                else
                {
                    Prm.Hata = 1;
                    Prm.BilgiMesajiAlani = "Toptancı eklenirken bir sorun oldu!";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
                }
            }
            else
            {
                Prm.Hata = 1;
                Prm.BilgiMesajiAlani = "Toptancı adı, İş telefonu ve Adres alanı boş olamaz!";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
            }
        }
    }
}
