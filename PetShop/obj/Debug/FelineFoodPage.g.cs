﻿#pragma checksum "..\..\FelineFoodPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8C98615BDDB994F8A729A94BBD21EBE30F21C2C1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PetShop;
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


namespace PetShop {
    
    
    /// <summary>
    /// FelineFoodPage
    /// </summary>
    public partial class FelineFoodPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\FelineFoodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label menubarCartTotal;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\FelineFoodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label catFoodLbl;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\FelineFoodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label panFoodLbl;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\FelineFoodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox catFoodCB;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\FelineFoodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox PanFoodCB;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\FelineFoodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addToCartCBtn;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\FelineFoodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button placeOrderCBtn;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\FelineFoodPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backCBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/PetShop;component/felinefoodpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FelineFoodPage.xaml"
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
            this.menubarCartTotal = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.catFoodLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.panFoodLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.catFoodCB = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.PanFoodCB = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.addToCartCBtn = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\FelineFoodPage.xaml"
            this.addToCartCBtn.Click += new System.Windows.RoutedEventHandler(this.addToCartCBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.placeOrderCBtn = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\FelineFoodPage.xaml"
            this.placeOrderCBtn.Click += new System.Windows.RoutedEventHandler(this.placeOrderCBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.backCBtn = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\FelineFoodPage.xaml"
            this.backCBtn.Click += new System.Windows.RoutedEventHandler(this.backCBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

