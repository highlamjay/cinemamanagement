﻿#pragma checksum "..\..\..\..\..\Views\Admin\Import_ExportManagement\ImportManagement.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3EBAB79DD00EB032C37EA294A588B6916A95125E3BCDA21B122100C7CDE15810"
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
using cinema_management.Views.Admin.Import_ExportManagement;


namespace cinema_management.Views.Admin.Import_ExportManagement {
    
    
    /// <summary>
    /// ImportManagement
    /// </summary>
    public partial class ImportManagement : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\..\Views\Admin\Import_ExportManagement\ImportManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal cinema_management.Views.Admin.Import_ExportManagement.ImportManagement mainPage;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\Views\Admin\Import_ExportManagement\ImportManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FilterBox;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\..\Views\Admin\Import_ExportManagement\ImportManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbFilter;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\..\Views\Admin\Import_ExportManagement\ImportManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox filtercbb;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\..\Views\Admin\Import_ExportManagement\ImportManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbmonth;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\..\..\Views\Admin\Import_ExportManagement\ImportManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView _ListView;
        
        #line default
        #line hidden
        
        
        #line 219 "..\..\..\..\..\Views\Admin\Import_ExportManagement\ImportManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label result;
        
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
            System.Uri resourceLocater = new System.Uri("/cinema-management;component/views/admin/import_exportmanagement/importmanagement" +
                    ".xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Admin\Import_ExportManagement\ImportManagement.xaml"
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
            this.mainPage = ((cinema_management.Views.Admin.Import_ExportManagement.ImportManagement)(target));
            return;
            case 2:
            this.FilterBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 56 "..\..\..\..\..\Views\Admin\Import_ExportManagement\ImportManagement.xaml"
            this.FilterBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbbFilter = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.filtercbb = ((System.Windows.Controls.ComboBox)(target));
            
            #line 78 "..\..\..\..\..\Views\Admin\Import_ExportManagement\ImportManagement.xaml"
            this.filtercbb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cbbmonth = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this._ListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.result = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

