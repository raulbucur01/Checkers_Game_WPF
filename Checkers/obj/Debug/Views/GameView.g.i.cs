﻿#pragma checksum "..\..\..\Views\GameView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3C16C5DF7176D6C7B138B2A286ECFAAFD912316F5DDDBFF6BD743724D5E5C8C2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Checkers.Converters;
using Checkers.ViewModels;
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


namespace Checkers.Views {
    
    
    /// <summary>
    /// GameView
    /// </summary>
    public partial class GameView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 67 "..\..\..\Views\GameView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid BoardGrid;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Views\GameView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.UniformGrid HighlightGrid;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Views\GameView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.UniformGrid PieceGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/Checkers;component/views/gameview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\GameView.xaml"
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
            this.BoardGrid = ((System.Windows.Controls.Grid)(target));
            
            #line 67 "..\..\..\Views\GameView.xaml"
            this.BoardGrid.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.BoardGrid_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.HighlightGrid = ((System.Windows.Controls.Primitives.UniformGrid)(target));
            return;
            case 3:
            this.PieceGrid = ((System.Windows.Controls.Primitives.UniformGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

