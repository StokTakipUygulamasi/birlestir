﻿#pragma checksum "..\..\..\Pencereler\MusteriSec.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6264FC12BF81B55A80E6078FD0F0B4B0F0E78E033F56E3CCE3BDB68FF69482BC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Bu kod araç tarafından oluşturuldu.
//     Çalışma Zamanı Sürümü:4.0.30319.42000
//
//     Bu dosyada yapılacak değişiklikler yanlış davranışa neden olabilir ve
//     kod yeniden oluşturulursa kaybolur.
// </auto-generated>
//------------------------------------------------------------------------------

using StokTakipUygulamasi.Pencereler;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace StokTakipUygulamasi.Pencereler {
    
    
    /// <summary>
    /// MusteriSec
    /// </summary>
    public partial class MusteriSec : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\Pencereler\MusteriSec.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton btn_Bilgi;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Pencereler\MusteriSec.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnKapat;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Pencereler\MusteriSec.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtg_MusteriListesi;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\Pencereler\MusteriSec.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup popup_bilgi;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\Pencereler\MusteriSec.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtBilgiPenceresi;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\Pencereler\MusteriSec.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_MusteriSec;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/StokTakipUygulamasi;component/pencereler/musterisec.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pencereler\MusteriSec.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\Pencereler\MusteriSec.xaml"
            ((StokTakipUygulamasi.Pencereler.MusteriSec)(target)).Loaded += new System.Windows.RoutedEventHandler(this.User_Kontrol);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_Bilgi = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 44 "..\..\..\Pencereler\MusteriSec.xaml"
            this.btn_Bilgi.Click += new System.Windows.RoutedEventHandler(this.btn_Bilgi_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnKapat = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\Pencereler\MusteriSec.xaml"
            this.btnKapat.Click += new System.Windows.RoutedEventHandler(this.btnKapat_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dtg_MusteriListesi = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.popup_bilgi = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 6:
            this.txtBilgiPenceresi = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.btn_MusteriSec = ((System.Windows.Controls.Button)(target));
            
            #line 125 "..\..\..\Pencereler\MusteriSec.xaml"
            this.btn_MusteriSec.Click += new System.Windows.RoutedEventHandler(this.btn_MusteriEkle_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

