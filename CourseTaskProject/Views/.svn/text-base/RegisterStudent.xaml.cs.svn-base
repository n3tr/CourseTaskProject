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
    /// Interaction logic for RegisterStudent.xaml
    /// </summary>
    public partial class RegisterStudent : UserControl
    {
        private Courses _course;
        private Students _student;

        public RegisterStudent()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            AddStudentBth.IsEnabled = false;
            AddByCodeExp.IsExpanded = true;
            LoadGroupData();

        }

        public void LoadGroupData()
        {
            var group = (from g in CourseData.db.StudentGroup
                         select g);

            ComboBox_Group.ItemsSource = group.ToList();
        }

        public Courses course
        {
            get { return _course; }
            set { _course = value; }
        }

        public Students student
        {
            get { return _student; }
            set { _student = value; }
        }

        private void SearchStudent_Click(object sender, RoutedEventArgs e)
        {
            string searchTxt = studentCodeSearchTxt.Text;

            this.student = (from s in CourseData.db.Students
                                where s.StudentCode.Equals(searchTxt)
                                select s).FirstOrDefault();
            if (student != null)
            {
                StudentCodeTxt.Text = this.student.StudentCode;
                StudentFirstNameTxt.Text = this.student.StudentFirstName;
                StudentLastNameTxt.Text = this.student.StudentLastName;
                StudentGroupTxt.Text = this.student.StudentGroup.GroupTitle;
                AddStudentBth.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Can't Find Student\nPlease Try Again", "Can't Find");
                
            }
            
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            Registers register = (from r in CourseData.db.Registers
                                  where r.Students.Equals(this.student) && r.Courses.Equals(this.course)
                                  select r).FirstOrDefault();

            if (register == null)
            {
                register = new Registers();
                register.CourseID = this.course.CourseID;
                register.StudentID = this.student.StudentID;
                CourseData.db.Registers.InsertOnSubmit(register);
                CourseData.db.SubmitChanges();
                MessageBox.Show("Added Student to This Courses", "Suceed");
                this.Clear();
            }
            else
            {
                MessageBox.Show("Student is Already Added", "Duplicate Student");
            }
            
            
        }

        public void Clear()
        {
            studentCodeSearchTxt.Text = "";
            StudentCodeTxt.Text = "";
            StudentFirstNameTxt.Text = "";
            StudentLastNameTxt.Text = "";
            StudentGroupTxt.Text = "";
            AddStudentBth.IsEnabled = false;
        }

        private void AddStudentByGroup_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox_Group.SelectedIndex >= 0)
            {
                var student = (from s in CourseData.db.Students
                               where s.StudentGroup.Equals(ComboBox_Group.SelectedItem)
                               select s);
                /* Debug
                foreach (Students s in student)
                {
                    Console.WriteLine(s.StudentFirstName);
                }
                 * */
                var studentInCourse = (from r in CourseData.db.Registers
                                       where r.Courses.Equals(this.course)
                                       select r.Students);
                /* Debug
                foreach (Students s in studentInCourse)
                {
                    Console.WriteLine(s.StudentFirstName);
                }
                 * */
                var newStudentOnly = student.Except(studentInCourse);

                /* Debug
                foreach (Students s in newStudentOnly)
                {
                    Console.WriteLine(s.StudentFirstName);
                }
                 * */
                if (newStudentOnly.FirstOrDefault() != null)
                {
                    foreach (Students s in newStudentOnly)
                    {
                        Registers r = new Registers();
                        r.StudentID = s.StudentID;
                        r.CourseID = this.course.CourseID;
                        CourseData.db.Registers.InsertOnSubmit(r);
                    }
                    CourseData.db.SubmitChanges();
                    ComboBox_Group.SelectedIndex = -1;
                    MessageBox.Show("Added Student By Group", "Suceed");
                }
                else
                {
                    MessageBox.Show("this Group already add to this Course", "Alert");
                }
                
            }
            else
            {
                MessageBox.Show("Please Select Group to Add Student", "Error");
            }
           
        }

        
    }
}
