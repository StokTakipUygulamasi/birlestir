using StokTakipUygulamasi.Class.Parametreler;
using StokTakipUygulamasi.Eklemeler;
using StokTakipUygulamasi.Guncellemeler;
using StokTakipUygulamasi.Pencereler;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StokTakipUygulamasi.UserController
{
    /// <summary>
    /// ucToptancilar.xaml etkileşim mantığı
    /// </summary>
    public partial class ucToptancilar : UserControl
    {
        public ucToptancilar()
        {
            InitializeComponent();
            btnToptanciyiGeriAl.Visibility = Visibility.Hidden;
        }

        Anasayfa gk = (Anasayfa)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string toptanciGridDoldur = $@"(select t.ID, t.Toptanci_Adi, t.Adres, t.Aciklama, tb.Cep_Tel, tb.Is_Tel, tb.Fax_No from toptancilar t left join toptanci_bilgileri tb on t.ID = tb.Toptanci_ID where t.Silindi_Mi=0)";
            Genel.GridiDoldurGenel(dtg_ToptancilarListesi, toptanciGridDoldur);
        }

        private void check_Eski_Toptancilarim_Checked(object sender, RoutedEventArgs e)
        {
            Prm.checkbox_eski_toptancilari_getir = true;
            string toptanciGridDoldur = $@"(select t.ID, t.Toptanci_Adi, t.Adres, t.Aciklama, tb.Cep_Tel, tb.Is_Tel, tb.Fax_No from toptancilar t left join toptanci_bilgileri tb on t.ID = tb.Toptanci_ID where t.Silindi_Mi=1)";
            Genel.GridiDoldurGenel(dtg_ToptancilarListesi, toptanciGridDoldur);
            btnToptanciyiGeriAl.Visibility = Visibility.Visible;
            btnGuncelle.IsEnabled = false;
            btnSil.IsEnabled = false;
            btn_Toptanci_Ekle.IsEnabled = false;
        }

        private void check_Eski_Toptancilarim_Unchecked(object sender, RoutedEventArgs e)
        {
            Prm.checkbox_eski_toptancilari_getir = false;
            string toptanciGridDoldur = $@"(select t.ID, t.Toptanci_Adi, t.Adres, t.Aciklama, tb.Cep_Tel, tb.Is_Tel, tb.Fax_No from toptancilar t left join toptanci_bilgileri tb on t.ID = tb.Toptanci_ID where t.Silindi_Mi=0)";
            Genel.GridiDoldurGenel(dtg_ToptancilarListesi, toptanciGridDoldur);
            btnGuncelle.IsEnabled = true;
            btnSil.IsEnabled = true;
            btn_Toptanci_Ekle.IsEnabled = true;
            btnToptanciyiGeriAl.Visibility = Visibility.Hidden;
        }
        string id;
        private void btnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_ToptancilarListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir toptancı seçiniz!","Hata",MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                id = ((TextBlock)dtg_ToptancilarListesi.Columns[0].GetCellContent(dtg_ToptancilarListesi.SelectedItem)).Text;
                ToptanciGuncelle tg = new ToptanciGuncelle(dtg_ToptancilarListesi,Convert.ToInt32(id));
                tg.Owner = gk;
                tg.Show();
            }
           
        }

        private void btnSil_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_ToptancilarListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir toptancı seçiniz!", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                id = ((TextBlock)dtg_ToptancilarListesi.Columns[0].GetCellContent(dtg_ToptancilarListesi.SelectedItem)).Text;
                ToptanciSilmePenceresi tsp = new ToptanciSilmePenceresi(Convert.ToInt32(id),dtg_ToptancilarListesi);
                tsp.Owner = gk;
                tsp.ShowDialog();
            }
        }

        private void btn_Toptanci_Ekle_Click(object sender, RoutedEventArgs e)
        {
            ToptanciEkle te = new ToptanciEkle(dtg_ToptancilarListesi);
            te.Owner = gk;
            te.ShowDialog();
        }

        private void btnToptanciyiGeriAl_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_ToptancilarListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen geri almak istediğiniz bir toptancıyı seçiniz!", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Toptancıyı geri almak istediğinize emin misiniz?","Evet/Hayır",MessageBoxButton.YesNo,MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    id = ((TextBlock)dtg_ToptancilarListesi.Columns[0].GetCellContent(dtg_ToptancilarListesi.SelectedItem)).Text;
                    if (Toptancilar.toptanciSilGeriAl(Convert.ToInt32(id)))
                    {
                        Prm.Hata = 0;
                        Prm.BilgiMesajiAlani = "Toptancı başarıyla geri alındı...";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                        string toptanciGridDoldur = $@"(select t.ID, t.Toptanci_Adi, t.Adres, t.Aciklama, tb.Cep_Tel, tb.Is_Tel, tb.Fax_No from toptancilar t left join toptanci_bilgileri tb on t.ID = tb.Toptanci_ID where t.Silindi_Mi=1)";
                        Genel.GridiDoldurGenel(dtg_ToptancilarListesi, toptanciGridDoldur);
                    }
                    else
                    {
                        Prm.Hata = 1;
                        Prm.BilgiMesajiAlani = "Toptancı geri alınırken bir sorun oldu!";
                        BilgiEkrani be = new BilgiEkrani();
                        be.ShowDialog();
                    }
                }
                
            }
        }
    }
}
