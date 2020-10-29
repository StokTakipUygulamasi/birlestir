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

namespace StokTakipUygulamasi.Pencereler
{
    /// <summary>
    /// ToptanciSilmePenceresi.xaml etkileşim mantığı
    /// </summary>
    public partial class ToptanciSilmePenceresi : Window
    {
        DataGrid grid;
        Prm veri = new Prm();
        public ToptanciSilmePenceresi(int toptanciID, DataGrid gelen_grid)
        {
            InitializeComponent();
            this.grid = gelen_grid;
            veri.ToptanciID = toptanciID;

            string toptanciAdiSorgu = $"Select * from toptancilar where ID='{toptanciID}'";
            string toptanciAdi = Genel.tekilVeriCekmeString(toptanciAdiSorgu,"Toptanci_Adi");

            txtBilgiPenceresi.Text = $"Bu sayfadan {toptanciAdi} isimli toptancıyı silebilirsiniz.";
        }

        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {

            Bonus.PopupShow(popup_bilgi);
            txtBilgiPenceresi.Text = "Bu sayfadan bir toptancıyı silebilir, silme sebebini girebilir. " +
                "Dilerseniz daha sonra silinen bir toptancıyı geri getirebilirsiniz.";
        }


        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Toptanciyi_Sil_Click(object sender, RoutedEventArgs e)
        {
            if (Toptancilar.toptanciSil(veri.ToptanciID, txtSilmeSebebi.Text))
            {
                Prm.Hata = 0;
                Prm.BilgiMesajiAlani = "Toptancı başarıyla silindi. Silinen toptancıları 'Eski Toptancılarım' seçeneğinden görüntüleyebilirsiniz.";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
                string toptanciGridDoldur = $@"(select t.ID, t.Toptanci_Adi, t.Adres, t.Aciklama, tb.Cep_Tel, tb.Is_Tel, tb.Fax_No from toptancilar t left join toptanci_bilgileri tb on t.ID = tb.Toptanci_ID where t.Silindi_Mi=0)";
                Genel.GridiDoldurGenel(grid, toptanciGridDoldur);
                this.Close();
            }
            else
            {
                Prm.Hata = 1;
                Prm.BilgiMesajiAlani = "Toptancı silinirken bir sorun oluştu!";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
                string toptanciGridDoldur = $@"(select t.ID, t.Toptanci_Adi, t.Adres, t.Aciklama, tb.Cep_Tel, tb.Is_Tel, tb.Fax_No from toptancilar t left join toptanci_bilgileri tb on t.ID = tb.Toptanci_ID where t.Silindi_Mi=0)";
                Genel.GridiDoldurGenel(grid, toptanciGridDoldur);
                this.Close();
            }
            
        }
    }
}
