using StokTakipUygulamasi.Class;
using StokTakipUygulamasi.Class.Parametreler;
using StokTakipUygulamasi.Eklemeler;
using StokTakipUygulamasi.Guncellemeler;
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

namespace StokTakipUygulamasi.Pencereler
{
    /// <summary>
    /// OlcuBirimleriEkleCikar.xaml etkileşim mantığı
    /// </summary>
    public partial class OlcuBirimleriEkleCikar : Window
    {
        string id;
        Anasayfa gk = (Anasayfa)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        string aktifOlcuBirimleri = "Select * from olcu_birimi where Silindi_Mi = 0";
        string silinmisOlcuBirimleri = "Select * from olcu_birimi where Silindi_Mi = 1";
        public OlcuBirimleriEkleCikar()
        {
            InitializeComponent();
            Genel.GridiDoldurGenel(dtg_OlcuBirimiListesi,aktifOlcuBirimleri);
            btnGeriAl.Visibility = Visibility.Hidden;

            txtBilgiPenceresi.Text = $"Bu sayfadan ölçü birimlerine ilişkin bilgilere ulaşabilir, ölçü birimi arayabilir, silinen ölçü birimlerini görebilir, ölçü birimlerinin bilgilerini güncelleyebilir, ölçü birimlerini silebilir/geri alabilir ya da yeni bir ölçü birimi ekleyebilirsiniz.";
        }

        private void checkbox_silinenOlcuBirimleri_Checked(object sender, RoutedEventArgs e)
        {
            Genel.GridiDoldurGenel(dtg_OlcuBirimiListesi,silinmisOlcuBirimleri);
            btnGeriAl.Visibility = Visibility.Visible;
            btnGuncelle.IsEnabled = false;
            btnSil.IsEnabled = false;
            btnOlcuBirimiEkle.IsEnabled = false;
            Prm.checkbox_silinen_olcu_birimleri = true;
        }

        private void checkbox_silinenOlcuBirimleri_Unchecked(object sender, RoutedEventArgs e)
        {
            Genel.GridiDoldurGenel(dtg_OlcuBirimiListesi,aktifOlcuBirimleri);
            btnGeriAl.Visibility = Visibility.Hidden;
            btnGuncelle.IsEnabled = true;
            btnSil.IsEnabled = true;
            btnOlcuBirimiEkle.IsEnabled = true;
            Prm.checkbox_silinen_olcu_birimleri = false;
        }

        private void btnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            id = ((TextBlock)dtg_OlcuBirimiListesi.Columns[0].GetCellContent(dtg_OlcuBirimiListesi.SelectedItem)).Text;
            if (dtg_OlcuBirimiListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir ölçü birimi seçiniz!","Hata",MessageBoxButton.OK,MessageBoxImage.Warning);

            }
            else
            {
                OlcuBirimiGuncelleme obg = new OlcuBirimiGuncelleme(dtg_OlcuBirimiListesi,Convert.ToInt32(id));
                obg.Owner = gk;
                obg.ShowDialog();
            }    
        }

        private void btnSil_Click(object sender, RoutedEventArgs e)
        {
           
                if (dtg_OlcuBirimiListesi.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen bir ölçü birimi seçiniz!", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Ölçü birimini silmek istediğinize emin misiniz?", "Evet/Hayır", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    id = ((TextBlock)dtg_OlcuBirimiListesi.Columns[0].GetCellContent(dtg_OlcuBirimiListesi.SelectedItem)).Text;
                    if (OlcuBirimleri.olcuBirimiSilGeriAl(Convert.ToInt32(id), "sil"))
                    {
                        Prm.Hata = 0;
                        Prm.BilgiMesajiAlani = "Silme işlemi başarıyla gerçekleşti...";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                    }
                    else
                    {
                        Prm.Hata = 1;
                        Prm.BilgiMesajiAlani = "Silme işlemi sırasında bir sorun oldu!";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                    }
                    Genel.GridiDoldurGenel(dtg_OlcuBirimiListesi, aktifOlcuBirimleri);
                }
                    
            }
        }

        private void btnOlcuBirimiEkle_Click(object sender, RoutedEventArgs e)
        {
            OlcuBirimiEkle obe = new OlcuBirimiEkle(dtg_OlcuBirimiListesi);
            obe.Owner = gk;
            obe.ShowDialog();
        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // bool popupAcikMi = true; // Kişi elle kapatmak isterse diye
        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {
            Bonus.PopupShow(popup_bilgi);
            txtBilgiPenceresi.Text = "Bu sayfadan ölçü birimi ekleyebilir, ölçü birimlerini güncelleyebilir ya da ölçü birimlerini silebilirsiniz." +
                " Sildiğiniz ölçü birimlerini de 'Silinen Ölçü birimleri' alanından görüntüleyebilir, silinen ölçü birimlerini geri getirebilirsiniz...";
        }

        private void btnGeriAl_Click(object sender, RoutedEventArgs e)
        {
           
                if (dtg_OlcuBirimiListesi.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen bir ölçü birimi seçiniz!", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Ölçü birimini geri almak istediğinize emin misiniz?", "Evet/Hayır", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        id = ((TextBlock)dtg_OlcuBirimiListesi.Columns[0].GetCellContent(dtg_OlcuBirimiListesi.SelectedItem)).Text;
                        if (OlcuBirimleri.olcuBirimiSilGeriAl(Convert.ToInt32(id), "geri al"))
                        {
                            Prm.Hata = 0;
                            Prm.BilgiMesajiAlani = "Geri alma işlemi başarıyla gerçekleşti...";
                            BilgiEkrani be = new BilgiEkrani();
                            be.Show();
                        }
                        else
                        {
                            Prm.Hata = 1;
                            Prm.BilgiMesajiAlani = "Geri alma işlemi sırasında bir sorun oldu!";
                            BilgiEkrani be = new BilgiEkrani();
                            be.Show();
                        }
                    Genel.GridiDoldurGenel(dtg_OlcuBirimiListesi, silinmisOlcuBirimleri);
                }
               
            }
              

        }

        private void txtOlcuBirimiAra_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Prm.checkbox_silinen_olcu_birimleri == true)
            {
                if (txtOlcuBirimiAra.Text == "")
                {
                    Genel.GridiDoldurGenel(dtg_OlcuBirimiListesi, silinmisOlcuBirimleri);
                }
                else
                {
                    string deger = txtOlcuBirimiAra.Text + "%";
                    string getir = $@"select * from olcu_birimi where Olcu_Birimi like '{deger}' and Silindi_Mi=1";
                    Genel.GridiDoldurGenel(dtg_OlcuBirimiListesi, getir);
                }
            }
            else
            {
                if (txtOlcuBirimiAra.Text == "")
                {
                    Genel.GridiDoldurGenel(dtg_OlcuBirimiListesi, aktifOlcuBirimleri);
                }
                else
                {
                    string deger = txtOlcuBirimiAra.Text + "%";
                    string getir = $@"select * from olcu_birimi where Olcu_Birimi like '{deger}' and Silindi_Mi=0";
                    Genel.GridiDoldurGenel(dtg_OlcuBirimiListesi, getir);
                }
            }
           
            
        }
    }
}
