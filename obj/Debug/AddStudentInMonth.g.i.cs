﻿#pragma checksum "..\..\AddStudentInMonth.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "075BD39C2E5D0B9C573FE7CD72F296D627DB5C91324C10C976CB847DF218B50D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Record;
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


namespace Record {
    
    
    /// <summary>
    /// AddStudentInMonth
    /// </summary>
    public partial class AddStudentInMonth : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\AddStudentInMonth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbGroups;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\AddStudentInMonth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbMonth;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\AddStudentInMonth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbYears;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\AddStudentInMonth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtAdd;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\AddStudentInMonth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtBack;
        
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
            System.Uri resourceLocater = new System.Uri("/Record;component/addstudentinmonth.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddStudentInMonth.xaml"
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
            this.CbGroups = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.CbMonth = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.CbYears = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.BtAdd = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\AddStudentInMonth.xaml"
            this.BtAdd.Click += new System.Windows.RoutedEventHandler(this.BtAdd_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtBack = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\AddStudentInMonth.xaml"
            this.BtBack.Click += new System.Windows.RoutedEventHandler(this.BtBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

