   M S B A M L   `   `   `  ���� E  ATaskSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TaskSystem.ViewsTaskSystem.Views  =#clr-namespace:TaskSystem.ViewModelsTaskSystem.ViewModels  '    !TaskSystem.Views.TaskSystemWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:TaskSystem.Views     :
viewmodels#clr-namespace:TaskSystem.ViewModels     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  -   $��Italic$�$��SemiBold"�$��13(�  � Title$  Task System��$	��720��$
��1280��$	��800��$	��402�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanResizeWithGrip=� � 	Resources 5   /TaskSystem.ViewModels.TaskSystemWindowViewModel   vm��%   &	           � DataContext ��  �� Source# [  .���� $��10q����#F5F5F5._��  � RowDefinitions �� $
��0.2* �$��25���� $
��0.2* �$��15���� $	��16* � � ColumnDefinitions �� -    �Name$ AllUsersGridLeftColumn��$��* ��� -   $ AllUsersGridRightColumn��$	��300��.+�� -   $��LeftGrid��$��2��$��0��$��1��$��0 0 0 10q�	 K� ZIndex$	 1��$
��Left=� �� -   
 ��Name$
 TopRowShowAllUsers��$	��20* ��� -   $
 BottomRowShowUsersTasks��$��0* ��� $��* �$��40��.+�&   System.Windows.Controls.DataGrid  -     Name$ 
UsersDGrid��$��0��$y�Hidden=�   
IsReadOnly$
 True��   AutoGenerateColumns$ False��   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    CanUserResizeColumns$ False��   CanUserResizeRows$ False��   CanUserReorderColumns$ False��$   HorizontalScrollBarVisibility$ Disabled=�   	RowHeight$ 30Q�   HeadersVisibility$ Column=�   HorizontalGridLinesBrush �#F5F5F5   VerticalGridLinesBrush �#F5F5F5���� *
AllUsers+ �� SelectedItem �� *SelectedUser+ �� UpdateSourceTrigger$ PropertyChanged=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
First Name��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	FirstName+  $ Surname�� �� *	Surname+  $ Middle Name�� �� *
MiddleName+  $ Login�� �� *Login+  $ Phone Number�� �� *PhoneNumber+     FontSize$ 22Q�$ Count of accepted�� �� *CountOfAccepted+$ PropertyChanged=� �� Mode$ TwoWay=�  $ 22Q�$ Count of created�� �� *CountOfCreated+$ PropertyChanged=�$ TwoWay=�  -   $ TasksOfSelectedUserDGrid��$��1��$y�Hidden=�$
 True��$ False��$ * $ False��$ False��$ False��$ Disabled=�   MinRowHeight$ 40Q�$ Column=� �#F5F5F5 �#F5F5F5���� *TasksOfSelectedUser+$ PropertyChanged=�      Width$
 0.5* $	 №�� �� *Id+  $ 2* $ Title�� �� *Title+  $	 10* $ Description�� �� *Description+    ElementStyle  �� ! �� 
TargetType"! ��.��� " �� Property" � ��# �� Value$
# Wrap=�  $ 2* $ Creation date/time�� �� *PublicationDate+  $
 1.5* $ Status�� �� *TaskStatus.Title+�� -	   $��ShowAllUserBorder��$��2�����#F5F5F5
�������$��5 0 5 5q�$��	0 0 0 -10q�$y�Hidden=�._��  �� $��* ��� $��* ��� $
��3.1* �.+��� -
   $��ShowTasksUserAccept��$y�Hidden=�$
{�True��$��0��$��	5 0 2.5 0q�$��35��$!��Show tasks accepted by user������ *ShowTasksUserAcceptCommand+�� -   $��ShowTasksUserMade��$y�Hidden=�$
{�True��$��1��$��	5 0 2.5 0q�$��35��$��Show tasks made by user������ *ShowTasksUserMadeCommand+� $��8��$��3�� �� $
��0.2* �$��25���� $
��0.2* �$��15���� $	��16* � �� -   $
 firt��$
��0.5* �$	��120���� -   $
 secd��$
��0.5* �$	��120���� -   $
 thrd��$��8* �$	��120���� -   $
 frth��$
��0.5* �$	��120���� -   $
 ffth��$
��0.5* �$	��120���� -   $ GlobalGridRightColumn��$��0* �$	��300��.+��� -   $��TasksTabControl��$��2��$��5��$y�Visible=�.@��� -   $��
myTasksTab������ 
My Tasks���  �� $
��0.7* �$��15��$��20���� $
��1.5* �$��50���� $��4* �$	��170���� $
��3.5* �$	��150���� $��4* �$	��140���� $��2* �$��65�� �� $
��0.5* �$��23���� $	��14* ��� $��* �.+��� $��0��№�� $��1��$��70��Title�� $��2��$	��200��Description�� $��3��Creation date/time�� $��4��Creator User�� $��6��Status�� -   $��TaskList��$��Visible=�$��False��$��Stretch=�$��Stretch=�$��1��$��6��$��5������ *TasksAccepted+$ PropertyChanged=� �� $ �� Path$$ SelectedTask�$ PropertyChanged=����� .R��� 
�������$��0 0 0 1q�._��  �� $
��0.6* �$��15���� $
��1.5* �$��50���� $��4* �$	��170���� $
��3.5* �$	��150���� $��4* �$	��140���� $��2* �$��65�� �� $��* �$��25��$	��400��.+�� $	 0��$��1��$��7��$��3�� �� $
��0.6* �$��15���� $
��1.5* �$��50���� $��4* �$	��170���� $
��3.5* �$	��150���� $��4* �$	��140���� $��2* �$��65��.+��� $��0������ *Id+�� $��TaskAcceptedTitleTBlock��$��1��$
��Wrap=�$��70������ *Title+�� $��TaskAcceptedDescTBlock��$��2��$	��200��$
��Wrap=�$	��200������ *Description+�� $��3������ *PublicationDate+�� $��4����`� % �� StringFormat$% {0} {1} {2} ��.1��� $$ CreatorUser.Surname��� $$ CreatorUser.FirstName��� $$ CreatorUser.MiddleName��� $��TaskStatusCBox��$��20��& �� SelectedValuePath$& Id��' �� DisplayMemberPath$' Title��$��5��$
��Left=�$��28��$��Center=�$	��Top=�$��5 0 0 2q�$��0 0 0 3q�$	��121������ *TaskStatuses+# [  ( �� SelectedValue( �� *TaskStatusId+$ PropertyChanged=�*  $Microsoft.Xaml.Behaviors.Interaction)   Triggers) +  %Microsoft.Xaml.Behaviors.EventTrigger  *   	EventName$* SelectionChanged��*	  $Microsoft.Xaml.Behaviors.TriggerBase+ 	  Actions.+ 2
  ,Microsoft.Xaml.Behaviors.InvokeCommandAction
  , 
  Command, �� *'%TaskStatusCBoxSelectionChangedCommand+# [  - 
  CommandParameter- �� . �� ElementName$. TaskCBox���� -   $��availableTasksTab������ Available Tasks���  �� $
��0.6* �$��15��$��20���� $
��1.5* �$��50���� $��4* �$	��170���� $
��3.5* �$	��150���� $��4* �$	��140���� $��2* �$��65�� �� $
��0.5* �$��23���� $	��14* ��� $��50 ��� -   $ 	BottomRow��$��40 �$	��200��$��37��.+��� $��0��№�� $��1��$��70��Title�� $��2��$	��200��Description�� $��3��Creation date/time�� $��4��Creator User�� -   $��TaskListAvailable��$��Visible=�$��False��$��Stretch=�$��Stretch=�$��1��$��6��$��5������ *TasksAvailable+$ PropertyChanged=� �� *SelectedTask+$ PropertyChanged=����� .R��� 
�������$��0 0 0 1q�._��  �� $
��0.5* �$��15���� $
��1.5* �$��50���� $��4* �$	��170���� $
��3.5* �$	��150���� $��4* �$	��140���� $��2* �$��65�� �� $��* �$��25��$	��400��.+��� $��0������ *Id+�� $��TaskAvailableTitleTBlock��$��1��$
��Wrap=�$��70������ *Title+�� $��TaskAvailableDescTBlock��$��2��$	��200��$
��Wrap=�$	��200������ *Description+�� $��3������ *PublicationDate+�� $��4����`� $% {0} {1} {2}��.1��� $$ CreatorUser.Surname��� $$ CreatorUser.FirstName��� $$ CreatorUser.MiddleName��� $��AcceptTaskBtn��-   $	��Top=�$��5q�$��5��$��60��$��25��$y�Visible=�/ �� 	IsDefault$/ False������ $$ AcceptTaskClickedCommand�# [  ���� *AcceptAndDeleteButtonContent+$ PropertyChanged=�# [  �� 
�������
�������$��0 5 0 0q�$��3��$��6��$��-1 -11 -1 -1q�._��  �� $��* ��� $��* ��� $��6* � �� �� -   $ BottomRowLastRow��$��40 �$��40��.+��� -   $��
AddTaskBtn��$��2��$��Center=�$��18(�$��0��$��	5 0 2.5 0q�$��35��$��35��$��Add task������ *AddTaskCommand+�� -   $��CancelAddTaskBtn��$��2��$��Center=�$��18(�$��1��$��	2.5 0 5 0q�$��35��$��35��$��Cancel��$y�Hidden=����� *CancelAddTaskCommand+� -   $��NewTaskInformationGrid��$��2��$��1��$��10 0 0 0q�$y�Hidden=� �� $��25 ��� $��25 ��� $��25 ��� �� .+��� -   $��TaskAddTitle��$��20(�$��0��Title:�� -   $��TaskAddDescription��$��20(�$��2��Description:�� -   $��NewTaskTitleTBox��$��1��$��	-5 2 4 -2q����� *NewTaskTitle+$ PropertyChanged=��� -    $��NewTaskDescTBox��$��3��$��
-5 5 4 -23q�0 �� TextWrapping$
0 Wrap=����� *NewTaskDescription+$ PropertyChanged=��� -!   $��TaskCBox��$��2��$��4��$	��Top=�$
��Auto������ *TaskComboBoxItems+$ PropertyChanged=� �� $$ TaskComboBoxSelectedItem�$ TwoWay=�$ PropertyChanged=�)   $* SelectionChanged��.+ 
  , �� *!TaskCBoxSelectionChangedCommand+�� -"   $��FilterTaskCBox��$��2��$��4��$	��Top=�$	��120��$y�Visible=����� *FilterTaskCBoxItems+ �� *FilterTaskCBoxSelectedItem+)   $* SelectionChanged��.+ 
  , �� *'%FilterTaskCBoxSelectionChangedCommand+�� -#   $��FilterByUserLoginTBox��$	��100��$��23��$��2��$��3��$y�Hidden=�$
��Left=�$	��Top=����� *FilterByUserText+$ PropertyChanged=��� -$   $��ShowRightTabBtn��$��	10 1 10 1q�$��Right=�$��3��$��2��$��Show my profile���� 1 �� Orientation$1 
Horizontal=�$��3��.+��� -%   $��AllUsersBtn��$��	10 1 10 1q�$��0��$��0 0 10 0q�$
��Left=�$��Show all users������ *UpdateAllUsersDGridCommand+�� -&   $��TasksReportBtn��$��	10 1 10 1q�$��0��$��Tasks report������ *OpenTasksReportWindowCommand+�� 
�������
�������$��5 5 0 5q�$��5��$��8��$��
10 0 -10 0q�._�� $��5q� �� $	��10* ��� $
��0.5* �$��40��.+�� $��5 5 5 0q� �� $��* �$��25���� $��* �$��25���� $��* �$��25���� $��* �$��25���� $��* �$��25���� $��* �$��25���� $��* �$��25���� $	��30* � �� $��* ��� $��* �.+��� $��0��$��1������ *CurrentUser.Surname+�� $��1��$��1������ *CurrentUser.FirstName+�� $��2��$��1������ *CurrentUser.MiddleName+�� $��3��$��1������ *CurrentUser.PhoneNumber+�� $��4��$��1������ *CurrentUser.Login+�� $��5��$��1������ *CurrentUser.Password+�� $��6��$��1������ *CurrentUser.CountOfAccepted+�� $��7��$��1������ *CurrentUser.CountOfCreated+�� $��0��$��0��$��	Surname: ���� $��1��$��0��$��First Name: ���� $��2��$��0��$��Middle Name: ���� $��3��$��0��$��Phone Number: ���� $��4��$��0��$��Login: ���� $��5��$��0��$��
Password: ���� $��6��$��0��$��Accepted tasks: ���� $��7��$��0��$��Created tasks: ���� $��1��
�������$��0 5 0 0q�$��-10 0 -10 0q�._�� $��5 5 5 0q� �� $��* ��� $��* �.+��� -'   $��	LogOutBtn��$��15(�$��0��$��	5 0 2.5 0q�$��35������ *LogOutCommand+.��	Log Out�� -(   $��ExitBtn��$��15(�$��1��$��	2.5 0 5 0q�$��35��.��Exit