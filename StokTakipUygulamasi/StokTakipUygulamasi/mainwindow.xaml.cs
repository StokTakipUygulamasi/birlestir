using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using StokTakipUygulamasi.Class;
using StokTakipUygulamasi.Class.Parametreler;

namespace StokTakipUygulamasi
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void btnGiris_Click(object sender, RoutedEventArgs e)
        {
            string kadi = txtKadi.Text;
            string sifre = txtSifre.Password;
            Genel islem = new Genel();
            islem.girisYap(kadi, sifre, this);
        }

    }
}
