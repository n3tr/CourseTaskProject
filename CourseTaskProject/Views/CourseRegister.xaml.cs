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
    /// Interaction logic for CourseRegister.xaml
    /// </summary>
    public partial class CourseRegister : UserControl
    {
        private Courses _course;
        public CourseRegister()
        {
            InitializeComponent();
        }

        public Courses course
        {
            get { return _course; }
            set { _course = value; }
        }

        public void LoadData(Courses course)
        {
            var register = (from r in CourseData.db.Registers
                            where r.Courses == course
                            select r);

            this.CourseRegiserGrid.ItemsSource = register.ToList();
        }

        public void LoadData()
        {
            var register = (from r in CourseData.db.Registers
                            where r.Courses == this.course
                            select r);

            this.CourseRegiserGrid.ItemsSource = register.ToList();
        }
    }
}
