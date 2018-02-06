﻿#pragma checksum "..\..\SongTile.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77CA71FFA519ACE5B35FD9AB24A4B290E1767625"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
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


namespace Mp3Wiki {
    
    
    /// <summary>
    /// SongTile
    /// </summary>
    public partial class SongTile : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\SongTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Mp3Wiki.SongTile ucTile;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\SongTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.Tile tile;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\SongTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TileGrid;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\SongTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition clmImage;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\SongTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition clmDetails;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\SongTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ColumnDefinition clmCommands;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\SongTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgAlbumArt;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\SongTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdDetails;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\SongTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtSongTitle;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\SongTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtSongAlbum;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\SongTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider PlayerSlider;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\SongTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.ProgressRing PlayProgressRing;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\SongTile.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlay;
        
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
            System.Uri resourceLocater = new System.Uri("/Mp3Wiki;component/songtile.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SongTile.xaml"
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
            this.ucTile = ((Mp3Wiki.SongTile)(target));
            return;
            case 2:
            this.tile = ((MahApps.Metro.Controls.Tile)(target));
            return;
            case 3:
            this.TileGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.clmImage = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 5:
            this.clmDetails = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 6:
            this.clmCommands = ((System.Windows.Controls.ColumnDefinition)(target));
            return;
            case 7:
            this.imgAlbumArt = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            this.grdDetails = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.txtSongTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.txtSongAlbum = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.PlayerSlider = ((System.Windows.Controls.Slider)(target));
            return;
            case 12:
            this.PlayProgressRing = ((MahApps.Metro.Controls.ProgressRing)(target));
            return;
            case 13:
            this.btnPlay = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\SongTile.xaml"
            this.btnPlay.Click += new System.Windows.RoutedEventHandler(this.btnPlay_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

