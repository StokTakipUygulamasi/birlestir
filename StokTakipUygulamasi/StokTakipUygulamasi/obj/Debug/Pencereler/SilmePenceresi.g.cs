﻿#pragma checksum "..\..\..\Pencereler\SilmePenceresi.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4196C043C847D500F5B3686635B6DCE9E1643405553AE20107EFFAA7597932FF"
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
    /// SilmePenceresi
    /// </summary>
    public partial class SilmePenceresi : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\Pencereler\SilmePenceresi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txtuyariYazi;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pencereler\SilmePenceresi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSilmeNedeni;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Pencereler\SilmePenceresi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Evet;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Pencereler\SilmePenceresi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Hayır;
        
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
            System.Uri resourceLocater = new System.Uri("/StokTakipUygulamasi;component/pencereler/silmepenceresi.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pencereler\SilmePenceresi.xaml"
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
            
            #line 9 "..\..\..\Pencereler\SilmePenceresi.xaml"
            ((StokTakipUygulamasi.Pencereler.SilmePenceresi)(target)).Loaded += new System.Windows.RoutedEventHandler(this.PencereLOaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtuyariYazi = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.txtSilmeNedeni = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btn_Evet = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\Pencereler\SilmePenceresi.xaml"
            this.btn_Evet.Click += new System.Windows.RoutedEventHandler(this.btnUrunEvet);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_Hayır = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Pencereler\SilmePenceresi.xaml"
            this.btn_Hayır.Click += new System.Windows.RoutedEventHandler(this.btnUrunHayir);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

