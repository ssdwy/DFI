﻿#pragma checksum "..\..\Materialbedarf.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F75A99C47A14B6EE742A0169ED0C805DE476B9052C28F825CDCE446292053C64"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using DFI_UE4_Gruppe11;
using ScottPlot;
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


namespace DFI_UE4_Gruppe11 {
    
    
    /// <summary>
    /// Materialbedarf
    /// </summary>
    public partial class Materialbedarf : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\Materialbedarf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Gew_BezeichnungTextbox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Materialbedarf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Gew_AdresseTextbox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Materialbedarf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Anzahl_PflanzeTextbox;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Materialbedarf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatumZeit_Von;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\Materialbedarf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatumZeit_bis;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\Materialbedarf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox WasserverbrauchTextBox;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\Materialbedarf.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DuengerverbrauchTextbox;
        
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
            System.Uri resourceLocater = new System.Uri("/DFI_UE4_Gruppe11;component/materialbedarf.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Materialbedarf.xaml"
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
            this.Gew_BezeichnungTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Gew_AdresseTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Anzahl_PflanzeTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.DatumZeit_Von = ((System.Windows.Controls.DatePicker)(target));
            
            #line 42 "..\..\Materialbedarf.xaml"
            this.DatumZeit_Von.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.Dayscount);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DatumZeit_bis = ((System.Windows.Controls.DatePicker)(target));
            
            #line 51 "..\..\Materialbedarf.xaml"
            this.DatumZeit_bis.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.Dayscount);
            
            #line default
            #line hidden
            return;
            case 6:
            this.WasserverbrauchTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.DuengerverbrauchTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
