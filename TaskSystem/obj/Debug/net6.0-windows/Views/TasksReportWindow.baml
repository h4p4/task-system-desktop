   M S B A M L   `   `   `  ����E  ATaskSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TaskSystem.ViewsTaskSystem.Views  5   	   =#clr-namespace:TaskSystem.ViewModelsTaskSystem.ViewModels  66   (    "TaskSystem.Views.TasksReportWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:TaskSystem.Views     5   	   :
viewmodels#clr-namespace:TaskSystem.ViewModels     66     � Title$  TasksReportWindow��5   	   $	��400��6#   $
��1000��60    � 
ResizeMode$ NoResize=�5	   	   $��Italic$�5
   	   $��SemiBold"�5   	   $��13(�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��20 10 20 10q�6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6   .+�5   
   � $��1��6    � RowDefinitions 5      �� 5      $
��0.5* �6    �� 5      �� 5      �� 5      $
��0.5* �6    .+�5      �� $��	Pre-view:��6   $��30(�6)   $��1��67   &   System.Windows.Controls.DataGrid  5      -   5        $��AllTasksDataGrid��5   z   $��1��69   $��1��6I   $��3��6V      
IsReadOnly$
 True��6h      AutoGenerateColumns$ False��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6/      CanUserResizeColumns$ False��6?   	   CanUserResizeRows$	 False��6\   
   CanUserReorderColumns$
 False��6v   $   HorizontalScrollBarVisibility$ Disabled=�6�      MinRowHeight$ 40Q�5         HeadersVisibility$ Column=�6%      HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����$��11(�5      $��0 -8 0 4q�6!   ��5      �� *
AllTasks+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       -   5        id��,  &System.Windows.Controls.DataGridColumn   Width$
 0.5* 5    5      Header$	 №��6B   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6M   �� *Id+  5!      -   5        	title��$
 0.5* 5!   8   $ Title��6E    6T   �� *Title+   ElementStyle 5"      �� 5#       �� 
TargetType" ��6$   .�5$   "   ��  �� Property � �� �� Value$
 Wrap=�6A   5%      5'        5(      -   5        description��$ 2* 5(   >   $ Description��6I    6^   �� *Description+ 5)      �� 5*      " ��6$   .�5+   "   ��  � ��$
 Wrap=�6A   5,      5.        5/      -   5        pubDate��$ 2* 5/   :   $ Creation date/time��6E    6a   �� *PublicationDate+  50      -   5        creator��$ 2* 50   :   $ Creator user��6E    51      `� 52       �� StringFormat$ {0} {1} {2} ��6+   .1�53   "   ��  �� Path$ CreatorUser.Surname�6*   �� 54   "   $ CreatorUser.FirstName�6*   �� 55   "   $ CreatorUser.MiddleName�6*   56      58        59      -   5        acceptor��$ 2* 59   ;   $ Accepted user��6F    5:      `� 5;      $ {0} {1} {2} ��6+   .1�5<   "   �� $ AcceptedUser.Surname�6*   �� 5=   "   $ AcceptedUser.FirstName�6*   �� 5>   "   $ AcceptedUser.MiddleName�6*   5?      5A        5B      -   5        
status��$ * 5B   9   $ Status��6C    6S   �� *TaskStatus.Title+5D      5E      �� 5F   
    �� Orientation$ 
Horizontal=�6   .+�5G      �� .+�5H      �� $��	Settings:��6   $��30(�6-   $��0��6;   �� 5I      $��0 12 0 0q�6   Saving format:6>   �� 5J      $��0 12 0 0q�6   
Directory:6:   �� 5K      $��0 12 0 0q�6   
Headers:68   5L      �� 5M      $��80��6   .+�5N      �� -	   5        $��SavingTypeCombobox��5N      $��0 49 0 0q�65   $��Center=�6G   $��10 2 2 2q�6k    �� SelectedIndex$ 0��6~   .@�5O      �� $	��Pdf��6#   �� 5P      $
��Word��6#   �� 5Q      $��Excel��6#   5R      �� 5S      -
   5        $��DirectoryChangerBtn��5S   <   $��0 12 0 0q�6   $��Choose��6+   6{   �� 5T      -   5        $��EnableHeadersChBox��5T   -   $��0 10 0 0q�6   6�   5U      5V      � 5W   
   $��Bottom=�6   $��35��6*    5X      �� 5Y      �� 5Z      .+�5\   
   �� -   5        $��SaveBtn��5\   =   $��0��6   $
��10 4q�6!   $��15(�6/   .��6b   Save6h   �� 5]   
   -   5        $��	CancelBtn��5]   W   $��1��6   $
��10 4q�6!   ��6/   �� *CancelSavingCommand+.��6�   Cancel6�   5^      5`      5a      