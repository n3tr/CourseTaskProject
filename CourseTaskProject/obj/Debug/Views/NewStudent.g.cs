﻿#pragma checksum "..\..\..\Views\NewStudent.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2E04245C699F8F05C2EBB2C35B27CD37"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// NewStudent
    /// </summary>
    public partial class NewStudent : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\Views\NewStudent.xaml"
        internal System.Windows.Controls.TextBox StudentCodeTxt;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Views\NewStudent.xaml"
        internal System.Windows.Controls.TextBox StudentFirstNameTxt;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Views\NewStudent.xaml"
        internal System.Windows.Controls.TextBox StudentLastNameTxt;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Views\NewStudent.xaml"
        internal System.Windows.Controls.ComboBox ComboGroup;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseTaskProject;component/views/newstudent.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\NewStudent.xaml"
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
            
            #line 4 "..\..\..\Views\NewStudent.xaml"
            ((CourseTaskProject.Views.NewStudent)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.StudentCodeTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.StudentFirstNameTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.StudentLastNameTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ComboGroup = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
