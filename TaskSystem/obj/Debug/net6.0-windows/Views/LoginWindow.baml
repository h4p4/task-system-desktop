   M S B A M L   `   `   `  ����E  ATaskSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TaskSystem.ViewsTaskSystem.Views  5   	   =#clr-namespace:TaskSystem.ViewModelsTaskSystem.ViewModels  66   "    TaskSystem.Views.LoginWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:TaskSystem.Views     5   	   :
viewmodels#clr-namespace:TaskSystem.ViewModels     66   $��Italic$�5   	   $��SemiBold"�5	   	     � Title$  LoginWindow��5
   	   $	��150��6   $	��210��6*   $	��150��5   	   $	��210��6   $	��150��5   	   $	��210��6    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� -   5        $��LogTBox��5   �   $��0��6W   $��0��6d   $��3��6t   $	��160��6�   $��25��6�   $��Bottom=�6�   ��6   �� *EnteredLogin+ �� UpdateSourceTrigger$ PropertyChanged=�6  �� 5   
   -   5        $��PassPBox��5   �   $��1��6Z   $��0��6g   $��3��6w   $	��160��6�   $��25��6�   $	��Top=�6�   ��6   �� *EnteredPassword+$ PropertyChanged=�6
  �� 5   
   -   5        $��	LogTBlock��5   t   
������� J� IsHitTestVisible$ False��6*   $��0��6C   $��0��6P   $��3��6`   $	��160��6�   $��25��6�   $��Bottom=�6�   Login6�   �� 5   
   -   5        $��
PassTBlock��5   t   
�������$ False��6*   $��1��6C   $��0��6P   $��3��6`   $	��160��6�   $��25��6�   $	��Top=�6�   
Password6�   �� 5   
   -   5        $��	LogButton��5   i   $��2��68   $��0��6E   $��2��6U   $��75��6z   $��25��6�   $
��Left=�6�   $��17 5 5 5q�6�    �� 	IsDefault$
 True��6�   ��6   �� *UserLogInCommand+.��6�   Log In6�   �� 5   
   -   5        $��	RegButton��5   h   $��2��67   $��1��6D   $��3��6T   $��75��6y   $��25��6�   $��Right=�6�   $��5 5 17 5q�6�   ��6   �� *UserSignUpCommand+.��6�   	Sign Up6�   5      5       