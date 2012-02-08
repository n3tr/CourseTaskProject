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
    /// Interaction logic for ManageGroup.xaml
    /// </summary>
    public partial class ManageGroup : UserControl
    {
        private int _groupID;
        public ManageGroup()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            var group = (from g in CourseData.db.StudentGroup
                                  orderby g.GroupID
                                  select g);

            ListGroup.ItemsSource = group.ToList();
        }

        public int groupID
        {
            get { return _groupID; }
            set { _groupID = value; }
        }

        private void AddGroupBth_Click(object sender, RoutedEventArgs e)
        {

            if (groupID == 0 && GroupTitleTxt.Text != "")
            {
                try
                {
                    StudentGroup group = new StudentGroup();
                    group.GroupTitle = GroupTitleTxt.Text;
                    group.GroupDesc = GroupDescTxt.Text;
                    CourseData.db.StudentGroup.InsertOnSubmit(group);
                    CourseData.db.SubmitChanges();
                    Clear();
                    LoadData();
                    GroupField.Visibility = Visibility.Hidden;
                    MessageBox.Show("Added Group");
                    ListGroup.IsEnabled = true;
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
                MessageBox.Show("Group Title Can't Empty");
            }
        }
         
           public void Clear()
           {
               GroupTitleTxt.Text = "";
               GroupDescTxt.Text = "";
               groupID = 0;
               ListGroup.IsEnabled = true;
               GroupField.Visibility = Visibility.Hidden;
              
           }

           private void UserControl_Loaded(object sender, RoutedEventArgs e)
           {
               LoadData();
           }

           private void PreAddGroup_Click(object sender, RoutedEventArgs e)
           {
               Clear();
               ListGroup.IsEnabled = false;
               AddButtun.IsEnabled = false;
               DeleteButton.IsEnabled = false;
               GroupField.Visibility = Visibility.Visible;
               UpdateGroupBth.Visibility = Visibility.Hidden;
               AddGroupBth.Visibility = Visibility.Visible;
           }

           private void GroupList_Select(object sender, SelectionChangedEventArgs e)
           {
               if (ListGroup.SelectedIndex >= 0)
               {
                   Clear();
                   groupID = Int32.Parse(ListGroup.SelectedValue.ToString());
                  
                   

                   StudentGroup group = (from g in CourseData.db.StudentGroup
                                         where g.GroupID == groupID
                                         select g).FirstOrDefault();
                   groupID = group.GroupID;
                   GroupTitleTxt.Text = group.GroupTitle;
                   GroupDescTxt.Text = group.GroupDesc;
                   AddGroupBth.Visibility = Visibility.Hidden;
                   UpdateGroupBth.Visibility = Visibility.Visible;
                   GroupField.Visibility = Visibility.Visible;
               }
              
              
           }

           private void UpdateGroupBth_Click(object sender, RoutedEventArgs e)
           {
               if (GroupTitleTxt.Text != "")
               {
                   StudentGroup group = (from g in CourseData.db.StudentGroup
                                         where g.GroupID == groupID
                                         select g).FirstOrDefault();
                   group.GroupTitle = GroupTitleTxt.Text;
                   group.GroupDesc = GroupDescTxt.Text;
                   CourseData.db.SubmitChanges();

                  
                   LoadData();
                   Clear();
                   GroupField.Visibility = Visibility.Hidden;
                   AddGroupBth.Visibility = Visibility.Visible;
                   UpdateGroupBth.Visibility = Visibility.Hidden;
                   ListGroup.SelectedIndex = -1;
                   MessageBox.Show("Updated Group");
               }
              
           }

           private void CancelGroupBth_Click(object sender, RoutedEventArgs e)
           {
               Clear();
               GroupField.Visibility = Visibility.Hidden;
               ListGroup.IsEnabled = true;
               AddButtun.IsEnabled = true;
               DeleteButton.IsEnabled = true;
               ListGroup.SelectedIndex = -1;
              

           }

           private void DeleteGroup_Click(object sender, RoutedEventArgs e)
           {
               if (ListGroup.SelectedIndex >= 0)
               {
                   if (MessageBox.Show("Confirm Delete Group Of Student", "Delete Student", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                   {
                       var n = (from g in CourseData.db.StudentGroup
                                where g.GroupID == Int32.Parse(ListGroup.SelectedValue.ToString())
                                select g).Count();
                       if (n > 0)
                       {
                           StudentGroup group = (from g in CourseData.db.StudentGroup
                                                 where g.GroupID == Int32.Parse(ListGroup.SelectedValue.ToString())
                                                 select g).FirstOrDefault();
                           CourseData.db.StudentGroup.DeleteOnSubmit(group);
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

        
    }
}
