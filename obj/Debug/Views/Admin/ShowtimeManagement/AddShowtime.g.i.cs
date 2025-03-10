﻿#pragma checksum "..\..\..\..\..\Views\Admin\ShowtimeManagement\AddShowtime.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "51DEFDE03343E39699B6DE2648C5ECFDBA288735CEFA7B0B181AC5A0F8D551A6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Microsoft.Xaml.Behaviors;
using Microsoft.Xaml.Behaviors.Core;
using Microsoft.Xaml.Behaviors.Input;
using Microsoft.Xaml.Behaviors.Layout;
using Microsoft.Xaml.Behaviors.Media;
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
using cinema_management.Views.Admin.ShowtimeManagement;


namespace cinema_management.Views.Admin.ShowtimeManagement {
    
    
    /// <summary>
    /// AddShowtime
    /// </summary>
    public partial class AddShowtime : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\..\Views\Admin\ShowtimeManagement\AddShowtime.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal cinema_management.Views.Admin.ShowtimeManagement.AddShowtime AddSuatChieu;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\..\..\Views\Admin\ShowtimeManagement\AddShowtime.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox _movieName;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\..\Views\Admin\ShowtimeManagement\AddShowtime.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker _movieDate;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\..\..\Views\Admin\ShowtimeManagement\AddShowtime.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.TimePicker _movieTime;
        
        #line default
        #line hidden
        
        
        #line 179 "..\..\..\..\..\Views\Admin\ShowtimeManagement\AddShowtime.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox _movieRoom;
        
        #line default
        #line hidden
        
        
        #line 193 "..\..\..\..\..\Views\Admin\ShowtimeManagement\AddShowtime.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _moviePrice;
        
        #line default
        #line hidden
        
        
        #line 247 "..\..\..\..\..\Views\Admin\ShowtimeManagement\AddShowtime.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label _desPrice;
        
        #line default
        #line hidden
        
        
        #line 310 "..\..\..\..\..\Views\Admin\ShowtimeManagement\AddShowtime.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar prg;
        
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
            System.Uri resourceLocater = new System.Uri("/cinema-management;component/views/admin/showtimemanagement/addshowtime.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Admin\ShowtimeManagement\AddShowtime.xaml"
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
            this.AddSuatChieu = ((cinema_management.Views.Admin.ShowtimeManagement.AddShowtime)(target));
            
            #line 17 "..\..\..\..\..\Views\Admin\ShowtimeManagement\AddShowtime.xaml"
            this.AddSuatChieu.PreviewKeyUp += new System.Windows.Input.KeyEventHandler(this.AddSuatChieu_PreviewKeyUp);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\..\..\Views\Admin\ShowtimeManagement\AddShowtime.xaml"
            this.AddSuatChieu.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.AddSuatChieu_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 61 "..\..\..\..\..\Views\Admin\ShowtimeManagement\AddShowtime.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            
            #line 66 "..\..\..\..\..\Views\Admin\ShowtimeManagement\AddShowtime.xaml"
            ((System.Windows.Controls.Button)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Button_MouseEnter_1);
            
            #line default
            #line hidden
            
            #line 67 "..\..\..\..\..\Views\Admin\ShowtimeManagement\AddShowtime.xaml"
            ((System.Windows.Controls.Button)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_MouseLeave_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this._movieName = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this._movieDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this._movieTime = ((MaterialDesignThemes.Wpf.TimePicker)(target));
            return;
            case 6:
            this._movieRoom = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this._moviePrice = ((System.Windows.Controls.TextBox)(target));
            
            #line 192 "..\..\..\..\..\Views\Admin\ShowtimeManagement\AddShowtime.xaml"
            this._moviePrice.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this._moviePrice_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 194 "..\..\..\..\..\Views\Admin\ShowtimeManagement\AddShowtime.xaml"
            this._moviePrice.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this._moviePrice_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this._desPrice = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.prg = ((System.Windows.Controls.ProgressBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

