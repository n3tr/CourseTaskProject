﻿#pragma checksum "..\..\..\Views\AssessmentGrid.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1BA75E5843D1FFE21A9E3DA8BA193989"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.Ribbon;
using Microsoft.Windows.Themes;
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


namespace CourseTaskProject.Views {
    
    
    /// <summary>
    /// AssessmentGrid
    /// </summary>
    public partial class AssessmentGrid : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Views\AssessmentGrid.xaml"
        internal System.Windows.Controls.ComboBox assessComboBox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Views\AssessmentGrid.xaml"
        internal Microsoft.Windows.Controls.DataGrid ScoreGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CourseTaskProject;component/views/assessmentgrid.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\AssessmentGrid.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 5 "..\..\..\Views\AssessmentGrid.xaml"
            ((CourseTaskProject.Views.AssessmentGrid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.assessComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 16 "..\..\..\Views\AssessmentGrid.xaml"
            this.assessComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.AssessComboBoxSelect_Change);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 17 "..\..\..\Views\AssessmentGrid.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\Views\AssessmentGrid.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ScoreGrid = ((Microsoft.Windows.Controls.DataGrid)(target));
            
            #line 24 "..\..\..\Views\AssessmentGrid.xaml"
            this.ScoreGrid.RowEditEnding += new System.EventHandler<Microsoft.Windows.Controls.DataGridRowEditEndingEventArgs>(this.EditScore_Ended);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}