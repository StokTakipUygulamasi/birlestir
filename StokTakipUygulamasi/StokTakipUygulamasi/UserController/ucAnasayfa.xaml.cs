﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Crypto.Tls;
using StokTakipUygulamasi.Class.Parametreler;

namespace StokTakipUygulamasi.UserController
{
    /// <summary>
    /// ucAnasayfa.xaml etkileşim mantığı
    /// </summary>
    /// 
    
    public partial class ucAnasayfa : UserControl
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public ucAnasayfa()
        {
            InitializeComponent();
            Genel.calisanlari_cek(dtg_calisanlar);

            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "1") == false)
            {
                btnCirolar.Visibility = Visibility.Collapsed;
            }

            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "3") == false)
            {
                stackpanel_calisanlar.Visibility = Visibility.Collapsed;
            }


            

        }


        private decimal GetRate(string code)
        {
            string url = string.Empty;
            var date = DateTime.Now;
            if (date.Date == DateTime.Today)
                url = "http://www.tcmb.gov.tr/kurlar/today.xml";
            else
                url = string.Format("http://www.tcmb.gov.tr/kurlar/{0}{1}/{2}{1}{0}.xml", date.Year, addZero(date.Month), addZero(date.Day));

            System.Xml.Linq.XDocument document = System.Xml.Linq.XDocument.Load(url);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            var result = document.Descendants("Currency")
            .Where(v => v.Element("ForexBuying") != null && v.Element("ForexBuying").Value.Length > 0)
            .Select(v => new Currency
            {
                Code = v.Attribute("Kod").Value,
                Rate = decimal.Parse(v.Element("ForexBuying").Value.Replace('.', ','))
            }).ToList();
            return result.FirstOrDefault(s => s.Code == code).Rate;
        }

        public class Currency
        {
            public string Code { get; set; }
            public decimal Rate { get; set; }
        }
        private string addZero(int p)
        {
            if (p.ToString().Length == 1)
                return "0" + p;
            return p.ToString();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            lblDolar.Content = "";
            lblDolar.Content = GetRate("USD").ToString();
            CommandManager.InvalidateRequerySuggested();
            //listBox1.Items.MoveCurrentToLast();
            //listBox1.SelectedItem = listBox1.Items.CurrentItem;
            //listBox1.ScrollIntoView(listBox1.Items.CurrentItem);
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
                
            if (InternetKonrol())
            {
                DispatcherTimer dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();
            }
        }


    

        public bool InternetKonrol()
        {
            try
            {
                System.Net.Sockets.TcpClient Kontrol = new System.Net.Sockets.TcpClient("wwww.google.com.tr", 80);
                Kontrol.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
