﻿#pragma checksum "..\..\..\Treenit.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DA1AA89FF67BC82D3F6EBECF7910805C9924ECAE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ohjelmisto_projekti;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Ohjelmisto_projekti {
    
    
    /// <summary>
    /// Treenit
    /// </summary>
    public partial class Treenit : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Treenit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Piilo;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Treenit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Maanantai;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Treenit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Keskiviikko;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Treenit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Torstai;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Treenit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Perjantai;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Treenit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Tiistai;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Treenit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Lauantai;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Treenit.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Sunnuntai;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Ohjelmisto_projekti;component/treenit.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Treenit.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\Treenit.xaml"
            ((Ohjelmisto_projekti.Treenit)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Piilo = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.Maanantai = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Treenit.xaml"
            this.Maanantai.Click += new System.Windows.RoutedEventHandler(this.Maanantai_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Keskiviikko = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Treenit.xaml"
            this.Keskiviikko.Click += new System.Windows.RoutedEventHandler(this.Keskiviikko_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Torstai = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Treenit.xaml"
            this.Torstai.Click += new System.Windows.RoutedEventHandler(this.Torstai_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Perjantai = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Treenit.xaml"
            this.Perjantai.Click += new System.Windows.RoutedEventHandler(this.Perjantai_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Tiistai = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Treenit.xaml"
            this.Tiistai.Click += new System.Windows.RoutedEventHandler(this.Tiistai_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Lauantai = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Treenit.xaml"
            this.Lauantai.Click += new System.Windows.RoutedEventHandler(this.Lauantai_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Sunnuntai = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Treenit.xaml"
            this.Sunnuntai.Click += new System.Windows.RoutedEventHandler(this.Sunnuntai_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

