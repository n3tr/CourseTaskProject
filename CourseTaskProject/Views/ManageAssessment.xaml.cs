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
    /// Interaction logic for ManageAssessment.xaml
    /// </summary>
    public partial class ManageAssessment : UserControl
    {
        private Courses _course;
        private int _AssessID;
        public ManageAssessment()
        {
            InitializeComponent();
        }

        public Courses course
        {
            get { return _course; }
            set { _course = value; }
        }

        public int AssessID
        {
            get { return _AssessID; }
            set { _AssessID = value; }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }


        public void LoadData()
        {
            var Ass = (from a in CourseData.db.Assessments
                       where a.Courses == this.course
                       select a);

            AssessList.ItemsSource = Ass.ToList();
        }

        public void Clear()
        {
            AssessmentTitleTxt.Text = "";
            MaxScoreTxt.Text = "";
            AssessID = 0;
            AssessList.IsEnabled = true;
            GroupField.Visibility = Visibility.Hidden;

        }

        private void PreAddAssess_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            AssessList.IsEnabled = false;
            AddButtun.IsEnabled = false;
            DeleteButton.IsEnabled = false;
            GroupField.Visibility = Visibility.Visible;
            UpdateGroupBth.Visibility = Visibility.Hidden;
            AddGroupBth.Visibility = Visibility.Visible;
        }

        private void DeleteAssess_Click(object sender, RoutedEventArgs e)
        {
               if (AssessList.SelectedIndex >= 0)
               {
                   if (MessageBox.Show("Confirm Delete Group Of Student", "Delete Student", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                   {
                       var n = (from a in CourseData.db.Assessments
                                where a == AssessList.SelectedItem as Assessments
                                select a).Count();
                       if (n > 0)
                       {
                           Assessments ass = (from a in CourseData.db.Assessments
                                                where a == AssessList.SelectedItem as Assessments
                                select a).FirstOrDefault();
                           CourseData.db.Assessments.DeleteOnSubmit(ass);
                           CourseData.db.SubmitChanges();
                           Clear();
                           LoadData();
                       }
                   }
                
               }
               else
               {
                   MessageBox.Show("Please Select Group to Delete", "Can't Delete");
               }

           
        }

        private void AddAssessBth_Click(object sender, RoutedEventArgs e)
        {
            if (AssessID == 0 && AssessmentTitleTxt.Text.Trim() != "")
            {
     
                try
                {
                 Assessments ass = new Assessments();
                 ass.AssessTitle = AssessmentTitleTxt.Text;
                 ass.CourseID = this.course.CourseID;
                 if (MaxScoreTxt.Text.Trim() != ""){
                     ass.AssessMaxScore = Int32.Parse(MaxScoreTxt.Text);
                            }
                            else
                             {
                        ass.AssessMaxScore = 100;
                         }
                    CourseData.db.Assessments.InsertOnSubmit(ass);
                    CourseData.db.SubmitChanges();

                    
                    Clear();

                    /*
                     * Add Student To Assessment and will be insert to Score Table
                     * */

                    var student = (from s in CourseData.db.Registers
                                   where s.Courses == this.course
                                   select s.Students);
                    Assessments lass = (from a in CourseData.db.Assessments
                                        where a.AssessTitle == ass.AssessTitle
                                        select a).FirstOrDefault();
                    
                        foreach (Students s in student)
                        {
                            Scores score = new Scores();
                            score.StudentID = s.StudentID;
                            score.AssessID = lass.AssessID;
                            score.Score = 0;
                            CourseData.db.Scores.InsertOnSubmit(score);
                        }
                        
                        CourseData.db.SubmitChanges();
                        
                    

                   

                    LoadData();
                    GroupField.Visibility = Visibility.Hidden;
                    MessageBox.Show("Added Group");
                    AssessList.IsEnabled = true;
                    AddButtun.IsEnabled = true;
                    DeleteButton.IsEnabled = true;
                        
                   
                    
                 

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Assessment Title Can't Empty");
            }
        }

        private void UpdateAssessBth_Click(object sender, RoutedEventArgs e)
        {
            if (AssessmentTitleTxt.Text.Trim() != "")
            {
                try
                {
                   Assessments ass = (from a in CourseData.db.Assessments
                                      where a.AssessID == this.AssessID
                                      select a).FirstOrDefault();
                ass.AssessTitle = AssessmentTitleTxt.Text;
               if (MaxScoreTxt.Text.Trim() != ""){
                            ass.AssessMaxScore = Int32.Parse(MaxScoreTxt.Text);

                            }
                            else
                             {
                        ass.AssessMaxScore = 100;
                         }
                CourseData.db.SubmitChanges();
                    LoadData();
                Clear();
                GroupField.Visibility = Visibility.Hidden;
                AddGroupBth.Visibility = Visibility.Visible;
                UpdateGroupBth.Visibility = Visibility.Hidden;
                AssessList.SelectedIndex = -1;
                MessageBox.Show("Updated Assessment");
                }
                catch(Exception ex){
                    MessageBox.Show(ex.ToString());
                }

                
                

                
                
            }
        }

        private void CancelAssessBth_Click(object sender, RoutedEventArgs e)
        {
            Clear();
               GroupField.Visibility = Visibility.Hidden;
               AssessList.IsEnabled = true;
               AddButtun.IsEnabled = true;
               DeleteButton.IsEnabled = true;
               AssessList.SelectedIndex = -1;
        }

        private void AssessList_Select(object sender, SelectionChangedEventArgs e)
        {
            if (AssessList.SelectedIndex >= 0)
            {
                Clear();
               // AssessID = Int32.Parse(AssessList.SelectedValue.ToString());
                Assessments a = AssessList.SelectedItem as Assessments;
                



                Assessments assessment = (from g in CourseData.db.Assessments
                                      where g ==  a
                                      select g).FirstOrDefault();
                AssessID = assessment.AssessID;
                AssessmentTitleTxt.Text = assessment.AssessTitle;
                MaxScoreTxt.Text = assessment.AssessMaxScore.ToString();
                AddGroupBth.Visibility = Visibility.Hidden;
                UpdateGroupBth.Visibility = Visibility.Visible;
                GroupField.Visibility = Visibility.Visible;
            }
        }
    }
}
