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
    /// Interaction logic for NewStudent.xaml
    /// </summary>
    public partial class NewStudent : UserControl
    {
        private int _StudentID = 0;
        public NewStudent()
        {
            InitializeComponent();
        }

        public int StudentID
        {
            get { return _StudentID; }
            set { _StudentID = value; }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            var group = (from g in CourseData.db.StudentGroup
                         orderby g.GroupTitle
                         select g);
            ComboGroup.ItemsSource = group.ToList() ;
        }

        public void Clear()
        {
            this.StudentID = 0;
            this.StudentCodeTxt.Text = "";
            this.StudentFirstNameTxt.Text = "";
            this.StudentLastNameTxt.Text = "";
            this.ComboGroup.SelectedIndex = -1;
        }
    }
}
