   M S B A M L   `   `   `  ���� U  QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35[<clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkitMicrosoft.Windows.Controls   CourseTaskProject,   &CourseTaskProject.Views.AssessmentGrid   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      8x,http://schemas.microsoft.com/winfx/2006/xaml    Idg<clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkit    -   $
��auto��$
��auto��
�������.���   � RowDefinitions  �� $��50 ��� .+��� $��25�� �� Orientation$ 
Horizontal=�.+��� $
��10,0q�Select Assessment:�� -   $��assessComboBox�� �� DisplayMemberPath$ AssessTitle�� �� SelectedValuePath$ AssessID��$	��150���� -   $
��30,5q�.��Show All Student)   #Microsoft.Windows.Controls.DataGrid  -   $��	ScoreGrid��$��1��   AutoGenerateColumns .  $ ScoreID��   CanUserAddRows .     Columns 3   -Microsoft.Windows.Controls.DataGridTextColumn  /   )Microsoft.Windows.Controls.DataGridColumn   Header$ Student Code��   
IsReadOnly . 	   MinWidth$	 80Q�4   .Microsoft.Windows.Controls.DataGridBoundColumn
   Binding
 �� *Students.StudentCode+  $ 
First Name�� . $		 150Q�
 �� *Students.StudentFirstName+  $ 	Last Name�� . $		 150Q�
 �� *Students.StudentLastName+  $ 
Assessment�� . $		 150Q�
 �� *Assessments.AssessTitle+  $ Score��$		 100Q�
 �� *Score+ �� Mode$ TwoWay=�