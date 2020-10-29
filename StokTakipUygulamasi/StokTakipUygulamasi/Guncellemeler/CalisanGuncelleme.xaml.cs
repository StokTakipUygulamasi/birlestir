using Microsoft.Win32;
using StokTakipUygulamasi.Class;
using StokTakipUygulamasi.Class.Parametreler;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// CalisanGuncelleme.xaml etkileşim mantığı
    /// </summary>
    public partial class CalisanGuncelleme : Window
    {
        string aktifCalisanlarSorgusu = "select c.ID, concat (c.Ad,' ',c.Soyad) Calisan_AdSoyad, c.TC, c.Kadi, c.Foto, c.Adres, " +
             "c.Giris_IP, cb.Tel, cb.E_mail, y.Yetki from calisanlar c left join calisan_bilgileri cb on c.ID = cb.Calisan_ID " +
             "left join calisan_yetki cy on cy.Calisan_ID = c.ID left join yetkiler y on y.ID = cy.Yetki_ID where c.Silindi_Mi=0 ";

        Prm veri = new Prm();
        DataGrid grid;
        public CalisanGuncelleme(int calisanID, DataGrid gelen_grid)
        {
            InitializeComponent();
            this.grid = gelen_grid;
            veri.CalisanID = calisanID;
            string yetkiCekmeSorgusu = "Select * from yetkiler";
            Genel.ComboBoxVeriCekme(cmb_Yetki,yetkiCekmeSorgusu,"Yetki");
            
            string calisaninYetkisiSorgu = $@"Select Yetki_ID from calisan_yetki where Calisan_ID='{calisanID}'";
            int calisaninYetkisiniCek = Genel.tekilVeriCekmeInt(calisaninYetkisiSorgu,"Yetki_ID");
            string calisanYetkiAdiSorgu = $@"Select yetki from yetkiler where ID='{calisaninYetkisiniCek}'";
            string calisaninYetkisi = Genel.tekilVeriCekmeString(calisanYetkiAdiSorgu,"Yetki");

            cmb_Yetki.SelectedItem = calisaninYetkisi;
            List<string> calisanBilgileriCek = Calisanlar.calisanTumBilgileri(calisanID);
            txtCalisanAdi.Text = calisanBilgileriCek[1];
            txtCalisanSoyadi.Text = calisanBilgileriCek[2];
            txtTCKimlikNo.Text = calisanBilgileriCek[3];
            txtKadi.Text = calisanBilgileriCek[4];
            txtSifre.Text = calisanBilgileriCek[5];
            txtCalisanAdres.Text = calisanBilgileriCek[6];
            if (!string.IsNullOrEmpty(calisanBilgileriCek[7]))
            {
                BitmapImage img = new BitmapImage();  // Resmi anlık olarak değiştirmek için kullanıyoruz.
                img.BeginInit();
                img.UriSource = new Uri(@"" + calisanBilgileriCek[7]);
                img.EndInit();
                img_CalisanResmi.Source = img;   // resmi burada değiştiriyoruz.
                veri.CalisanFoto = calisanBilgileriCek[7];
            }
            txtCepTel.Text = calisanBilgileriCek[8];
            txtCalisanEmail.Text = calisanBilgileriCek[9];


            txtBilgiPenceresi.Text = $"Bu sayfadan {txtCalisanAdi} isimli çalışanın bilgilerini güncelleyebilirsiniz. [ Yanında * olanlar zorunludur. ]";

        }

        private void txtSadeceSayi(object sender, TextCompositionEventArgs e)
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
                if (!Directory.Exists(Prm.BelgelerimYolu + "\\StokTakipProgrami\\CalisanResimleri"))
                {
                    Directory.CreateDirectory(Prm.BelgelerimYolu + "\\StokTakipProgrami\\CalisanResimleri");  // Belgelerimin içine Resimler adlı klasör oluşturuyoruz.
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
                    Random rst = new Random();
                    string sorgu;
                    string MusteriNoUret;
                    do
                    {
                        MusteriNoUret = rst.Next(100000000, 999999999).ToString();
                        sorgu = Genel.tekilVeriCekmeString($@"Select * from musteriler where Musteri_No='{MusteriNoUret}'", "ID");
                    } while (sorgu != "");
                    Prm.ResimAdi = Prm.BelgelerimYolu + "\\StokTakipProgrami\\CalisanResimleri\\" + MusteriNoUret + zaman.ToString(format) + ".png"; // BarkodNo + Zaman ismini ver. (Şöyle bir dosya oluşturacağım diyoruz)

                    File.Copy(SecilenResimAdi, Prm.ResimAdi, true);  // Aynı dosyayı iki kere oluşturuyoruz. Sadece ismini farklı yapıyoruz. Önceki resmi silmiyoruz.


                    // Belgelerim içindeki resmimizin yolunu uriye çevirip img_UrunResmi yoluna verme.
                    BitmapImage img = new BitmapImage();  // Resmi anlık olarak değiştirmek için kullanıyoruz.
                    img.BeginInit();
                    img.UriSource = new Uri(@"" + Prm.ResimAdi);
                    img.EndInit();
                    img_CalisanResmi.Source = img;   // resmi burada değiştiriyoruz.


                    // Resim Başarıyla Eklendi Ekranı
                    Prm.Hata = 0;
                    BilgiEkrani be = new BilgiEkrani();
                    Prm.BilgiMesajiAlani = "Resim başarıyla eklendi...";
                    be.Show();
                    veri.CalisanFoto = Prm.ResimAdi;
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

        private void btn_CalisaniGuncelle_Click(object sender, RoutedEventArgs e)
        {
            if (txtCalisanAdi.Text == "" || txtCalisanSoyadi.Text == "" || txtTCKimlikNo.Text == "" || txtKadi.Text == "" || txtSifre.Text == "" || txtCepTel.Text == "")
            {
                Prm.Hata = 1;
                Prm.BilgiMesajiAlani = "Lütfen zorunlu alanları (*) doldurun!";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
            }
            else
            {
                veri.CalisanAdi = txtCalisanAdi.Text;
                veri.CalisanSoyadi = txtCalisanSoyadi.Text;
                veri.CalisanTC = txtTCKimlikNo.Text;
                veri.CalisanKadi = txtKadi.Text;
                veri.CalisanSifre = txtSifre.Text;
                veri.CalisanAdres = txtCalisanAdres.Text;
                veri.CalisanTel = txtCepTel.Text;
                veri.CalisanEmail = txtCalisanEmail.Text;

                string yetkiIDSorgusu = $@"Select ID from yetkiler where yetki='{cmb_Yetki.SelectedItem}'";
                int guncelYetkiID = Genel.tekilVeriCekmeInt(yetkiIDSorgusu,"ID");
                veri.CalisanYetkiID = guncelYetkiID;

                if (Calisanlar.calisanGuncelle(veri,veri.CalisanID))
                {
                    Prm.Hata = 0;
                    Prm.BilgiMesajiAlani = "Çalışan başarıyla güncellendi...";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
                }
                else
                {
                    Prm.Hata = 1;
                    Prm.BilgiMesajiAlani = "Çalışan güncellenirken bir sorun oldu!";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
                }
                Genel.GridiDoldurGenel(grid, aktifCalisanlarSorgusu);
                this.Close();
            }
        }
    }
}
