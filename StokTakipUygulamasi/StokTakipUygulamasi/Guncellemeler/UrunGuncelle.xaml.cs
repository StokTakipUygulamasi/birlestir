using Microsoft.Win32;
using StokTakipUygulamasi.Class;
using StokTakipUygulamasi.Class.Parametreler;
using StokTakipUygulamasi.UserController;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
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

namespace StokTakipUygulamasi
{
    /// <summary>
    /// UrunGuncelle.xaml etkileşim mantığı
    /// </summary>
    /// 
    public partial class UrunGuncelle : Window
    {
        DataGrid grid;
        Prm veri = new Prm();
        public UrunGuncelle(DataGrid gelen_grid, string id)
        {
            this.grid = gelen_grid;
            InitializeComponent();
            veri.ID = id;
            string[] cek = Urunler.urunCek(id);
            txtUrunAdi.Text = cek[1];
            txtBarkodNo.Text = cek[2];
            txtAciklama.Text = cek[3];
            txtKDVOrani.Text = cek[4];
            txtKarOrani.Text = cek[5];
            txtSatisFiyati.Text = cek[6];
            txtKritikDurum.Text = cek[11];
            cmb_UrunOlcuBirimi = Genel.OlcuBirimleri(cmb_UrunOlcuBirimi);
            cmb_UrunOlcuBirimi.SelectedItem = cek[7];
            if (Convert.ToInt32(cek[8]) == 1)
            {
                checkbox_satistami.IsChecked = true;
            }
            else
            {
                checkbox_satistami.IsChecked = false;
            }
            txtOlcuMiktar.Text = cek[9];

            if (!string.IsNullOrEmpty(cek[10]))
            {
                BitmapImage img = new BitmapImage();  // Resmi anlık olarak değiştirmek için kullanıyoruz.
                img.BeginInit();
                img.UriSource = new Uri(@"" + cek[10]);
                img.EndInit();
                img_UrunResmi.Source = img;   // resmi burada değiştiriyoruz.
            }

            txtBilgiPenceresi.Text = $"Bu sayfadan {txtUrunAdi} isimli ürünün bilgilerini güncelleyebilirsiniz. [ Yanında * olanlar zorunludur. ]";
        }

        private void txtKDVOrani_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) // Harf girilmesini engelliyoruz.
            {
                e.Handled = true;
            }
        }

        private void txtOlcuMiktar_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) // Harf girilmesini engelliyoruz.
            {
                e.Handled = true;
            }
        }

        private void txtKarOrani_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) // Harf girilmesini engelliyoruz.
            {
                e.Handled = true;
            }
        }

        private void txtSatisFiyati_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) // Harf girilmesini engelliyoruz.
            {
                e.Handled = true;
            }
        }

        private void txtKritikDurum_PreviewTextInput(object sender, TextCompositionEventArgs e)
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

        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {

            Bonus.PopupShow(popup_bilgi);

        }

        string SecilenResimAdi;
        private void btnResimEkle_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                // Belgelerim klasöründe StokTakipProgrami ve içinde Resimler klasörü yoksa oluştur diyoruz. Varsa zaten aşağıdaki işlemleri yapacak.
                if (!Directory.Exists(Prm.BelgelerimYolu + "\\StokTakipProgrami\\UrunResimleri"))
                {
                    Directory.CreateDirectory(Prm.BelgelerimYolu + "\\StokTakipProgrami\\UrunResimleri");  // Belgelerimin içine Resimler adlı klasör oluşturuyoruz.
                }

                // OpenFileDialog ile resim seçme işlemi yapıyoruz.
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Resim seç";
                dialog.InitialDirectory = "";  // Pencere açıldığında ilk olarak karşımıza hangi pencere gelsin onu seçiyoruz. Direkt Belgelerimi seçebiliriz yani.
                dialog.Filter = "Image Files (*.jpg;*.jpeg;)|*.jpg;*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";  // Seçilecek dosyayı filtreliyoruz. Resim seçmek istediğimiz için.
                dialog.FilterIndex = 1;
                if ((bool)dialog.ShowDialog())  // Seçim işlemi başarılı ise buraya girecek.
                {
                    // Openfile dialog ile seçilen resmi oluşturduğumuz klasör içerisine kopyalama işlemi.
                    SecilenResimAdi = dialog.FileName;
                    DateTime zaman = DateTime.Now;
                    string format = "dd-MM-yyyy-hh-mm-ss";
                    Prm.ResimAdi = Prm.BelgelerimYolu + "\\StokTakipProgrami\\UrunResimleri\\" + Prm.BarkodNo + zaman.ToString(format) + ".png"; // BarkodNo + Zaman ismini ver. (Şöyle bir dosya oluşturacağım diyoruz)

                    File.Copy(SecilenResimAdi, Prm.ResimAdi, true);  // Aynı dosyayı iki kere oluşturuyoruz. Sadece ismini farklı yapıyoruz. Önceki resmi silmiyoruz.


                    // Belgelerim içindeki resmimizin yolunu uriye çevirip img_UrunResmi yoluna verme.
                    BitmapImage img = new BitmapImage();  // Resmi anlık olarak değiştirmek için kullanıyoruz.
                    img.BeginInit();
                    img.UriSource = new Uri(@"" + Prm.ResimAdi);
                    img.EndInit();
                    img_UrunResmi.Source = img;   // resmi burada değiştiriyoruz.


                    // Resim Başarıyla Eklendi Ekranı
                    Prm.Hata = 0;
                    BilgiEkrani be = new BilgiEkrani();
                    Prm.BilgiMesajiAlani = "Resim başarıyla eklendi...";
                    be.Show();
                }
                else
                {
                    // Resim Eklenemedi Ekranı
                    Prm.Hata = 1;
                    BilgiEkrani be = new BilgiEkrani();
                    Prm.BilgiMesajiAlani = "Resim eklenirken bir sorun oldu!";
                    be.Show();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void btn_Urunu_Guncelle_Click(object sender, RoutedEventArgs e)
        {
            if (txtUrunAdi.Text != "" && cmb_UrunOlcuBirimi.Text != "")
            {
                veri.UrunAdi = txtUrunAdi.Text;
                veri.Olcu_Birimi = cmb_UrunOlcuBirimi.Text;
                string sorgu_OlcuBirimiID = ($@"Select ID from olcu_birimi where Olcu_Birimi='{cmb_UrunOlcuBirimi.SelectedItem}'");
                veri.Olcu_Birimi_ID = Genel.tekilVeriCekmeInt(sorgu_OlcuBirimiID,"ID");

                veri.Aciklama = txtAciklama.Text;
                veri.Barkod_No = txtBarkodNo.Text;
                veri.Resim = Prm.ResimAdi;
                veri.Satista_Mi = checkbox_satistami.IsEnabled;
                veri.KritikDurum = Convert.ToInt32(txtKritikDurum.Text);
                if (checkbox_satistami.IsChecked.Value)
                {
                    veri.Satista_Mi = true;
                }
                else
                {
                    veri.Satista_Mi = false;
                }

                if (txtOlcuMiktar.Text == "")
                {
                    veri.Olcu_Miktar = null;
                }
                else
                {
                    veri.Olcu_Miktar = Convert.ToInt32(txtOlcuMiktar.Text);
                }

                if (txtKDVOrani.Text == "")
                {
                    veri.KDV_Orani = null;
                }
                else
                {
                    veri.KDV_Orani = Convert.ToInt32(txtKDVOrani.Text);
                }

                if (txtKarOrani.Text == "")
                {
                    veri.Kar_Orani = null;
                }
                else
                {
                    veri.Kar_Orani = Convert.ToInt32(txtKarOrani.Text);
                }

                if (txtSatisFiyati.Text == "")
                {
                    veri.Satis_Fiyati = null;
                }
                else
                {
                    veri.Satis_Fiyati = Convert.ToInt32(txtSatisFiyati.Text);
                }
                if (Urunler.UrunuGuncelle(veri,veri.ID))
                {
                    if (Prm.checkbox_Satista_Olanlar == false)
                    {
                        string sorgu_SatistaOlanUrunler = ($@"select u.ID, u.Urun_Adi,u.Barkod_No,u.Aciklama,u.KDV_Orani,u.Kar_Orani,u.Satis_Fiyati,u.Satista_mi, ob.Olcu_Birimi 
                                    from urunler u  join olcu_birimi ob on u.Olcu_Birimi_ID = ob.ID  Where u.Satista_Mi=0");
                        Genel.GridiDoldurGenel(grid,sorgu_SatistaOlanUrunler);
                    }
                    else
                    {
                        string sorgu_SatistaOlmayanUrunler = ($@"select u.ID, u.Urun_Adi,u.Barkod_No,u.Aciklama,u.KDV_Orani,u.Kar_Orani,u.Satis_Fiyati,u.Satista_mi, ob.Olcu_Birimi 
                                    from urunler u  join olcu_birimi ob on u.Olcu_Birimi_ID = ob.ID  Where u.Satista_Mi=1");
                        Genel.GridiDoldurGenel(grid, sorgu_SatistaOlmayanUrunler);
                    }
                    
                    Prm.Hata = 0;
                    Prm.BilgiMesajiAlani = "Ürün başarıyla güncellendi...";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
                    this.Close();
                }
                else
                {
                    Prm.Hata = 1;
                    Prm.BilgiMesajiAlani = "Ürün güncellenirken bir sorun oldu!";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
                }
            }
            else
            {
                Prm.Hata = 1;
                Prm.BilgiMesajiAlani = "Ürün adı ve ölçü birimi boş olamaz!";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
            }
            
        }

     
    }
}
