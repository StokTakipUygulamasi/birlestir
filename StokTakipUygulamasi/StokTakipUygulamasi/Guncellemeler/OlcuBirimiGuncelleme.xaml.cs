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
    /// OlcuBirimiGuncelleme.xaml etkileşim mantığı
    /// </summary>
    public partial class OlcuBirimiGuncelleme : Window
    {
        string aktifOlcuBirimleri = "Select * from olcu_birimi where Silindi_Mi = 0";
        Prm veri = new Prm();
        DataGrid grid;
        public OlcuBirimiGuncelleme(DataGrid gelen_grid, int obID)
        {
            InitializeComponent();
            this.grid = gelen_grid;
            string olcuBirimiSorgusu = $@"Select * from olcu_birimi where ID='{obID}'";
            string olcuBirimi = Genel.tekilVeriCekmeString(olcuBirimiSorgusu,"Olcu_Birimi");
            txtEskiOlcubirimiAdi.Text = olcuBirimi;
            veri.Olcu_Birimi_ID = obID;

            txtBilgiPenceresi.Text = $"Bu sayfadan {txtEskiOlcubirimiAdi} isimli ölçü biriminin bilgilerini güncelleyebilirsiniz. [ Yanında * olanlar zorunludur. ]";
        }

        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {

            Bonus.PopupShow(popup_bilgi);

        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_OlcuBirimiGuncelle_Click(object sender, RoutedEventArgs e)
        {
            if (txtYeniOlcuBirimiAdi.Text == "")
            {
                Prm.Hata = 1;
                Prm.BilgiMesajiAlani = "Lütfen yeni ismi girin!";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
            }
            else
            {
                if (OlcuBirimleri.olcuBirimiAdiGuncelle(Convert.ToInt32(veri.Olcu_Birimi_ID),txtYeniOlcuBirimiAdi.Text))
                {
                    Prm.Hata = 0;
                    Prm.BilgiMesajiAlani = "Ölçü birimi adı güncellendi...";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
                }
                else
                {
                    Prm.Hata = 1;
                    Prm.BilgiMesajiAlani = "Ölçü birimi adı güncellenirken bir sorun oldu!";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
                }
                Genel.GridiDoldurGenel(grid,aktifOlcuBirimleri);
                this.Close();
            }
        }
    }
}
