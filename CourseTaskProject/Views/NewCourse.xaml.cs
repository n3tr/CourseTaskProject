using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CourseTaskProject.Data;

namespace CourseTaskProject.Views
{
    /// <summary>
    /// Interaction logic for NewCourse.xaml
    /// </summary>
    public partial class NewCourse : UserControl
    {
        private int _CourseID = 0;
        public NewCourse()
        {
            InitializeComponent();
        }

        public int CourseID
        {
            get { return _CourseID; }
            set { _CourseID = value; }
        }

        public void Clear()
        {
            this.CourseID = 0;
            this.CourseCode.Text = "";
            this.CourseSection.Text = "";
            this.CourseTitle.Text = "";
            this.CourseDesc.Text = "";
        }
       
    }
}
