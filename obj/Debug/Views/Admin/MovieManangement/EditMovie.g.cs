﻿#pragma checksum "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D3D1714697151A581DB8F5287F32242211CC6DCB5C5C9EACD0EB0C3DB2D6B44D"
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
using cinema_management.Views.Admin.MovieManangement;


namespace cinema_management.Views.Admin.MovieManangement {
    
    
    /// <summary>
    /// EditMovie
    /// </summary>
    public partial class EditMovie : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal cinema_management.Views.Admin.MovieManangement.EditMovie EditMovieWindow;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _Name;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox _Genre;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _Author;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox _Country;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _Duration;
        
        #line default
        #line hidden
        
        
        #line 240 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _Descripstion;
        
        #line default
        #line hidden
        
        
        #line 264 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgframe;
        
        #line default
        #line hidden
        
        
        #line 304 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Year;
        
        #line default
        #line hidden
        
        
        #line 360 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
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
            System.Uri resourceLocater = new System.Uri("/cinema-management;component/views/admin/moviemanangement/editmovie.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
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
            this.EditMovieWindow = ((cinema_management.Views.Admin.MovieManangement.EditMovie)(target));
            
            #line 17 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
            this.EditMovieWindow.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
            this.EditMovieWindow.PreviewKeyUp += new System.Windows.Input.KeyEventHandler(this.EditMovieWindow_PreviewKeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 75 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
            ((System.Windows.Controls.Button)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Button_MouseEnter_1);
            
            #line default
            #line hidden
            
            #line 76 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
            ((System.Windows.Controls.Button)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_MouseLeave_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this._Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this._Genre = ((System.Windows.Controls.ComboBox)(target));
            
            #line 139 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
            this._Genre.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this._Genre_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this._Author = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this._Country = ((System.Windows.Controls.ComboBox)(target));
            
            #line 190 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
            this._Country.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this._Country_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this._Duration = ((System.Windows.Controls.TextBox)(target));
            
            #line 207 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
            this._Duration.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Duration_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            this._Descripstion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.imgframe = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            this.Year = ((System.Windows.Controls.TextBox)(target));
            
            #line 310 "..\..\..\..\..\Views\Admin\MovieManangement\EditMovie.xaml"
            this.Year.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Year_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 11:
            this.prg = ((System.Windows.Controls.ProgressBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
