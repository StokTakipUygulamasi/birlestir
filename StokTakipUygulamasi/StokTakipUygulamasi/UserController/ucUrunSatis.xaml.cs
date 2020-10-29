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
    /// ucUrunSatis.xaml etkileşim mantığı
    /// </summary>
    public partial class ucUrunSatis : UserControl
    {
        public ucUrunSatis()
        {
            bool ali = false;
            


            InitializeComponent();
        }

        private void User_Control(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Convert.ToInt32(false).ToString());
        }
    }
}
