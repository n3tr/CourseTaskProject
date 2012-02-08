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
    /// Interaction logic for CourseGridView.xaml
    /// </summary>
    public partial class CourseGridView : UserControl
    {
       
        public CourseGridView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            var course = (from c in CourseData.db.Courses
                          orderby c.CourseID
                          select c
                          );
            CourseGrid.ItemsSource = course.ToList() ;
        }

        private void CourseGrid_RowEditEnding(object sender, Microsoft.Windows.Controls.DataGridRowEditEndingEventArgs e)
        {
            try
            {
                CourseData.db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Courses course = e.Row.Item as Courses;
                try
                {
                    CourseData.db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, course);
                }
                catch (Exception ex2)
                {
                    Console.WriteLine(ex2.Message);
                }
                Console.WriteLine(ex.Message);
            }
        }
    }
}
