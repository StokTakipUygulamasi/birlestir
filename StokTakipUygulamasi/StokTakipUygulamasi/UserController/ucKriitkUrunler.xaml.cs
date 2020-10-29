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
    /// ucKriitkUrunler.xaml etkileşim mantığı
    /// </summary>
    public partial class ucKriitkUrunler : UserControl
    {
        public ucKriitkUrunler()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string sorgu = ($@"select u.ID, u.Urun_Adi,u.Barkod_No,u.Aciklama,u.KDV_Orani,u.Kar_Orani,u.Satis_Fiyati,u.Satista_mi,
                                    ob.Olcu_Birimi,u.Olcu_Miktar, s.Eldeki_Miktar, u.Kritik_Durum
                                    from stoktakipuygulamasi.urunler u  
                                    left join stoktakipuygulamasi.olcu_birimi ob on u.Olcu_Birimi_ID = ob.ID
                                    left join stoktakipuygulamasi.stok s on s.Urun_ID = u.ID where u.Kritik_Durum >= s.Eldeki_Miktar ");
            Genel.GridiDoldurGenel(dtg_Kritik_Urunler_Listesi,sorgu);




        }
    }
}
