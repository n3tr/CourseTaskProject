   M S B A M L   `   `   `  ����U  QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35[<clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkitMicrosoft.Windows.Controls  5       CourseTaskProject,   &CourseTaskProject.Views.AssessmentGrid   5      W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      Idg<clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkit    5      -   5        $
��auto��5      $
��auto��6   
�������.��5      �   � RowDefinitions  5   
   �� 5	      $��50 �6   6*   �� 5
      6   .+�5   
   �� $��25��6    �� Orientation$ 
Horizontal=�6!   .+�5      �� $
��10,0q�6   Select Assessment:6;   �� 5      -   5        $��assessComboBox��5   T    �� DisplayMemberPath$ AssessTitle��6    �� SelectedValuePath$ AssessID��67   $	��150��5      5   H   5      )   #Microsoft.Windows.Controls.DataGrid  5   
   -   5        $��	ScoreGrid��5   #   $��1��6      AutoGenerateColumns .  $ ScoreID��5         CanUserAddRows .     Columns 5      3   -Microsoft.Windows.Controls.DataGridTextColumn  5      /   )Microsoft.Windows.Controls.DataGridColumn   Header$ Student Code��6)      
IsReadOnly . 	   MinWidth$	 80Q�6z   4   .Microsoft.Windows.Controls.DataGridBoundColumn
   Binding
 6Q   �� *Students.StudentCode+6z     5      $ 
First Name��6(    . $		 150Q�6|   
 6N   �� *Students.StudentFirstName+6|     5      $ 	Last Name��6(    . $		 150Q�6z   
 6M   �� *Students.StudentLastName+6z     5      $ 
Assessment��6)    . $		 150Q�6{   
 6O   �� *Assessments.AssessTitle+6{     5      $ Score��6(   $		 100Q�6^   
 68   �� *Score+ �� Mode$ TwoWay=�6^   5"      5#      5$      