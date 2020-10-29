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
using StokTakipUygulamasi.Class;
using StokTakipUygulamasi.Class.Parametreler;

namespace StokTakipUygulamasi
{
    /// <summary>
    /// iadeUrunler.xaml etkileşim mantığı
    /// </summary>
    public partial class iadeUrunler : Window
    {
        int[] adetList;
        String[] iptalNedeni;
        public iadeUrunler()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnIadeUrunAl_Click(object sender, RoutedEventArgs e)
        {  /*
            int dtgListeCount =  Convert.ToInt32(dtg_iadeUrunListesi.Items.Count);
            MessageBox.Show(dtgListeCount.ToString());
            int adet =Convert.ToInt32(dtg_iadeUrunListesi.Columns[2].GetCellContent(dtg_iadeUrunListesi.Items.GetItemAt(1)) as TextBox);

            TextBox text = ((TextBox)(dtg_iadeUrunListesi.Columns[2].GetCellContent(dtg_iadeUrunListesi.Items.GetItemAt(1)).DataContext as TextBox));
            adet = dtg_iadeUrunListesi.SelectedIndex;
            MessageBox.Show(adet.ToString());
          //  int adet = Convert.ToInt32(((TextBlock)dtg_iadeUrunListesi.Columns[0].GetCellContent(dtg_iadeUrunListesi.SelectedItem)).Text);

            */
            if (StogaEkleRadioButton.IsChecked == true || StoktanCikarRadioButton.IsChecked == true)
            {
                Prm prm = new Prm();
                prm.CalisanID = 1;
                prm.FaturaNo = faturaIDText.Text.ToString() ;
                prm.IadeTarihi = DateTime.Now;
                
                for (int i= 0; i<adetList.Length; i++)
                {
                   
                    if (adetList[i]!=0)
                    {
                        string UrunAdi = ((TextBlock)dtg_iadeUrunListesi.Columns[1].GetCellContent(dtg_iadeUrunListesi.Items.GetItemAt(i))).Text;
                        prm.UrunID = Genel.tekilVeriCekmeInt($@"select ID from stoktakipuygulamasi.urunler where Urun_Adi ='{UrunAdi}' ", "ID");
                        prm.IadeAdeti = adetList[i];
                        prm.IadeSebei = iptalNedeni[i];

                        if (Urunler.IadeAl(prm))
                        {
                            if (StogaEkleRadioButton.IsChecked == true)
                            {
                                int EldekiMiktar = Genel.tekilVeriCekmeInt($@"select Eldeki_Miktar from stok where  Urun_ID = '{ prm.UrunID}' ", "Eldeki_Miktar");
                                int ToplamGiris = Genel.tekilVeriCekmeInt($@"select Toplam_Giris from stok where  Urun_ID = '{ prm.UrunID}' ", "Toplam_Giris");
                                int ToptanCikis = Genel.tekilVeriCekmeInt($@"select Toplam_Cikis from stok where  Urun_ID = '{ prm.UrunID}' ", "Toplam_Cikis");
                                EldekiMiktar = EldekiMiktar + adetList[i];
                                ToplamGiris = ToplamGiris + adetList[i];
                                prm.Stok_EldekiMiktar = EldekiMiktar;
                                prm.Stok_Toplam_Giris = ToplamGiris;
                                
                                prm.Olcu_Birimi_ID = Genel.tekilVeriCekmeInt($@"select Olcu_Birimi_ID from stoktakipuygulamasi.urunler where Urun_Adi ='{UrunAdi}' ", "Olcu_Birimi_ID");
                                if (Stok.StokGuncellStogaEkle(prm,prm.UrunID))
                                {
                                    MessageBox.Show("Stoğa Eklendi");
                                }
                            }
                        }

                    }
                    

                }
            }
            else
            {
                MessageBox.Show("Lütfen Ürün Stoğa Eklenip Eklenmeyeceğine Seçiniz");
            }
        }

        private void getirButton_Click(object sender, RoutedEventArgs e)
        {
            string faturaID = faturaIDText.Text.ToString();
            faturaID = "fat123123";
            string sorgu = $@"select u.Urun_Adi, us.Fiyat, us.Adet from stoktakipuygulamasi.urun_satis us
                                join stoktakipuygulamasi.faturalar f on f.ID = us.Faturalar_ID
                                join stoktakipuygulamasi.urunler u on u.ID = us.Urun_ID where f.Fatura_No = '{faturaID}'";
            if (Genel.GridiDoldurGenel(dtg_iadeUrunListesi, sorgu))
            {
                adetList = new int[dtg_iadeUrunListesi.Items.Count];
                iptalNedeni = new string[dtg_iadeUrunListesi.Items.Count];
                MessageBox.Show(adetList.Length.ToString());
            }
            else
            {
                MessageBox.Show("Ürün Bulunamadı");
            }
        }

        private void iadeAdeti_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length > 0)
            {
                int iptalAdet = Convert.ToInt32(textBox.Text.ToString());

                int adet = Convert.ToInt32(((TextBlock)dtg_iadeUrunListesi.Columns[0].GetCellContent(dtg_iadeUrunListesi.SelectedItem)).Text);


                if (adet >= iptalAdet)
                {
                    adetList[dtg_iadeUrunListesi.SelectedIndex] =  iptalAdet;
                    
                }
                else
                {
                    MessageBox.Show("Lütfen Ürün Alış Adetini Aşmayın");
                    textBox.Text = null;
                    
                    

                }
            }
        }

        private void iadeAdetiText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) // Harf girilmesini engelliyoruz.
            {
                e.Handled = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }


        private void iadeIptalhText_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            iptalNedeni[dtg_iadeUrunListesi.SelectedIndex] = textBox.Text;
        }
    }
}
