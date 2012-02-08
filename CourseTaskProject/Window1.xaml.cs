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
using System.Collections;
using Microsoft.Windows.Controls;
using CourseTaskProject.Views;
using Microsoft.Windows.Controls.Ribbon;

namespace CourseTaskProject
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : RibbonWindow
    {

        #region Main Application Field Region

        CTData _db = new CTData(App.ConnectionString);
        List<UIElement> uiList = new List<UIElement>();
        CourseGridView courseView = new CourseGridView();
        NewCourse newCourse = new NewCourse();
        ManageGroup manageGroupView = new ManageGroup();
        StudentGrid studentView = new StudentGrid();
        NewStudent newStudent = new NewStudent();
        CourseRegister courseRegister = new CourseRegister();
        RegisterStudent registerStudent = new RegisterStudent();
        AssessmentGrid assessmentGrid = new AssessmentGrid();
        ManageAssessment manageAssessment = new ManageAssessment();

        #endregion

        #region Main Region

        public Window1()
        {
            InitializeComponent();
        }

        // ===================================================
        // This Method will call when Application is starting
        // ===================================================
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //TODO: To Enable later
            
            ReportTab.IsEnabled = false;


            uiList.Add(courseView);
            uiList.Add(newCourse);
            uiList.Add(manageGroupView);
            uiList.Add(studentView);
            uiList.Add(newStudent);
            uiList.Add(courseRegister);
            uiList.Add(registerStudent);
            uiList.Add(assessmentGrid);
            uiList.Add(manageAssessment);

            foreach (UIElement ui in uiList)
            {
                MainContent.Children.Add(ui);
            }


            ShowView(courseView);
        }
        #endregion

        // =======================
        // Utility Function Region
        // =======================
        #region Utility Function

        //==========================================
        // This Method Will Show Only View Parameter
        // =========================================
        private void ShowView(UIElement view)
        {
            foreach (UIElement ui in uiList)
            {
                if (ui == view)
                {
                    ui.Visibility = Visibility.Visible;
                    continue;
                }
                ui.Visibility = Visibility.Collapsed;
            }
        }

        // ====================================================
        // This Method Will Control About Ribbon Tab and Button
        // First Para is Show and secoend para is Collapse
        // ====================================================
        private void VisibilityAndCollapsedUI(UIElement[] _viUI, UIElement[] _coUI)
        {
            foreach (UIElement ui in _viUI)
            {
                ui.Visibility = Visibility.Visible;
            }
            foreach (UIElement ui in _coUI)
            {
                ui.Visibility = Visibility.Collapsed;
            }
        }

        // =============================
        // Exit Application Button Click
        // =============================
        private void Exit_Click(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
       
        // ============================
        // Course Tab Controler Region
        // ============================
        #region Course Tab Controller

        // =====================================
        // Call when select Course Tab on Ribbon
        // =====================================
        private void CourseTab_Select(object sender, RoutedEventArgs e)
        {
            ShowView(courseView);
        }

        // ============================
        // New Couse Button Click Event
        // ============================
        private void RibbonNewCourse_Click(object sender, ExecutedRoutedEventArgs e)
        {

            ShowView(newCourse);
            NewCourseTab.Label = "New Course";

            UIElement[] viUI = { NewCourseTab, ClearCourseField };
            UIElement[] coUI = { courseTab, studentTab };
            VisibilityAndCollapsedUI(viUI, coUI);

            ribbonControl.SelectedTab = NewCourseTab;

        }

        /*
         * Add Course Button Click
         */
        private void RibbonAddCourse_Click(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                if (newCourse.CourseID == 0)
                {

                    if (newCourse.CourseCode.Text != "")
                    {

                        Courses course = new Courses();

                        course.CourseCode = newCourse.CourseCode.Text;
                        course.CourseSection = newCourse.CourseSection.Text;
                        course.CourseTitle = newCourse.CourseTitle.Text;
                        course.CourseDesc = newCourse.CourseDesc.Text;
                        CourseData.db.Courses.InsertOnSubmit(course);
                        CourseData.db.SubmitChanges();

                        courseView.LoadData();
                        newCourse.Clear();

                        // UI Control
                        ribbonControl.SelectedTab = courseTab;
                        ShowView(courseView);
                        UIElement[] viUI = { courseTab, studentTab };
                        UIElement[] coUI = { NewCourseTab };
                        this.VisibilityAndCollapsedUI(viUI, coUI);

                        MessageBox.Show("Added  Course", "Course");
                    }
                    else
                    {
                        MessageBox.Show("Course Code Can't Empty");
                    }
                }
                else
                {
                    if (newCourse.CourseCode.Text != "")
                    {

                        Courses course = (from c in CourseData.db.Courses
                                          where c.CourseID == Int32.Parse(courseView.CourseGrid.SelectedValue.ToString())
                                          select c).FirstOrDefault();

                        course.CourseID = newCourse.CourseID;
                        course.CourseCode = newCourse.CourseCode.Text;
                        course.CourseSection = newCourse.CourseSection.Text;
                        course.CourseTitle = newCourse.CourseTitle.Text;
                        course.CourseDesc = newCourse.CourseDesc.Text;
                        CourseData.db.SubmitChanges();
                        ribbonControl.SelectedTab = courseTab;
                        newCourse.Clear();
                        ShowView(courseView);

                        UIElement[] viUI = { courseTab, studentTab };
                        UIElement[] coUI = { NewCourseTab };
                        VisibilityAndCollapsedUI(viUI, coUI);
                        MessageBox.Show("Modified Course", "Course");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void RibbonDeleteCourse_Click(object sender, ExecutedRoutedEventArgs e)
        {
            if (courseView.CourseGrid.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Delete Course Confirm", "Delete Course", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var n = (from c in CourseData.db.Courses
                             where c.CourseID == Int32.Parse(courseView.CourseGrid.SelectedValue.ToString())
                             select c).Count();
                    if (n > 0)
                    {
                        Courses course = (from c in CourseData.db.Courses
                                      where c.CourseID == Int32.Parse(courseView.CourseGrid.SelectedValue.ToString())
                                      select c).FirstOrDefault();
                        int id = course.CourseID;
                        CourseData.db.Courses.DeleteOnSubmit(course);
                        CourseData.db.SubmitChanges();
                        courseView.LoadData();

                        var reg = (from r in CourseData.db.Registers
                                   where r.CourseID == id
                                   select r);

                        if (reg.Count() > 0)
                        {
                            CourseData.db.Registers.DeleteAllOnSubmit(reg);
                            CourseData.db.SubmitChanges();
                        }

                        var ass = (from a in CourseData.db.Assessments
                                   where a.CourseID == id
                                   select a);
                        if (ass.Count() > 0)
                        {
                            CourseData.db.Assessments.DeleteAllOnSubmit(ass);
                            CourseData.db.SubmitChanges();
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Please Select Course to Delete", "Can't Delete");
            }

        }

        private void RibbonClearCourse_Click(object sender, ExecutedRoutedEventArgs e)
        {
            newCourse.Clear();
        }

        private void RibbonCancelCourse_Click(object sender, ExecutedRoutedEventArgs e)
        {
            newCourse.Clear();
            ShowView(courseView);
            ribbonControl.SelectedTab = courseTab;

            UIElement[] coUI = { NewCourseTab };
            UIElement[] viUI = { courseTab, studentTab };
            VisibilityAndCollapsedUI(viUI, coUI);

        }

        private void RibbonEditCourse_Click(object sender, ExecutedRoutedEventArgs e)
        {
            newCourse.Clear();

            if (courseView.CourseGrid.SelectedIndex >= 0)
            {
                Courses course = (from c in CourseData.db.Courses
                                  where c.CourseID == Int32.Parse(courseView.CourseGrid.SelectedValue.ToString())
                                  select c).FirstOrDefault();

                newCourse.CourseCode.Text = course.CourseCode;
                newCourse.CourseSection.Text = course.CourseSection;
                newCourse.CourseTitle.Text = course.CourseTitle;
                newCourse.CourseDesc.Text = course.CourseDesc;
                newCourse.CourseID = course.CourseID;
                NewCourseTab.Label = "Edit Course";

                course = null;

                ShowView(newCourse);
                ribbonControl.SelectedTab = NewCourseTab;

                UIElement[] coUI = { ClearCourseField, courseTab, studentTab };
                UIElement[] viUI = { NewCourseTab };
                VisibilityAndCollapsedUI(viUI, coUI);

            }
            else
            {
                MessageBox.Show("Select Course to edit", "Course");
            }
        }

        #endregion


        // ============================
        // Student Tab Controller Region
        // ============================
        #region Student Tab Region

        //=============================
        // Call When select Student Tab
        // =============================
        private void StudentTab_Select(object sender, RoutedEventArgs e)
        {
            ShowView(studentView);
        }

        // =====================================================
        // Call When Click ManageButton In Student Tab On Ribbon
        // =====================================================
        private void RibbonManageGroup_Click(object sender, ExecutedRoutedEventArgs e)
        {
            ShowView(manageGroupView);
            ribbonControl.SelectedTab = ManageGroupTab;
            UIElement[] coUI = { courseTab, studentTab };
            UIElement[] viUI = { ManageGroupTab };
            this.VisibilityAndCollapsedUI(viUI, coUI);
        }

        // ===============================================================
        // Call When Click ExitGroupManage Button In Student Tab On Ribbon
        // ===============================================================
        private void RibbonExitManage_Click(object sender, ExecutedRoutedEventArgs e)
        {
            manageGroupView.Clear();
            manageGroupView.ListGroup.SelectedIndex = -1;
            UIElement[] viUI = { courseTab, studentTab };
            UIElement[] coUI = { ManageGroupTab };
            this.VisibilityAndCollapsedUI(viUI, coUI);
            ShowView(studentView);
            ribbonControl.SelectedTab = studentTab;

        }
        
        // =============================================
        // This Method will call for Create New Student
        // =============================================
        private void RibbonNewStudent_Click(object sender, ExecutedRoutedEventArgs e)
        {
            ShowView(newStudent);
            NewStudentTab.Label = "New Student";
            newStudent.LoadData();
            newStudent.ComboGroup.SelectedIndex = 0;
            UIElement[] viUI = { NewStudentTab };
            UIElement[] coUI = { courseTab, studentTab };
            VisibilityAndCollapsedUI(viUI, coUI);

            ribbonControl.SelectedTab = NewStudentTab;
        }

        // =============================================
        // This Method To Confirm for Create Student
        // ==============================================
        private void RibbonAddStudent_Click(object sender, ExecutedRoutedEventArgs e)
        {
            if (newStudent.ComboGroup.SelectedIndex >= 0)
            {
                try
                {
                    if (newStudent.StudentID == 0)
                    {

                        if (newStudent.StudentCodeTxt.Text != "")
                        {

                            Students student = new Students();

                            student.StudentCode = newStudent.StudentCodeTxt.Text;
                            student.StudentFirstName = newStudent.StudentFirstNameTxt.Text;
                            student.StudentLastName = newStudent.StudentLastNameTxt.Text;
                            student.GroupID = Int32.Parse(newStudent.ComboGroup.SelectedValue.ToString());

                            CourseData.db.Students.InsertOnSubmit(student);
                            CourseData.db.SubmitChanges();

                            studentView.LoadData();
                            newStudent.Clear();

                            // UI Control
                            ribbonControl.SelectedTab = studentTab;
                            ShowView(studentView);
                            UIElement[] viUI = { courseTab, studentTab };
                            UIElement[] coUI = { NewStudentTab };
                            this.VisibilityAndCollapsedUI(viUI, coUI);

                            MessageBox.Show("Added  Student", "Course");
                        }
                        else
                        {
                            MessageBox.Show("Student Code Can't Empty");
                        }
                    }
                    else
                    {
                        if (newStudent.StudentCodeTxt.Text != "")
                        {

                            Students student = (from s in CourseData.db.Students
                                                where s.StudentID == Int32.Parse(studentView.studentGrid.SelectedValue.ToString())
                                                select s).FirstOrDefault();

                            student.StudentID = newStudent.StudentID;
                            student.StudentCode = newStudent.StudentCodeTxt.Text;
                            student.StudentFirstName = newStudent.StudentFirstNameTxt.Text;
                            student.StudentLastName = newStudent.StudentLastNameTxt.Text;
                            student.StudentGroup = newStudent.ComboGroup.SelectedItem as StudentGroup;
                            CourseData.db.SubmitChanges();
                            ribbonControl.SelectedTab = studentTab;
                            newStudent.Clear();
                            ShowView(studentView);
                            studentView.LoadData();
                            UIElement[] viUI = { courseTab, studentTab };
                            UIElement[] coUI = { NewStudentTab };
                            VisibilityAndCollapsedUI(viUI, coUI);
                            MessageBox.Show("Modified Student", "Student");

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Select Group");
            }

        }

        // =========================
        // For Cancel Create Student
        // =========================
        private void RibbonCancelStudent_Click(object sender, ExecutedRoutedEventArgs e)
        {
            newStudent.Clear();

            ShowView(studentView);
            ribbonControl.SelectedTab = studentTab;

            UIElement[] coUI = { NewStudentTab };
            UIElement[] viUI = { courseTab, studentTab };
            VisibilityAndCollapsedUI(viUI, coUI);
        }

        // ================================================================
        // Method to delete Student when select Student in Student DataGrid
        // ================================================================
        private void RibbonDeleteStudent_Click(object sender, ExecutedRoutedEventArgs e)
        {
            if (studentView.studentGrid.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Delete Student Confirm", "Delete Student", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var n = (from g in CourseData.db.Students
                             where g.StudentID == Int32.Parse(studentView.studentGrid.SelectedValue.ToString())
                             select g).Count();
                    if (n > 0)
                    {
                        Students student = (from g in CourseData.db.Students
                                       where g.StudentID == Int32.Parse(studentView.studentGrid.SelectedValue.ToString())
                                       select g).FirstOrDefault();
                        int id = student.StudentID;
                        CourseData.db.Students.DeleteOnSubmit(student);
                        CourseData.db.SubmitChanges();
                        MessageBox.Show("Deleted Student");
                        studentView.LoadData();

                        var reg = (from r in CourseData.db.Registers
                                   where r.StudentID == id
                                   select r);
                        
                        if (reg.Count() > 0)
                        {
                            CourseData.db.Registers.DeleteAllOnSubmit(reg);
                            CourseData.db.SubmitChanges();
                        }

                        var ass = (from a in CourseData.db.Scores
                                   where a.StudentID == id
                                   select a);
                        if (ass.Count() > 0)
                        {
                            CourseData.db.Scores.DeleteAllOnSubmit(ass);
                            CourseData.db.SubmitChanges();
                        }
                           

                    }
                }

            }
            else
            {
                MessageBox.Show("Please Select Student to Delete", "Can't Delete");
            }
        }

        // ================================================================
        // Method To Edit Student When selected student in Stuednt DataGrid
        // ================================================================
        private void RibbonEditStudent_Click(object sender, ExecutedRoutedEventArgs e)
        {
            newStudent.Clear();
            newStudent.LoadData();

            if (studentView.studentGrid.SelectedIndex >= 0)
            {
                Students student = (from s in CourseData.db.Students
                                    where s.StudentID == Int32.Parse(studentView.studentGrid.SelectedValue.ToString())
                                    select s).FirstOrDefault();

                newStudent.StudentCodeTxt.Text = student.StudentCode;
                newStudent.StudentFirstNameTxt.Text = student.StudentFirstName;
                newStudent.StudentLastNameTxt.Text = student.StudentLastName;
                newStudent.ComboGroup.SelectedValue = student.StudentGroup.GroupID;
                newStudent.StudentID = student.StudentID;
                NewStudentTab.Label = "Edit Student";

                student = null;

                ShowView(newStudent);
                ribbonControl.SelectedTab = NewStudentTab;

                UIElement[] coUI = { courseTab, studentTab };
                UIElement[] viUI = { NewStudentTab };
                VisibilityAndCollapsedUI(viUI, coUI);

            }
            else
            {
                MessageBox.Show("Select Student to edit", "Course");
            }
        }

        #endregion

        // ===================================
        // Course Detail Tab Controller Region
        // ===================================
        #region CourseDetailTab

        private void RibbonViewCourseDetail_Click(object sender, ExecutedRoutedEventArgs e)
        {
            if (courseView.CourseGrid.SelectedIndex >= 0)
            {
                courseRegister.course = courseView.CourseGrid.SelectedItem as Courses;
                courseRegister.LoadData();
                Courses course = courseView.CourseGrid.SelectedItem as Courses;
                CourseDetailTab.Label = course.CourseTitle;

                CourseDetailTab.IsActive = true;
                UIElement[] viUI = { RegistedCourseTab };
                UIElement[] coUI = { courseTab, studentTab };
                VisibilityAndCollapsedUI(viUI, coUI);
                ribbonControl.SelectedTab = RegistedCourseTab;
                ShowView(courseRegister);
            }
            else
            {
                MessageBox.Show("Please Select Course To View Detail", "Access Course Detail");
            }

        }

        private void RibbonExitCourseDetail_Click(object sender, ExecutedRoutedEventArgs e)
        {
            assessmentGrid.course = null;
            manageAssessment.Clear();
            assessmentGrid.assessComboBox.SelectedIndex = -1;
            manageAssessment.AssessID = 0;
            manageAssessment.course = null;
            courseRegister.course = null;
            registerStudent.course = null;
            UIElement[] coUi = { RegistedCourseTab };
            UIElement[] viUi = { courseTab, studentTab };
            VisibilityAndCollapsedUI(viUi, coUi);
            courseView.CourseGrid.SelectedIndex = -1;
            CourseDetailTab.IsActive = false;
            ribbonControl.SelectedTab = courseTab;
            ShowView(courseView);
        }

        #endregion

        private void RibbonAddStudentByCode_Click(object sender, ExecutedRoutedEventArgs e)
        {
           //TODO: To Add Student By Student Code to Registers Table
            registerStudent.course = courseRegister.course;
            ribbonControl.SelectedTab = RegisterStudenTab;
            registerStudent.LoadGroupData();
            ShowView(registerStudent);
            
            
        }

        private void RegisterStudenTab_Select(object sender, RoutedEventArgs e)
        {
            registerStudent.LoadGroupData();
            ShowView(registerStudent);
        }

        private void RegisterCourseTab_Select(object sender, RoutedEventArgs e)
        {
            registerStudent.course = courseRegister.course;
            courseRegister.LoadData();
            ShowView(courseRegister);
        }

        private void ReportTab_Select(object sender, RoutedEventArgs e)
        {
            
        }

      

        private void RibbonDeleteOfCourse_Click(object sender, ExecutedRoutedEventArgs e)
        {
            if (courseRegister.CourseRegiserGrid.SelectedIndex >= 0)
            {
                 Registers reg = courseRegister.CourseRegiserGrid.SelectedItem as Registers;
                 if (MessageBox.Show("Confirm To Remove Student:\nStudent Code: " + reg.Students.StudentCode + 
                     "\nStudent Name: " + reg.Students.StudentFirstName + " " + reg.Students.StudentLastName
                     + "\nStudent Group: " + reg.Students.StudentGroup.GroupTitle, 
                     "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                 {
                     CourseData.db.Registers.DeleteOnSubmit(reg);
                     CourseData.db.SubmitChanges();
                     courseRegister.LoadData();
                     MessageBox.Show("Remove Student Successfully", "Remove");
                 }                    
            }
            else
            {
                MessageBox.Show("Please Select Student To Delete Out Of This Course", "Delete");
            }
           
        }

        private void AssessmentTab_Select(object sender, RoutedEventArgs e)
        {
            assessmentGrid.course = courseRegister.course;
            assessmentGrid.LoadData();
            ShowView(assessmentGrid);

            
        }

        

        private void RibbonManageAssess_Click(object sender, ExecutedRoutedEventArgs e)
        {
            manageAssessment.course = courseRegister.course;
            manageAssessment.LoadData();
            ShowView(manageAssessment);

        }

        private void ManageAssessmentTab_Select(object sender, RoutedEventArgs e)
        {
            manageAssessment.course = courseRegister.course;
            manageAssessment.LoadData();
            ShowView(manageAssessment);
        }
        
          
    }
}
