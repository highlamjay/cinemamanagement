﻿#pragma checksum "..\..\..\..\..\Views\Staff\OrderFoodWindow\FoodPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7E98B775F80D299F3684F983271C3DECFE4E29F4A6022DE013B1CF2ED57E19F7"
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
using cinema_management.Views.Staff.OrderFoodWindow;


namespace cinema_management.Views.Staff.OrderFoodWindow {
    
    
    /// <summary>
    /// FoodPage
    /// </summary>
    public partial class FoodPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\..\Views\Staff\OrderFoodWindow\FoodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal cinema_management.Views.Staff.OrderFoodWindow.FoodPage Food_Page;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\..\..\Views\Staff\OrderFoodWindow\FoodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Card all;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\..\..\Views\Staff\OrderFoodWindow\FoodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Card food;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\..\..\..\Views\Staff\OrderFoodWindow\FoodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Card drink;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\..\..\..\Views\Staff\OrderFoodWindow\FoodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbxMenuProduct;
        
        #line default
        #line hidden
        
        
        #line 348 "..\..\..\..\..\Views\Staff\OrderFoodWindow\FoodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvOrderList;
        
        #line default
        #line hidden
        
        
        #line 525 "..\..\..\..\..\Views\Staff\OrderFoodWindow\FoodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblSum;
        
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
            System.Uri resourceLocater = new System.Uri("/cinema-management;component/views/staff/orderfoodwindow/foodpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Staff\OrderFoodWindow\FoodPage.xaml"
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
            this.Food_Page = ((cinema_management.Views.Staff.OrderFoodWindow.FoodPage)(target));
            return;
            case 2:
            this.all = ((MaterialDesignThemes.Wpf.Card)(target));
            return;
            case 3:
            this.food = ((MaterialDesignThemes.Wpf.Card)(target));
            return;
            case 4:
            this.drink = ((MaterialDesignThemes.Wpf.Card)(target));
            return;
            case 5:
            this.lbxMenuProduct = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.lvOrderList = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.tblSum = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
