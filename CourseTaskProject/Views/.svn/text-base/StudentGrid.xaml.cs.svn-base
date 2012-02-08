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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CourseTaskProject.Data;

namespace CourseTaskProject.Views
{
    /// <summary>
    /// Interaction logic for StudentGrid.xaml
    /// </summary>
    public partial class StudentGrid : UserControl
    {
        public StudentGrid()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            var student = (from s in CourseData.db.Students

                           orderby s.GroupID ,s.StudentCode
                          select s
                          );
            studentGrid.ItemsSource = student.ToList();
        }
    }
}
