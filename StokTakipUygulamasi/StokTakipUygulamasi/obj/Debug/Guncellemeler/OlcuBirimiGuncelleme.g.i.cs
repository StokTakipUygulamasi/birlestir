﻿#pragma checksum "..\..\..\Guncellemeler\OlcuBirimiGuncelleme.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7EA476AFB96FDA23C9109734E3D542625B375FC2FA5BAA6C4E2E72838A849275"
//------------------------------------------------------------------------------
// <auto-generated>
//     Bu kod araç tarafından oluşturuldu.
//     Çalışma Zamanı Sürümü:4.0.30319.42000
//
//     Bu dosyada yapılacak değişiklikler yanlış davranışa neden olabilir ve
//     kod yeniden oluşturulursa kaybolur.
// </auto-generated>
//------------------------------------------------------------------------------

using StokTakipUygulamasi.Guncellemeler;
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


namespace StokTakipUygulamasi.Guncellemeler {
    
    
    /// <summary>
    /// OlcuBirimiGuncelleme
    /// </summary>
    public partial class OlcuBirimiGuncelleme : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 51 "..\..\..\Guncellemeler\OlcuBirimiGuncelleme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEskiOlcubirimiAdi;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Guncellemeler\OlcuBirimiGuncelleme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtYeniOlcuBirimiAdi;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Guncellemeler\OlcuBirimiGuncelleme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_OlcuBirimiGuncelle;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Guncellemeler\OlcuBirimiGuncelleme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton btn_Bilgi;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Guncellemeler\OlcuBirimiGuncelleme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnKapat;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Guncellemeler\OlcuBirimiGuncelleme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup popup_bilgi;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Guncellemeler\OlcuBirimiGuncelleme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtBilgiPenceresi;
        
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
            System.Uri resourceLocater = new System.Uri("/StokTakipUygulamasi;component/guncellemeler/olcubirimiguncelleme.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Guncellemeler\OlcuBirimiGuncelleme.xaml"
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
            this.txtEskiOlcubirimiAdi = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtYeniOlcuBirimiAdi = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btn_OlcuBirimiGuncelle = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\Guncellemeler\OlcuBirimiGuncelleme.xaml"
            this.btn_OlcuBirimiGuncelle.Click += new System.Windows.RoutedEventHandler(this.btn_OlcuBirimiGuncelle_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_Bilgi = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 59 "..\..\..\Guncellemeler\OlcuBirimiGuncelleme.xaml"
            this.btn_Bilgi.Click += new System.Windows.RoutedEventHandler(this.btn_Bilgi_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnKapat = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\Guncellemeler\OlcuBirimiGuncelleme.xaml"
            this.btnKapat.Click += new System.Windows.RoutedEventHandler(this.btnKapat_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.popup_bilgi = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 7:
            this.txtBilgiPenceresi = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
