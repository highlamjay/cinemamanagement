﻿#pragma checksum "..\..\..\..\..\Views\Admin\ProductManagement\EditProduct.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A61A096778BA5C787FFF6EF05A60B0901A51C609F7C3173051FF200DA79BF48D"
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
using cinema_management.Views.Admin.ProductManagement;


namespace cinema_management.Views.Admin.ProductManagement {
    
    
    /// <summary>
    /// EditProduct
    /// </summary>
    public partial class EditProduct : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\..\Views\Admin\ProductManagement\EditProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal cinema_management.Views.Admin.ProductManagement.EditProduct EditFoodWd;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\..\Views\Admin\ProductManagement\EditProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _displayName;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\..\..\Views\Admin\ProductManagement\EditProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox _category;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\..\..\Views\Admin\ProductManagement\EditProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _price;
        
        #line default
        #line hidden
        
        
        #line 154 "..\..\..\..\..\Views\Admin\ProductManagement\EditProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image EditImage;
        
        #line default
        #line hidden
        
        
        #line 234 "..\..\..\..\..\Views\Admin\ProductManagement\EditProduct.xaml"
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
            System.Uri resourceLocater = new System.Uri("/cinema-management;component/views/admin/productmanagement/editproduct.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Admin\ProductManagement\EditProduct.xaml"
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
            this.EditFoodWd = ((cinema_management.Views.Admin.ProductManagement.EditProduct)(target));
            
            #line 22 "..\..\..\..\..\Views\Admin\ProductManagement\EditProduct.xaml"
            this.EditFoodWd.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.EditFoodWd_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this._displayName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this._category = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this._price = ((System.Windows.Controls.TextBox)(target));
            
            #line 135 "..\..\..\..\..\Views\Admin\ProductManagement\EditProduct.xaml"
            this._price.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this._price_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 136 "..\..\..\..\..\Views\Admin\ProductManagement\EditProduct.xaml"
            this._price.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.EditImage = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.prg = ((System.Windows.Controls.ProgressBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

