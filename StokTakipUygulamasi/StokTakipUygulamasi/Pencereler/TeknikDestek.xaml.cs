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
using System.Net.Mail;

namespace StokTakipUygulamasi.Pencereler
{
    /// <summary>
    /// TeknikDestek.xaml etkileşim mantığı
    /// </summary>
    public partial class TeknikDestek : Window
    {
        public TeknikDestek()
        {
            InitializeComponent();
           
            txtGonderenCalisan.Text = Prm.oturumCalisanAd + " " + Prm.oturumCalisanSoyad;
            DockPanelDosyaAlani.Visibility = Visibility.Hidden;

            txtBilgiPenceresi.Text = "Bu sayfadan teknik destek almak için teknik destek ekibine mesaj gönderebilirsiniz.";
        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {

            Bonus.PopupShow(popup_bilgi);

        }

        string SecilenDosyaAdi;

        private void btnDosyaEkle_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                // Belgelerim klasöründe StokTakipProgrami ve içinde Resimler klasörü yoksa oluştur diyoruz. Varsa zaten aşağıdaki işlemleri yapacak.
                if (!Directory.Exists(Prm.BelgelerimYolu + "\\StokTakipProgrami\\TeknikDestekDosyalari"))
                {
                    Directory.CreateDirectory(Prm.BelgelerimYolu + "\\StokTakipProgrami\\TeknikDestekDosyalari");  // Belgelerimin içine TeknikDestekDosyalari adlı klasör oluşturuyoruz.
                }

                // OpenFileDialog ile resim seçme işlemi yapıyoruz.
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Bir dosya seçin";
                dialog.InitialDirectory = "";  // Pencere açıldığında ilk olarak karşımıza hangi pencere gelsin onu seçiyoruz. Direkt Belgelerimi seçebiliriz yani.
                dialog.Filter = "Image Files (*.jpg;*.jpeg;)|*.jpg;*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)" +
                    "|*.jpg|Pdf Files (*.pdf)|*.pdf| Archives Files | *.zip; *.rar" +
                    "|Office Files|*.doc;*.xls;*.xlsx;*.ppt";  // Seçilecek dosyayı filtreliyoruz. Resim ve pdf seçmek istediğimiz için. // filtreleme yapmıyoruz
                dialog.FilterIndex = 1;
                if ((bool)dialog.ShowDialog())  // Seçim işlemi başarılı ise buraya girecek.
                {
                    // Openfile dialog ile seçilen resmi oluşturduğumuz klasör içerisine kopyalama işlemi.
                    SecilenDosyaAdi = dialog.FileName;
                    // string yol = dialog.SafeFileName;
                    DateTime zaman = DateTime.Now;
                    string format = "dd-MM-yyyy-hh-mm-ss";
                    Random rst = new Random();
                    string sayiUret;
                    sayiUret = rst.Next(100000000, 999999999).ToString();

                    Prm.DosyaAdi = Prm.BelgelerimYolu + "\\StokTakipProgrami\\TeknikDestekDosyalari\\" + sayiUret + zaman.ToString(format)+dialog.SafeFileName; // SayiUret + Zaman ismini ver. (Şöyle bir dosya oluşturacağım diyoruz)

                    File.Copy(SecilenDosyaAdi, Prm.DosyaAdi, true);  // Aynı dosyayı iki kere oluşturuyoruz. Sadece ismini farklı yapıyoruz. Önceki resmi silmiyoruz.



                    // Dosya Başarıyla Eklendi Ekranı
                    Prm.Hata = 0;
                    BilgiEkrani be = new BilgiEkrani();
                    Prm.BilgiMesajiAlani = "Dosya başarıyla eklendi...";
                    be.Show();
                    btnDosyaEkle.Content = "Dosya eklendi";
                    btnDosyaEkle.Foreground = Brushes.Green;
                    DockPanelDosyaAlani.Visibility = Visibility.Visible;
                    lblDosyaAdi.Content = " Görüntüle";
                    lblDosyaAdi.Foreground = Brushes.Green;
                }
                else
                {
                    // Resim Eklenemedi Ekranı
                    Prm.Hata = 1;
                    BilgiEkrani be = new BilgiEkrani();
                    Prm.BilgiMesajiAlani = "Dosya eklenirken bir sorun oldu!";
                    be.Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_MesajiGonder_Click(object sender, RoutedEventArgs e)
        {
            Prm veri = new Prm();
            if (txtMesajKonusu.Text == "" || txtMesaj.Text == "")
            {
                Prm.Hata = 1;
                Prm.BilgiMesajiAlani = "Lütfen zorunlu alanları (*) doldurun";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
            }
            else
            {
                veri.TeknikDestekMailKonusu = txtMesajKonusu.Text;
                veri.TeknikDestekMailGonderen = txtGonderenCalisan.Text;
                veri.TeknikDestekMailIcerik = txtMesaj.Text;
                veri.TeknikDestekMailCepTel = txtCepTel.Text;
                veri.TeknikDestekMailDosya = Prm.DosyaAdi;

                string firmaSorgusu = "Select * from firma_bilgileri";
                string firmaAdi = Genel.tekilVeriCekmeString(firmaSorgusu,"Firma_Adi");
                string firmaMail = Genel.tekilVeriCekmeString(firmaSorgusu,"E_mail");

                string birlesmisMesaj = $"\n Firma Adı: {firmaAdi}"+ 
                                        $"\n Gönderen: {veri.TeknikDestekMailGonderen}"+
                                        $"\n Konu: {veri.TeknikDestekMailKonusu}"+
                                        $"\n Cep Tel: {veri.TeknikDestekMailCepTel}"+ 
                                        $"\n İçerik: {veri.TeknikDestekMailIcerik}";
                MailMessage ePosta = new MailMessage();
                ePosta.From = new MailAddress(firmaMail);
                ePosta.To.Add("a.yasinnbalci@gmail.com");
                ePosta.To.Add("semihkeles1997@hotmail.com");
                ePosta.To.Add("umitsu255@gmail.com");
                if (!string.IsNullOrEmpty(veri.TeknikDestekMailDosya))
                {
                    ePosta.Attachments.Add(new Attachment($@"{veri.TeknikDestekMailDosya}"));
                }
                ePosta.Subject = veri.TeknikDestekMailKonusu;
                ePosta.Body = birlesmisMesaj;
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new System.Net.NetworkCredential("semihkeles1997@hotmail.com", "Fb 190797");
                smtp.Port = 587;
                smtp.Host = "smtp.live.com";
                smtp.EnableSsl = true;
                bool kontrol = false;
                try
                {
                    smtp.SendAsync(ePosta, (object)ePosta);
                    Prm.Hata = 0;
                    Prm.BilgiMesajiAlani = "Mail başarıyla gönderildi...";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
                    kontrol = true;
                }
                catch (SmtpException ex)
                {
                    MessageBox.Show(ex.Message, "Mail gönderilirken bir sorun oldu!");
                }
                if (kontrol)
                {
                    this.Close();
                }

            }
        }

        private void txtSadeceSayi(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) // Harf girilmesini engelliyoruz.
            {
                e.Handled = true;
            }
        }

        private void lblDosyaAdi_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(Prm.DosyaAdi);
        }

        private void img_YuklenenDosya_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(Prm.DosyaAdi);
        }
    }
}
